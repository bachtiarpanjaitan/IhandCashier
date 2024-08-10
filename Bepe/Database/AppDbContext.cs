using Microsoft.EntityFrameworkCore;
using IhandCashier.Bepe.Configs;
using IhandCashier.Bepe.Entities;

public class AppDbContext : DbContext
{
    public DbSet<Product> Product { get; set; }
    public DbSet<BasicUnit> BasicUnit { get; set; }
    public DbSet<Unit> Unit { get; set; }
    public DbSet<User> User { get; set; }


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