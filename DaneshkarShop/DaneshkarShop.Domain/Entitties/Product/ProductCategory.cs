namespace DaneshkarShop.Domain.Entitties.Product;

public class ProductCategory
{
    #region properties

    public int Id { get; set; }

    public string CategoryTitle { get; set; }

    public int? ParentId { get; set; }

    #endregion
}
