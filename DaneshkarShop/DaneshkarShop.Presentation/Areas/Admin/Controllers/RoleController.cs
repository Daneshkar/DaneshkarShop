using DaneshkarShop.Application.Services.Implementation;
using DaneshkarShop.Application.Services.Interface;
using DaneshkarShop.Domain.DTOs.AdminSide.Role;
using DaneshkarShop.Presentation.HttpManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
namespace DaneshkarShop.Presentation.Areas.Admin.Controllers;

public class RoleController : AdminBaseController
{
    #region Ctor

    private readonly IRoleService _roleService;

    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    #endregion

    #region List Of Roles

    [HttpGet]
    public async Task<IActionResult> ListOfRoles(CancellationToken cancellationToken = default)
    {
        return View(await _roleService.Get_ListOfRoles(cancellationToken));
    }

    #endregion

    #region Create Role

    [HttpGet]
    public IActionResult CreateRole()
    {
        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateRole(Create_NewRole_DTO role , CancellationToken cancellation = default)
    {
        #region Create Role 

        if (ModelState.IsValid)
        {
            var res = await _roleService.Create_NewRole(role , cancellation);
            if (res)
            {
                return RedirectToAction(nameof(ListOfRoles));
            }
        }

        #endregion

        return View(role);
    }

    #endregion

    #region Edit Role

    [HttpGet]
    public async Task<IActionResult> EditRole(int roleId , CancellationToken cancellationToken)
    {
        //Get Role By ID 
        var model = await _roleService.Fill_EditRoleDTO(roleId , cancellationToken);
        if (model == null) return NotFound();

        return View(model);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> EditRole(Edit_Role_DTO model , CancellationToken cancellationToken = default)
    {
        //Update Role Method 
        var res = await _roleService.Edit_Role(model , cancellationToken);
        if (res)
        {
            return RedirectToAction(nameof(ListOfRoles));
        }

        return View(model);
    }

    #endregion

    #region Delete Role

    public async Task<IActionResult> DeleteRole(int roleId, CancellationToken cancellation)
    {
        var res = await _roleService.Delete_Role_ById(roleId, cancellation);
        if (res)
        {
            return ApiResponse.SetResponse(ApiResponseStatus.Success, null, "عملیات باموفقیت انجام شده است.");
        }

        return ApiResponse.SetResponse(ApiResponseStatus.Danger, null, "عملیات باشکست مواجه شده است.");
    }

    #endregion
}
