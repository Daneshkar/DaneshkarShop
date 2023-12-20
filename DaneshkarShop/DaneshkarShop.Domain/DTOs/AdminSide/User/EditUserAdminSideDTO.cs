using Microsoft.AspNetCore.Http;

namespace DaneshkarShop.Domain.DTOs.AdminSide.User;

public class EditUserAdminSideDTO
{
    #region properties

    public int UserId { get; set; }

    public string Username { get; set; }

    public string Mobile { get; set; }

    //public bool SuperAdmin { get; set; }

    public string? UserOriginalAvatar { get; set; }

    public IFormFile UserAvatar { get; set; }

    //public List<int> UserSelectedRoleId { get; set; }

    #endregion
}
