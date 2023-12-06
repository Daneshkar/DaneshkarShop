using DaneshkarShop.Application.Services.Interface;
using DaneshkarShop.Domain.Entitties.Role;
using DaneshkarShop.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace DaneshkarShop.Application.Services.Implementation;

public class RoleService : IRoleService
{
	#region Ctor

	private readonly IRoleRepository _roleRepository;

	public RoleService(IRoleRepository roleRepository)
	{
		_roleRepository = roleRepository;
	}

    #endregion

    public List<Role> GetUserRolesByUserId(int userId)
    {
        return _roleRepository.GetUserRolesByUserId(userId);
    }
}
