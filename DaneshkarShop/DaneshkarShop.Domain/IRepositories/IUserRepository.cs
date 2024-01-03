using DaneshkarShop.Domain.DTOs.AdminSide.LandingPage;
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

    Task SaveChangeAsync(CancellationToken cancellation);

    User? GetUserByMobile(string mobile);

    User? GetUserById(int userId);

    Task<User?> GetUserByIdAsync(int userId , CancellationToken cancellationToken);

    void UpdateUser(User user);

    #endregion

    #region Admin Side Methods 

    Task<LandingPageModelDTO?> FillLandingPageModelDTO(CancellationToken cancellation);

    List<User> ListOfUsers();

    List<ListOfUsersDTO> listOfUsersWithDTO();

    List<int> GetListOfUserRolesIdByUserId(int userId);

    Task<List<int>> GetListOfUserRolesIdByUserIdAsync(int userId, CancellationToken cancellationToken);

    List<UserSelectedRole> GetListOfUserSelectedRolesByUserId(int userId);

    void DeleteRangeOfUserSelectedRoles(List<UserSelectedRole> userSelectedRoles);

    bool IsExistAnyUserSelectedRoleByUserIdAndRoleId(int userId, int roleId);

    UserSelectedRole? GetUserSelectedRoleByUserIdAndRoleId(int userId, int roleId);

    void DeleteUserSelectedRoles(UserSelectedRole userSelectedRoles);

    #endregion
}
