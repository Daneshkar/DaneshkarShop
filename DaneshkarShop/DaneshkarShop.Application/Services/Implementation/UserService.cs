using DaneshkarShop.Application.Services.Interface;
using DaneshkarShop.Application.Utilities;
using DaneshkarShop.Data.AppDbContext;
using DaneshkarShop.Domain.DTOs.AdminSide.User;
using DaneshkarShop.Domain.DTOs.SiteSode.Account;
using DaneshkarShop.Domain.Entitties.User;
using DaneshkarShop.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace DaneshkarShop.Application.Services.Implementation
{
    public class UserService : IUserService
    {
        #region Ctor

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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

        #endregion
    }
}
