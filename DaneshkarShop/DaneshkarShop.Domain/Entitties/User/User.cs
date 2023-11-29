namespace DaneshkarShop.Domain.Entitties.User;

public class User
{
    #region properties

    public int UserId { get; set; }

    public string Username { get; set; }

    public string Mobile { get; set; }

    public string Password { get; set; }

    public DateTime CreateDate { get; set; }

    public bool IsDelete { get; set; }

    #endregion

    #region Navigation properties



    #endregion
}
