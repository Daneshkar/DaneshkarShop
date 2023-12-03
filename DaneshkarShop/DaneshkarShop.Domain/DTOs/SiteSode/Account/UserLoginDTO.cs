using System.ComponentModel.DataAnnotations;

namespace DaneshkarShop.Domain.DTOs.SiteSode.Account;

public class UserLoginDTO
{
    #region properties

    public string Mobile { get; set; }

    public string Password { get; set; }

    #endregion
}
