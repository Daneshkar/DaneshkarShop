using DaneshkarShop.Domain.DTOs.AdminSide.Slider;
using Microsoft.AspNetCore.Http;

namespace DaneshkarShop.Application.Services.Interface;

public interface ISliderService
{
    #region Admin Side 

    Task<bool> CreateSlider(Create_Clider_AdminSide_DTO model, CancellationToken cancellationToken);

    Task<Edit_Slider_AdminSide_DTO?> Fill_EditSliderAdminSideDTO_BySliderId(int sliderId,
                                                                            CancellationToken cancellationToken);

    Task<bool> EditSlider_AdminSide(Edit_Slider_AdminSide_DTO inComeSlider,
                                    IFormFile? sliderImage,
                                    CancellationToken cancellationToken);

    Task<bool> Delete_Slider_AdminSide(int sliderId,
                                       CancellationToken cancellationToken);

    #endregion
}
