using DaneshkarShop.Application.Services.Interface;
using DaneshkarShop.Domain.Entitties.Role;
using DaneshkarShop.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security;

namespace DaneshkarShop.Application.Services.Implementation;

public class RoleService : IRoleService
{
	#region Ctor

	private readonly IRoleRepository _roleRepository;
	private readonly IUserRepository _userRepository;

	public RoleService(IRoleRepository roleRepository, 
					   IUserRepository userRepository)
	{
		_roleRepository = roleRepository;
		_userRepository = userRepository;
	}

	#endregion

	public List<Role> GetListOfRoles()
	{
		return _roleRepository.GetListOfRoles();
	}

    public async Task<List<Role>> GetListOfRolesAsync(CancellationToken cancellation)
    {
        return await _roleRepository.GetListOfRolesAsync(cancellation);
    }

    public List<Role> GetUserRolesByUserId(int userId)
    {
        return _roleRepository.GetUserRolesByUserId(userId);
    }

	public bool IsUserAdmin(int userId)
	{
		//Get User By Id
		var user = _userRepository.GetUserById(userId);
		if (user.SuperAdmin == true) return true;

		var userRoles = GetUserRolesByUserId(userId);

		foreach (var role in userRoles)
		{
			if (role.RoleUniqueName == "Admin")
			{
				return true;
			}
		}

		return false;
	}

}
