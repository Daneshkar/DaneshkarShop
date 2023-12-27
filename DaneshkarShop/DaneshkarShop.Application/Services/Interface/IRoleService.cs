using DaneshkarShop.Domain.Entitties.Role;

namespace DaneshkarShop.Application.Services.Interface;

public interface IRoleService
{
    List<Role> GetUserRolesByUserId(int userId);

	bool IsUserAdmin(int userId);

    List<Role> GetListOfRoles();

    Task<List<Role>> GetListOfRolesAsync(CancellationToken cancellation);
}
