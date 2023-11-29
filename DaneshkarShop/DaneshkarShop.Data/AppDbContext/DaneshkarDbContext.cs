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
