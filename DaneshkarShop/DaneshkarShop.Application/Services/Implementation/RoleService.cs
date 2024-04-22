using DaneshkarShop.Application.Services.Interface;
using DaneshkarShop.Domain.DTOs.AdminSide.Role;
using DaneshkarShop.Domain.Entitties.Role;
using DaneshkarShop.Domain.IRepositories;
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

    public async Task<List<Role>> Get_ListOfRoles(CancellationToken cancellationToken)
    {
		return await _roleRepository.Get_ListOfRoles(cancellationToken);
    }

	public async Task<bool> Create_NewRole(Create_NewRole_DTO newRole , CancellationToken cancellation)
	{
		//Is Exist Any Role By Role UniqueName
		bool isExistRoleUniqueName = await _roleRepository.IsExist_AnyRole_ByRoleUniqueName(newRole.RoleTitle.TrimEnd().ToLower() , cancellation);
		if (isExistRoleUniqueName)
		{
			return false;
		}

        //Fill Role Entity
        Role role = new Role()
		{
			RoleTitle = newRole.RoleTitle,
			RoleUniqueName = newRole.RoleTitle.Trim().ToLower(),
        };

		//Add Record To Data Base 
		await _roleRepository.Add_Role(role , cancellation);
		_roleRepository.SaveChange();

		return true;
	}

	public async Task<Edit_Role_DTO?> Fill_EditRoleDTO(int roleId, CancellationToken cancellationToken)
	{
		//Get Role By Id 
		var role = await _roleRepository.Get_Role_ById(roleId , cancellationToken);
		if (role == null) return null;

		//Fill Return Model
		return new Edit_Role_DTO()
		{
			RoleId = roleId,
			RoleTitle = role.RoleTitle
		};
	}

	public async Task<bool> Edit_Role(Edit_Role_DTO role , CancellationToken cancellationToken)
	{
		//Get Old Role By Id 
		var oldRole = await _roleRepository.Get_Role_ById(role.RoleId , cancellationToken);
		if(oldRole == null) return false;

		//Is Exist Any Role By This Role Unique Title
		if (await _roleRepository.IsExist_AnyRole_ByRoleUniqueName(oldRole.Id , role.RoleTitle, cancellationToken)) return false;

		//Update Feilds
		oldRole.RoleTitle = role.RoleTitle;
		oldRole.RoleUniqueName = role.RoleTitle;

		_roleRepository.Update_Role(oldRole);
	    _roleRepository.SaveChange();

		return true;
	}

	public async Task<bool> Delete_Role_ById(int role , CancellationToken cancellationToken)
	{
        //Get Old Role By Id 
        var oldRole = await _roleRepository.Get_Role_ById(role, cancellationToken);
        if (oldRole == null) return false;

        //Update Feilds
        oldRole.IsDelete = true;

        _roleRepository.Update_Role(oldRole);
        _roleRepository.SaveChange();

        return true;
    }
}
