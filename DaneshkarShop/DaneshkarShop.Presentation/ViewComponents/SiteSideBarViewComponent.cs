using Microsoft.AspNetCore.Mvc;

namespace DaneshkarShop.Presentation.ViewComponents;

public class SiteSideBarViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View("SiteSideBar");
    }
}
