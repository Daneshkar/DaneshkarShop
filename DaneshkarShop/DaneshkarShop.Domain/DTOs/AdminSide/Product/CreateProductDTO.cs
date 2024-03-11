namespace DaneshkarShop.Domain.DTOs.AdminSide.Product;

public class CreateProductCategoryDTO
{
    #region properties

    public string CategoryTitle { get; set; }

    public int? ParentId { get; set; }

    #endregion
}
