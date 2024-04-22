using DaneshkarShop.Domain.Entitties.Role;

namespace DaneshkarShop.Domain.IRepositories;

public interface IRoleRepository
{
    List<Role> GetUserRolesByUserId(int userId);

    List<Role> GetListOfRoles();

    Task<List<Role>> GetListOfRolesAsync(CancellationToken cancellation);

    void AddUserSelectedRoleData(UserSelectedRole userSelectedRole);

    void SaveChange();

    Task<List<Role>> Get_ListOfRoles(CancellationToken cancellationToken);

    Task<bool> IsExist_AnyRole_ByRoleUniqueName(string roleUniqueName, CancellationToken token);

    Task<bool> IsExist_AnyRole_ByRoleUniqueName(int roleId,
                                                string roleTitle,
                                                CancellationToken cancellationToken);

    Task Add_Role(Role role, CancellationToken cancellation);

    Task<Role?> Get_Role_ById(int roleId, CancellationToken cancellation);

    void Update_Role(Role role);
}
