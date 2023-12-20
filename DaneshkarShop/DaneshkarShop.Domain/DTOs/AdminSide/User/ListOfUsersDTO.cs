namespace DaneshkarShop.Domain.DTOs.AdminSide.User;

public class ListOfUsersDTO
{
    #region properties
    
    public int UserId { get; set; } 

    public string Username { get; set; }

    public string Mobile { get; set; }

    public DateTime CreateDate { get; set; }

    public string? UserAvatar { get; set; }

    #endregion
}
