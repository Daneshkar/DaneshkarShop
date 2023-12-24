using DaneshkarShop.Data.AppDbContext;
using DaneshkarShop.Domain.Entitties.Role;
using DaneshkarShop.Domain.Entitties.User;
using DaneshkarShop.Domain.IRepositories;

namespace DaneshkarShop.Data.Repositories;

public class RoleRepository : IRoleRepository
{
	#region Ctor

	private readonly DaneshkarDbContext _context;

    public RoleRepository(DaneshkarDbContext context)
    {
        _context = context;
    }

    #endregion

    public List<Role> GetUserRolesByUserId(int userId)
    {
        var roles = _context.UserSelectedRoles
                            .Where(p=> p.UserId == userId)
                            .Select(p=> p.Role)
                            .ToList();
        return roles;
    }

    public List<Role> GetListOfRoles()
    {
        return _context.Roles.ToList();
    }

    public void AddUserSelectedRoleData(UserSelectedRole userSelectedRole)
    {
        _context.UserSelectedRoles.Add(userSelectedRole);
    }

    public void SaveChange()
    {
        _context.SaveChanges();
    }
}
