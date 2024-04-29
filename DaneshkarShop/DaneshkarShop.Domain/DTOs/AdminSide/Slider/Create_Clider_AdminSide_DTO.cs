using Microsoft.AspNetCore.Http;

namespace DaneshkarShop.Domain.DTOs.AdminSide.Slider;

public record Create_Clider_AdminSide_DTO
{
    #region properties

    public string Title { get; set; }

    public IFormFile SliderImage { get; set; }

    #endregion
}
