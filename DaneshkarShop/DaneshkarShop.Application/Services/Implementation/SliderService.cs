using DaneshkarShop.Application.Services.Interface;
using DaneshkarShop.Application.Utilities;
using DaneshkarShop.Domain.DTOs.AdminSide.Slider;
using DaneshkarShop.Domain.DTOs.AdminSide.User;
using DaneshkarShop.Domain.Entitties.Role;
using DaneshkarShop.Domain.Entitties.Slider;
using DaneshkarShop.Domain.IRepositories;
using Microsoft.AspNetCore.Http;
using System.Reflection;
using System.Xml.Xsl;

namespace DaneshkarShop.Application.Services.Implementation;

public class SliderService : ISliderService
{
	#region Ctor

	private readonly ISliderRepository _sliderRepository;

    public SliderService(ISliderRepository sliderRepository)
    {
        _sliderRepository = sliderRepository;
    }

    #endregion

    #region Admin Side 

    public async Task<bool> CreateSlider(Create_Clider_AdminSide_DTO model , CancellationToken cancellationToken)
    {
        #region Fill Slider Class

        Slider slider = new Slider()
        {
            Title = model.Title,
            EndDate = DateTime.Now,
            StartDate = DateTime.Now,
            IsActive = true
        };

        #endregion

        #region Slider Image 

        //Save New Image
        slider.SliderImage = NameGenerator.GenerateUniqCode() + Path.GetExtension(model.SliderImage.FileName);

        string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Slider", slider.SliderImage);
        using (var stream = new FileStream(imagePath, FileMode.Create))
        {
            model.SliderImage.CopyTo(stream);
        }

        #endregion

        await _sliderRepository.Add_Slider(slider) ;
        await _sliderRepository.SaveChanges();

        return true;
    }

    public async Task<Edit_Slider_AdminSide_DTO?> Fill_EditSliderAdminSideDTO_BySliderId(int sliderId , 
                                                                                        CancellationToken cancellationToken)
    {
        //Get Slider By Id 
        var slider = await _sliderRepository.Get_Slider_ById(sliderId);
        if (slider == null) return null;

        return new Edit_Slider_AdminSide_DTO()
        {
            Id = sliderId,
            SliderImage = slider.SliderImage,
            Title = slider.Title
        };
    }

    public async Task<bool> EditSlider_AdminSide(Edit_Slider_AdminSide_DTO inComeSlider , 
                                                 IFormFile? sliderImage , 
                                                 CancellationToken cancellationToken)
    {
        //Get Slider By Id 
        var oldSlider = await _sliderRepository.Get_Slider_ById(inComeSlider.Id);
        if (oldSlider == null) return false;

        oldSlider.Title = inComeSlider.Title;

        if (sliderImage != null)
        {
            //Save New Image
            oldSlider.SliderImage = NameGenerator.GenerateUniqCode() + Path.GetExtension(sliderImage.FileName);

            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Slider", oldSlider.SliderImage);
            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                sliderImage.CopyTo(stream);
            }
        }

        _sliderRepository.Update_Slider(oldSlider);
        await _sliderRepository.SaveChanges();

        return true;
    }

    public async Task<bool> Delete_Slider_AdminSide(int sliderId , 
                                                    CancellationToken cancellationToken)
    {
        //Get Slider By Id 
        var oldSlider = await _sliderRepository.Get_Slider_ById(sliderId);
        if (oldSlider == null) return false;

        _sliderRepository.Delete_Slider(oldSlider);
        await _sliderRepository.SaveChanges();

        return true;
    }

    #endregion
}
