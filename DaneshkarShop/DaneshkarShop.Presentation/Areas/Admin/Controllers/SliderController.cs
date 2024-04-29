using DaneshkarShop.Application.Services.Implementation;
using DaneshkarShop.Application.Services.Interface;
using DaneshkarShop.Domain.DTOs.AdminSide.Slider;
using DaneshkarShop.Presentation.HttpManager;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DaneshkarShop.Presentation.Areas.Admin.Controllers;

public class SliderController : AdminBaseController
{
    #region ctor

    private readonly ISliderService _sliderService;

    public SliderController(ISliderService sliderService)
    {
        _sliderService = sliderService;
    }

    #endregion

    #region List Of Sliders

    public async Task<IActionResult> ListOfSliders()
    {
        return View();
    }

    #endregion

    #region Create Slider

    [HttpGet]
    public IActionResult CreateSlider()
    {
        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateSlider(Create_Clider_AdminSide_DTO model,
                                                 CancellationToken cancellationToken = default)
    {
        if (ModelState.IsValid)
        {
            var res = await _sliderService.CreateSlider(model, cancellationToken);
            if (res)
            {
                return RedirectToAction(nameof(ListOfSliders));
            }
        }

        return View(model);
    }


    #endregion

    #region Edit Slider 

    [HttpGet]
    public async Task<IActionResult> EditSlider(int sliderId, CancellationToken cancellationToken = default)
    {
        //Get Old Slider 
        var slider = await _sliderService.Fill_EditSliderAdminSideDTO_BySliderId(sliderId, cancellationToken);
        if (slider == null) return NotFound();

        return View(slider);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> EditSlider(Edit_Slider_AdminSide_DTO inComeSlider,
                                                IFormFile? sliderImage,
                                                CancellationToken cancellationToken = default)
    {
        try
        {
            var res = await _sliderService.EditSlider_AdminSide(inComeSlider, sliderImage, cancellationToken);
            if (res)
            {
                return RedirectToAction(nameof(ListOfSliders));
            }
        }
        catch (Exception)
        {
            return View();
        }

        return View();
    }

    #endregion

    #region Delete Sldier  

    public async Task<IActionResult> DeleteSlider(int sliderId, CancellationToken cancellation)
    {
        var res = await _sliderService.Delete_Slider_AdminSide(sliderId, cancellation);
        if (res)
        {
            return ApiResponse.SetResponse(ApiResponseStatus.Success, null, "عملیات باموفقیت انجام شده است.");
        }

        return ApiResponse.SetResponse(ApiResponseStatus.Danger, null, "عملیات باشکست مواجه شده است.");
    }

    #endregion
}
