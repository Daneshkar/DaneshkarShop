using DaneshkarShop.Application.Services.Implementation;
using DaneshkarShop.Application.Services.Interface;
using DaneshkarShop.Presentation.HttpManager;
using Microsoft.AspNetCore.Mvc;
namespace DaneshkarShop.Presentation.Areas.Admin.Controllers;

public class ContactUsController : AdminBaseController
{
    #region Ctor

    private readonly IContactUsService _contactUsService;

    public ContactUsController(IContactUsService contactUsService)
    {
        _contactUsService = contactUsService;
    }

    #endregion

    #region List Of ContactUs

    [HttpGet]
    public async Task<IActionResult> ListOfContactUs()
    {
        return View(await _contactUsService.GetListOfContactUs());
    }

    #endregion

    #region Contact Us Detail

    [HttpGet]
    public async Task<IActionResult> ContactUsDetail(int id)
    {
        return View(await _contactUsService.GetContactUsById(id));
    }

    #endregion

    #region Delete Contact Us

    public async Task<IActionResult> DeleteContactUs(int id, CancellationToken cancellation)
    {
        var res = await _contactUsService.DeleteContactUs(id);
        if (res)
        {
            return ApiResponse.SetResponse(ApiResponseStatus.Success, null, "عملیات باموفقیت انجام شده است.");
        }

        return ApiResponse.SetResponse(ApiResponseStatus.Danger, null, "عملیات باشکست مواجه شده است.");
    }

    #endregion
}
