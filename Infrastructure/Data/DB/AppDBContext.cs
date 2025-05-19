using Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.DB;

public class AppDbContext : DbContext
{
    public DbSet<ProductEntity> Products => Set<ProductEntity>();
    public DbSet<CategoryEntity> Categories => Set<CategoryEntity>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<ProductEntity>()
            .HasOne(p => p.Category1)
            .WithMany()
            .HasForeignKey(p => p.Category1Id)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<ProductEntity>()
            .HasOne(p => p.Category2)
            .WithMany()
            .HasForeignKey(p => p.Category2Id)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<ProductEntity>()
            .HasOne(p => p.Category3)
            .WithMany()
            .HasForeignKey(p => p.Category3Id)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<ProductEntity>()
            .Navigation(p => p.Category1)
            .AutoInclude();

        modelBuilder.Entity<ProductEntity>()
            .Navigation(p => p.Category2)
            .AutoInclude();

        modelBuilder.Entity<ProductEntity>()
            .Navigation(p => p.Category3)
            .AutoInclude();
    }
}
