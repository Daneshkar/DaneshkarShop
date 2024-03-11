using DaneshkarShop.Domain.Entitties.Product;

namespace DaneshkarShop.Domain.IRepositories;

public interface IProductCategoryRepository
{
    #region Admin Side 

    void DeleteCategory(ProductCategory category);

    Task<Domain.Entitties.Product.ProductCategory> GetProductCategoryById(int categoryId,
                                                                          CancellationToken cancellation);

    Task<List<ProductCategory>> FilterProductCategories(CancellationToken cancellationToken);

    Task AddProductCategory(ProductCategory category);

    Task SaveChanges();

    Task<List<ProductCategory>> Get_ChildernOfParentCategory_ByParentCategoryId(int categoryId,
                                                                                CancellationToken cancellationToken);

    #endregion
}
