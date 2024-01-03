using DaneshkarShop.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;
namespace DaneshkarShop.Presentation.Areas.Admin.ViewComponents;

public class UserInfomationViewComponent : ViewComponent
{
    #region Ctor

    private readonly IRoleService _roleService;
    private readonly IUserService _userService;

    public UserInfomationViewComponent(IRoleService roleService,
                          IUserService userService)
    {
        _roleService = roleService;
        _userService = userService;
    }

    #endregion

    public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellation)
    {
        return View("UserInfomation", await _userService.FillLandingPageModelDTO(cancellation));
    }
}
