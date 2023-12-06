using System.ComponentModel.DataAnnotations;

namespace DaneshkarShop.Domain.Entitties.Role;

public class Role
{
    #region properties

    public int Id { get; set; }

    [MaxLength(100)]
    [Required]
    public string RoleTitle { get; set; }

    [MaxLength(100)]
    [Required]
    public string RoleUniqueName { get; set; }

    public DateTime CreateDate { get; set; }

    public bool IsDelete { get; set; }

    #endregion

    #region relations

    public ICollection<UserSelectedRole> UserSelectedRoles { get; set; }

    #endregion
}
