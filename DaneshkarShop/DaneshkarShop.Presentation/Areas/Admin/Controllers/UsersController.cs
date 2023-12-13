using DaneshkarShop.Application.Services.Interface;
using DaneshkarShop.Domain.Entitties.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

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

        List<User> users = _userService.ListOfUsers();
        if (User == null) return NotFound();

        #endregion

        return View(users);
    }

    #endregion
}
