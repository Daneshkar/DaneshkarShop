using DaneshkarShop.Application.Services.Interface;
using DaneshkarShop.Domain.DTOs.AdminSide.User;
using Microsoft.AspNetCore.Mvc;
namespace DaneshkarShop.Presentation.Areas.Admin.Controllers;

public class UsersController : AdminBaseController
{
    #region Ctor

    private readonly IUserService _userService;
    private readonly IRoleService _roleService;

    public UsersController(IUserService userService, 
                           IRoleService roleService)
    {
        _userService = userService;
        _roleService = roleService;

    }

    #endregion

    #region List Of User

    public IActionResult Index()
    {
        #region Get List Of Users

        var users = _userService.listOfUsersWithDTO();
        if (User == null) return NotFound();

        #endregion

        return View(users);
    }

    #endregion

    #region Edit User

    [HttpGet]
    public IActionResult EditUser(int userId)
    {
        //Get User Information
        var userInfo = _userService.FillEditUserAdminSideDTO(userId);
        if (userInfo == null) return NotFound();

        #region View Datas

        ViewBag.Roles = _roleService.GetListOfRoles();

        #endregion

        return View(userInfo);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult EditUser(EditUserAdminSideDTO model , List<int>? SelectedRoles)
    {
        if (ModelState.IsValid) 
        {
            var res = _userService.EditUserAdminSide(model , SelectedRoles);
            if (res)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        #region View Datas

        ViewBag.Roles = _roleService.GetListOfRoles();

        #endregion

        return View(model);
    }

    #endregion
}
