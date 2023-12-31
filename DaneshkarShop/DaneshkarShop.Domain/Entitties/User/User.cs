﻿using DaneshkarShop.Domain.Entitties.Role;
using System.Collections.ObjectModel;

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

    public bool SuperAdmin { get; set; }

    public string? UserAvatar { get; set; }

    #endregion

    #region Navigation properties

    public ICollection<UserSelectedRole> UserSelectedRoles { get; set; }

    #endregion
}
