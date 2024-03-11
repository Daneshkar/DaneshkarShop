using DaneshkarShop.Application.Services.Interface;
using DaneshkarShop.Domain.DTOs.AdminSide.Product;
using DaneshkarShop.Domain.Entitties.Product;
using DaneshkarShop.Domain.IRepositories;

namespace DaneshkarShop.Application.Services.Implementation;

public class ProductCategoryService : IProductCategoryService
{
	#region Ctor

	private readonly IProductCategoryRepository _productCategoryRepository;

    public ProductCategoryService(IProductCategoryRepository productCategoryRepository)
    {
        _productCategoryRepository = productCategoryRepository;
    }

    #endregion

    #region Admin Side 

    public async Task<List<ProductCategory>> FilterProductCategories(CancellationToken cancellationToken)
    {
        return await _productCategoryRepository.FilterProductCategories(cancellationToken);
    }

    public async Task<bool> AddProductCategory(CreateProductCategoryDTO model , 
                                               CancellationToken cancellationToken)
    {
        ProductCategory productCategory = new ProductCategory()
        {
            CategoryTitle = model.CategoryTitle,
            ParentId = model.ParentId,
        };

        await _productCategoryRepository.AddProductCategory(productCategory);
        await _productCategoryRepository.SaveChanges();

        return true;
    }

    public async Task<Domain.Entitties.Product.ProductCategory> GetProductCategoryById(int categoryId , 
                                                                                       CancellationToken cancellation)
    {
        return await _productCategoryRepository.GetProductCategoryById(categoryId , cancellation);
    }

    public async Task<bool> DeleteProductCategory(int categoryId , 
                                                  CancellationToken cancellation)
    {
        //Find Category By Id 
        var category = await GetProductCategoryById(categoryId , cancellation);
        if (category == null) return false;

        //Delete Child Categories
        if (category.ParentId == null)
        {
            var childen = await _productCategoryRepository.Get_ChildernOfParentCategory_ByParentCategoryId(categoryId , cancellation);
            if (childen != null && childen.Any())
            {
                foreach (var child in childen)
                {
                    //Delete Category 
                    _productCategoryRepository.DeleteCategory(child);
                }
            }
        }

        //Delete Category 
        _productCategoryRepository.DeleteCategory(category);
        await _productCategoryRepository.SaveChanges();

        return true;
    }

    #endregion
}
