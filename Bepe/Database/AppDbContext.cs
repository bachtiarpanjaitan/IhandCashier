using IhandCashier.Bepe.Configs;
using IhandCashier.Bepe.Entities;
using Microsoft.EntityFrameworkCore;

namespace IhandCashier.Bepe.Database;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<BasicUnit> BasicUnits { get; set; }
    public DbSet<Unit> Units { get; set; }
    public DbSet<User> Users { get; set; }


    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
    {
        string cs = DatabaseConfig.DatabasePath();
        optionsBuilder.UseSqlite($"Data Source={cs}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().ToTable("products");
        modelBuilder.Entity<User>().ToTable("users");
        modelBuilder.Entity<Unit>().ToTable("units");
        modelBuilder.Entity<BasicUnit>().ToTable("basic_units");

        base.OnModelCreating(modelBuilder);
    }


}