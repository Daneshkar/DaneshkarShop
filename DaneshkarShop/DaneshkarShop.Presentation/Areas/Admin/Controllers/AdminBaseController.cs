using DaneshkarShop.Presentation.Areas.Admin.ActionFilterAttributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace DaneshkarShop.Presentation.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize]
[CheckUserIsAdmin]
public abstract class AdminBaseController : Controller
{
}
