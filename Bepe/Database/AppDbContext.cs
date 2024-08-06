using IhandCashier.Bepe.Interfaces;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using IhandCashier.Bepe.Configs;


public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
    {
        optionsBuilder.UseSqlite($"Data Source={DatabaseConfig.DatabasePath()}");
    }   
            
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var entityTypes = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => typeof(IEntity).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

        foreach (var entityType in entityTypes)
        {
            // Menambahkan konfigurasi untuk setiap tipe entitas
            modelBuilder.Entity(entityType);
        }

    }   
}