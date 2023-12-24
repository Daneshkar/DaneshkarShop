using DaneshkarShop.Data.AppDbContext;
using DaneshkarShop.Domain.DTOs.AdminSide.User;
using DaneshkarShop.Domain.Entitties.Role;
using DaneshkarShop.Domain.Entitties.User;
using DaneshkarShop.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace DaneshkarShop.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        #region Ctor

        private readonly DaneshkarDbContext _context;

        public UserRepository(DaneshkarDbContext context)
        {
            _context = context;
        }

        #endregion

        #region General Methods 

        public bool IsExistUserByMobile(string mobile)
        {
            return _context.Users.Any(p => p.Mobile == mobile);
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);

            SaveChange();
        }

        public void SaveChange()
        {
            _context.SaveChanges();
        }

        public User? GetUserByMobile(string mobile)
        {
            return _context.Users.SingleOrDefault(p => p.IsDelete == false && p.Mobile == mobile);
        }

        public User? GetUserById(int userId)
        {
            return _context.Users.Find(userId);
        }

        public void UpdateUser(User user) 
        {
            _context.Users.Update(user);
        }

        #endregion

        #region Admin Side Methods

        public List<User> ListOfUsers()
        {
            return _context.Users
                           .Where(p => !p.IsDelete)
                           .OrderByDescending(p => p.CreateDate)
                           .ToList();
        }

        public List<ListOfUsersDTO> listOfUsersWithDTO()
        {
            return _context.Users
                           .Where(p => !p.IsDelete)
                           .OrderByDescending(p => p.CreateDate)
                           .Select(p => new ListOfUsersDTO()
                           {
                               CreateDate = p.CreateDate,
                               Mobile = p.Mobile,
                               Username = p.Username,
                               UserId = p.UserId,
                               UserAvatar = p.UserAvatar
                           })
                           .ToList();
        }

        public List<int> GetListOfUserRolesIdByUserId(int userId)
        {
            return _context.UserSelectedRoles
                           .Where(p=> p.UserId == userId)
                           .Select(p=> p.RoleId)
                           .ToList();
        }

        public List<UserSelectedRole> GetListOfUserSelectedRolesByUserId(int userId)
        {
            return _context.UserSelectedRoles.Where(p=> p.UserId == userId).ToList();
        }

        public void DeleteRangeOfUserSelectedRoles(List<UserSelectedRole> userSelectedRoles)
        {
            _context.UserSelectedRoles.RemoveRange(userSelectedRoles);
        }

        public bool IsExistAnyUserSelectedRoleByUserIdAndRoleId(int userId , int roleId)
        {
            return _context.UserSelectedRoles.Any(p=> p.UserId == userId && p.RoleId == roleId);
        }

        public UserSelectedRole? GetUserSelectedRoleByUserIdAndRoleId(int userId, int roleId)
        {
            return _context.UserSelectedRoles.FirstOrDefault(p => p.UserId == userId && p.RoleId == roleId);
        }

        public void DeleteUserSelectedRoles(UserSelectedRole userSelectedRoles)
        {
            _context.UserSelectedRoles.Remove(userSelectedRoles);
        }

        #endregion
    }
}
