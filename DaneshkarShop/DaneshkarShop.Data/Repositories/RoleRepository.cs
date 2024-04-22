using DaneshkarShop.Data.AppDbContext;
using DaneshkarShop.Domain.Entitties.Role;
using DaneshkarShop.Domain.Entitties.User;
using DaneshkarShop.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;

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

    public async Task<List<Role>> GetListOfRolesAsync(CancellationToken cancellation)
    {
        return await _context.Roles.ToListAsync();
    }

    public void AddUserSelectedRoleData(UserSelectedRole userSelectedRole)
    {
        _context.UserSelectedRoles.Add(userSelectedRole);
    }

    public void SaveChange()
    {
        _context.SaveChanges();
    }

    public async Task<List<Role>> Get_ListOfRoles(CancellationToken cancellationToken)
    {
        return await _context.Roles
                             .Where(p => !p.IsDelete)
                             .ToListAsync();
    }

    public async Task<bool> IsExist_AnyRole_ByRoleUniqueName(string roleUniqueName , CancellationToken token)
    {
        return await _context.Roles
                             .AnyAsync(p=> !p.IsDelete && 
                                       p.RoleUniqueName == roleUniqueName);
    }

    public async Task Add_Role(Role role , CancellationToken cancellation)
    {
        await _context.Roles.AddAsync(role);
    }

    public async Task<Role?> Get_Role_ById(int roleId , CancellationToken cancellation)
    {
        return await _context.Roles
                             .FirstOrDefaultAsync(p=> !p.IsDelete && 
                                                  p.Id == roleId);
    }

    public async Task<bool> IsExist_AnyRole_ByRoleUniqueName(int roleId , 
                                                             string roleTitle , 
                                                             CancellationToken cancellationToken)
    {
        return await _context.Roles
                             .AnyAsync(p => !p.IsDelete &&
                                            p.Id != roleId &&
                                            p.RoleUniqueName == roleTitle);
    }

    public void Update_Role(Role role)
    {
        _context.Roles.Update(role);
    }
}
