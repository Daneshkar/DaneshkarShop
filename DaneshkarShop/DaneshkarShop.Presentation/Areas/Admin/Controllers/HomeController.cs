using DaneshkarShop.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DaneshkarShop.Presentation.Areas.Admin.Controllers;


public class HomeController : AdminBaseController
{
    #region Ctor

    private readonly IRoleService _roleService;

    public HomeController(IRoleService roleService)
    {
            _roleService = roleService;
    }

	#endregion

	public IActionResult Index()
    {
        return View();
    }
}
