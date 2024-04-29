using DaneshkarShop.Domain.Entitties.Slider;

namespace DaneshkarShop.Domain.IRepositories;

public interface ISliderRepository
{
    #region General Methods

    Task SaveChanges();

    Task<Slider?> Get_Slider_ById(int sliderId);

    void Update_Slider(Slider slider);

    void Delete_Slider(Slider slider);

    #endregion

    #region Admin Side 

    Task Add_Slider(Slider slider);

    #endregion
}
