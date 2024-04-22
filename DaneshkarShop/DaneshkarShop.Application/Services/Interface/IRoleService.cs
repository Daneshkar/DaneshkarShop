using DaneshkarShop.Domain.DTOs.AdminSide.Role;
using DaneshkarShop.Domain.Entitties.Role;

namespace DaneshkarShop.Application.Services.Interface;

public interface IRoleService
{
    List<Role> GetUserRolesByUserId(int userId);

	bool IsUserAdmin(int userId);

    List<Role> GetListOfRoles();

    Task<List<Role>> GetListOfRolesAsync(CancellationToken cancellation);

    Task<List<Role>> Get_ListOfRoles(CancellationToken cancellationToken);

    Task<bool> Create_NewRole(Create_NewRole_DTO newRole, CancellationToken cancellation);

    Task<Edit_Role_DTO?> Fill_EditRoleDTO(int roleId, CancellationToken cancellationToken);

    Task<bool> Edit_Role(Edit_Role_DTO role, CancellationToken cancellationToken);

    Task<bool> Delete_Role_ById(int role, CancellationToken cancellationToken);
}
