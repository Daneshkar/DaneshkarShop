using DaneshkarShop.Domain.Entitties.Role;

namespace DaneshkarShop.Domain.IRepositories;

public interface IRoleRepository
{
    List<Role> GetUserRolesByUserId(int userId);

    List<Role> GetListOfRoles();

    void AddUserSelectedRoleData(UserSelectedRole userSelectedRole);

    void SaveChange();
}
