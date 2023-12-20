using DaneshkarShop.Application.Services.Interface;
using DaneshkarShop.Domain.DTOs.AdminSide.User;
using Microsoft.AspNetCore.Mvc;

namespace DaneshkarShop.Presentation.Areas.Admin.Controllers;

public class UsersController : AdminBaseController
{
    #region Ctor

    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
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

        return View(userInfo);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult EditUser(EditUserAdminSideDTO model)
    {
        if (ModelState.IsValid) 
        {
            var res = _userService.EditUserAdminSide(model);
            if (res)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        return View(model);
    }

    #endregion
}
