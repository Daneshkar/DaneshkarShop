using DaneshkarShop.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DaneshkarShop.Presentation.Areas.Admin.Controllers;


public class HomeController : AdminBaseController
{
    #region Ctor

    private readonly IRoleService _roleService;
    private readonly IUserService _userService;

    public HomeController(IRoleService roleService, 
                          IUserService userService )
    {
        _roleService = roleService;
        _userService = userService;
    }

    #endregion

    public async Task<IActionResult> Index(CancellationToken cancellation)
    {
        return View(await _userService.FillLandingPageModelDTO(cancellation));
    }
}
