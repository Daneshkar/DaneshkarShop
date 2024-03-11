using DaneshkarShop.Domain.DTOs.AdminSide.Product;
using DaneshkarShop.Domain.Entitties.Product;
namespace DaneshkarShop.Application.Services.Interface;

public interface IProductCategoryService
{
    #region Admin Side 

    Task<List<ProductCategory>> FilterProductCategories(CancellationToken cancellationToken);

    Task<bool> AddProductCategory(CreateProductCategoryDTO model,
                                               CancellationToken cancellationToken);

    Task<bool> DeleteProductCategory(int categoryId,
                                     CancellationToken cancellation);

    #endregion
}
