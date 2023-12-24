using DaneshkarShop.Application.Services.Interface;
using DaneshkarShop.Application.Utilities;
using DaneshkarShop.Data.AppDbContext;
using DaneshkarShop.Domain.DTOs.AdminSide.User;
using DaneshkarShop.Domain.DTOs.SiteSode.Account;
using DaneshkarShop.Domain.Entitties.Role;
using DaneshkarShop.Domain.Entitties.User;
using DaneshkarShop.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace DaneshkarShop.Application.Services.Implementation
{
    public class UserService : IUserService
    {
        #region Ctor

        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public UserService(IUserRepository userRepository,
                           IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        #endregion

        #region General Methods

        public bool IsExistUserByMobile(string mobile)
        {
            return _userRepository.IsExistUserByMobile(mobile.Trim());
        }

        public User FillUserEntity(UserRegisterDTO userDTO)
        {
            //Object Mapping
            User user = new User()
            {
                Mobile = userDTO.Mobile.Trim(),
                Password = PasswordHelper.EncodePasswordMd5(userDTO.Password),
                Username = userDTO.Mobile,
                CreateDate = DateTime.Now
            };

            return user;
        }

        public void AddUser(User user)
        {
            _userRepository.AddUser(user);
        }

        public bool RegisterUser(UserRegisterDTO userDTO)
        {
            //Is Exist Any User By Mobile
            var isExist = IsExistUserByMobile(userDTO.Mobile);
            if (isExist == true)
            {
                return false;
            }

            //Fill Entity
            var user = FillUserEntity(userDTO);

            //Add User To Data Base 
            AddUser(user);

            return true;
        }

        public bool LoginUser(UserLoginDTO loginDTO)
        {
            //Get User By Mobile
            var user = _userRepository.GetUserByMobile(loginDTO.Mobile);
            if (user == null)
            {
                return false;
            }

            return true;
        }

        public User? GetUserByMobile(string mobile)
        {
            return _userRepository.GetUserByMobile(mobile);
        }

        #endregion

        #region Admin Side Methods

        public List<User> ListOfUsers()
        {
            return _userRepository.ListOfUsers();
        }

        public List<ListOfUsersDTO> listOfUsersWithDTO()
        {
            return _userRepository.listOfUsersWithDTO();
        }

        public EditUserAdminSideDTO? FillEditUserAdminSideDTO(int userId)
        {
            #region Get User By Id 

            var user = _userRepository.GetUserById(userId);
            if (user == null) return null;

            #endregion

            #region Fill DTO

            EditUserAdminSideDTO model = new EditUserAdminSideDTO()
            {
                Mobile = user.Mobile,
                UserId = userId,
                Username = user.Username,
                UserOriginalAvatar = user.UserAvatar,
            };

            //Get User Roles
            model.CurrentUserRolesId = _userRepository.GetListOfUserRolesIdByUserId(userId);

            #endregion

            return model;
        }

        public bool EditUserAdminSide(EditUserAdminSideDTO model, List<int> SelectedRoles)
        {
            #region Get User By Id 

            var userOrgin = _userRepository.GetUserById(model.UserId);
            if (userOrgin == null) return false;

            #endregion

            #region Update Properties

            userOrgin.Mobile = model.Mobile;
            userOrgin.Username = model.Username;

            if (model.UserAvatar != null)
            {
                //Save New Image
                userOrgin.UserAvatar = NameGenerator.GenerateUniqCode() + Path.GetExtension(model.UserAvatar.FileName);

                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/UserAvatar", userOrgin.UserAvatar);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    model.UserAvatar.CopyTo(stream);
                }
            }

            #endregion

            #region Update User Roles

            //List<UserSelectedRole> userSelectedRoles = _userRepository.GetListOfUserSelectedRolesByUserId(model.UserId);
            //if (userSelectedRoles != null && userSelectedRoles.Any())
            //{
            //    _userRepository.DeleteRangeOfUserSelectedRoles(userSelectedRoles);
            //}

            if (SelectedRoles != null && SelectedRoles.Any())
            {
                foreach (var roleId in SelectedRoles)
                {
                    if (_userRepository.IsExistAnyUserSelectedRoleByUserIdAndRoleId(model.UserId, roleId) == false)
                    {
                        UserSelectedRole userSelectedRole = new UserSelectedRole()
                        {
                            RoleId = roleId,
                            UserId = model.UserId
                        };

                        _roleRepository.AddUserSelectedRoleData(userSelectedRole);
                    }
                    else
                    {
                        var userRole = _userRepository.GetUserSelectedRoleByUserIdAndRoleId(model.UserId, roleId);
                        if (userRole != null)
                        {
                            _userRepository.DeleteUserSelectedRoles(userRole);
                        }
                    }
                }
            }
            else
            {
                List<UserSelectedRole> userSelectedRoles = _userRepository.GetListOfUserSelectedRolesByUserId(model.UserId);
                if (userSelectedRoles != null && userSelectedRoles.Any())
                {
                    _userRepository.DeleteRangeOfUserSelectedRoles(userSelectedRoles);
                }
            }

            #endregion

            _userRepository.UpdateUser(userOrgin);
            _userRepository.SaveChange();

            return true;
        }

        #endregion
    }
}
