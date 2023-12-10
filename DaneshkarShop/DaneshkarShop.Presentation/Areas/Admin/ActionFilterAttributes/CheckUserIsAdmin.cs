#region Usings

using DaneshkarShop.Application.Extensions;
using DaneshkarShop.Application.Services.Interface;
using DaneshkarShop.Domain.Entitties.Role;
using Microsoft.AspNetCore.Mvc.Filters;
namespace DaneshkarShop.Presentation.Areas.Admin.ActionFilterAttributes;

#endregion

public class CheckUserIsAdmin : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
	{
		var _roleService = (IRoleService)context.HttpContext
										   .RequestServices
										   .GetService(typeof(IRoleService))!;

		base.OnActionExecuting(context);

		#region آزمودن درسترسی داشتن کاربر

		var result = _roleService.IsUserAdmin((int)context.HttpContext.User.GetUserId());
		if (result == false)
		{
			context.HttpContext.Response.Redirect("/");
		}

		#endregion
	}
}
