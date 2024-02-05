using System.ComponentModel.DataAnnotations;

namespace DaneshkarShop.Domain.Entitties.ContactUs;

public class ContactUs
{
    #region properties

    public int Id { get; set; }

    [MaxLength(50)]
    public string Username { get; set; }

    [MaxLength(50)]
    public string Mobile { get; set; }

    public string Message { get; set; }

    #endregion
}
