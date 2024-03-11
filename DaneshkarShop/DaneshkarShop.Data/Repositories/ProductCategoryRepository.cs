using DaneshkarShop.Data.AppDbContext;
using DaneshkarShop.Domain.Entitties.Product;
using DaneshkarShop.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
namespace DaneshkarShop.Data.Repositories;

public class ProductCategoryRepository : IProductCategoryRepository
{
	#region Ctor

	private readonly DaneshkarDbContext _context;

    public ProductCategoryRepository(DaneshkarDbContext context)
    {
            _context = context;
    }

    #endregion

    #region Admin Side 

    public async Task<Domain.Entitties.Product.ProductCategory> GetProductCategoryById(int categoryId,
                                                                                      CancellationToken cancellation)
    {
        return await _context.ProductCategories
                             .FirstOrDefaultAsync(p => p.Id == categoryId);
    }

    public async Task<List<ProductCategory>> FilterProductCategories(CancellationToken cancellationToken)
    {
        return await _context.ProductCategories
                             .AsNoTracking()
                             .ToListAsync();
    }

    public async Task AddProductCategory(ProductCategory category)
    {
        await _context.ProductCategories.AddAsync(category);
    }

    public void DeleteCategory(ProductCategory category)
    {
        _context.ProductCategories.Remove(category);
    }

    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }


    public async Task<List<ProductCategory>> Get_ChildernOfParentCategory_ByParentCategoryId(int categoryId , 
                                                                                             CancellationToken cancellationToken)
    {
        return await _context.ProductCategories
                             .Where(p => p.ParentId == categoryId)
                             .ToListAsync();
    }

    #endregion
}
