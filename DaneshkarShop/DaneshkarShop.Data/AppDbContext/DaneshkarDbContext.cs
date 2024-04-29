using DaneshkarShop.Domain.Entitties.ContactUs;
using DaneshkarShop.Domain.Entitties.Product;
using DaneshkarShop.Domain.Entitties.Role;
using DaneshkarShop.Domain.Entitties.Slider;
using DaneshkarShop.Domain.Entitties.User;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DaneshkarShop.Data.AppDbContext;

public class DaneshkarDbContext : DbContext
{
    #region Ctor

    public DaneshkarDbContext(DbContextOptions<DaneshkarDbContext> options) : base(options)
    {
        
    }

    #endregion

    #region Db Sets

    #region User

    public DbSet<User> Users { get; set; }

    #endregion

    #region Role 

    public DbSet<Role> Roles { get; set; }

    public DbSet<UserSelectedRole> UserSelectedRoles { get; set; }

    #endregion

    #region Contact Us

    public DbSet<ContactUs> ContactUs { get; set; }

    #endregion

    #region Product 

    public DbSet<ProductCategory> ProductCategories { get; set; }

    #endregion

    #region Slider

    public DbSet<Slider> Sliders { get; set; }

    #endregion

    #endregion

    #region Model Creating

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var cascadeFKs = modelBuilder.Model.GetEntityTypes()
            .SelectMany(t => t.GetForeignKeys())
            .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

        foreach (var fk in cascadeFKs)
            fk.DeleteBehavior = DeleteBehavior.Restrict;


        base.OnModelCreating(modelBuilder);
    }

    #endregion
}
