using DaneshkarShop.Domain.DTOs.AdminSide.User;
using DaneshkarShop.Domain.Entitties.Role;
using DaneshkarShop.Domain.Entitties.User;
namespace DaneshkarShop.Domain.IRepositories;

public interface IUserRepository
{
    #region General Methods

    bool IsExistUserByMobile(string mobile);

    void AddUser(User user);

    void SaveChange();

    User? GetUserByMobile(string mobile);

    User? GetUserById(int userId);

    void UpdateUser(User user);

    #endregion

    #region Admin Side Methods 

    List<User> ListOfUsers();

    List<ListOfUsersDTO> listOfUsersWithDTO();

    List<int> GetListOfUserRolesIdByUserId(int userId);

    List<UserSelectedRole> GetListOfUserSelectedRolesByUserId(int userId);

    void DeleteRangeOfUserSelectedRoles(List<UserSelectedRole> userSelectedRoles);

    bool IsExistAnyUserSelectedRoleByUserIdAndRoleId(int userId, int roleId);

    UserSelectedRole? GetUserSelectedRoleByUserIdAndRoleId(int userId, int roleId);

    void DeleteUserSelectedRoles(UserSelectedRole userSelectedRoles);

    #endregion
}
