namespace DaneshkarShop.Domain.DTOs.AdminSide.Slider;

public record Edit_Slider_AdminSide_DTO 
{
    #region properties

    public int Id { get; set; }

    public string SliderImage { get; set; }

    public string Title { get; set; }

    #endregion
}
