using DaneshkarShop.Domain.Entitties.Role;

namespace DaneshkarShop.Domain.IRepositories;

public interface IRoleRepository
{
    List<Role> GetUserRolesByUserId(int userId);
}
