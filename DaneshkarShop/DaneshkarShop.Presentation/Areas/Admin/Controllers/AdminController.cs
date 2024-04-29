using DaneshkarShop.Application.Services.Interface;
using DaneshkarShop.Domain.DTOs.AdminSide.Slider;
using DaneshkarShop.Domain.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace DaneshkarShop.Presentation.Areas.Admin.Controllers;

public class AdminController : AdminBaseController
{
    #region List Of Sliders

    private readonly ISliderService _sliderService;

    public AdminController(ISliderService sliderService)
    {
        _sliderService = sliderService;
    }

    #endregion

    #region Create Slider

    [HttpGet]
    public IActionResult CreateSlider()
    {
        return View();
    }

    [HttpPost , ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateSlider(Create_Clider_AdminSide_DTO slider,
                                                  CancellationToken cancellationToken = default)
    {
        if (ModelState.IsValid)
        {
            //Add Slider to the data base 
            var result = await _sliderService.CreateSlider(slider , cancellationToken) ;
        }

        return View(slider);
    }

    #endregion
}
