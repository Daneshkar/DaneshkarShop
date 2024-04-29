using DaneshkarShop.Data.AppDbContext;
using DaneshkarShop.Domain.Entitties.Slider;
using DaneshkarShop.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace DaneshkarShop.Data.Repositories;

public class SliderRepository : ISliderRepository
{
    #region Ctor

    private readonly DaneshkarDbContext _context;

    public SliderRepository(DaneshkarDbContext context)
    {
        _context = context;
    }

    #endregion

    #region General Methods

    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<Slider?> Get_Slider_ById(int sliderId)
    {
        return await _context.Sliders.FirstOrDefaultAsync(p => p.Id == sliderId);
    }

    public void Update_Slider(Slider slider)
    {
        _context.Sliders.Update(slider);
    }

    public void Delete_Slider(Slider slider)
    {
        _context.Sliders.Remove(slider);
    }

    #endregion

    #region Admin Side 

    public async Task Add_Slider(Slider slider)
    {
        await _context.Sliders.AddAsync(slider);
    }

    #endregion
}
