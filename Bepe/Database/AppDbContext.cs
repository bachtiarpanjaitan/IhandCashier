using Microsoft.EntityFrameworkCore;
using IhandCashier.Bepe.Configs;
using IhandCashier.Bepe.Entities;

public class AppDbContext : DbContext
{
    public DbSet<Product> Product { get; set; }


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
        modelBuilder.Entity<Product>()
        .ToTable("products");

        base.OnModelCreating(modelBuilder);
    }


}