using DaneshkarShop.Domain.Entitties.User;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaneshkarShop.Domain.Entitties.Role;

public class UserSelectedRole
{
    #region properties

    public int Id { get; set; }

    public int UserId { get; set; }

    public int RoleId { get; set; }

    #endregion

    #region Relations

    public Role Role { get; set; }

    public User.User User { get; set; }

    #endregion
}
