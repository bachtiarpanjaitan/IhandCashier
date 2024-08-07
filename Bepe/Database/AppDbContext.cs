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
        string cs = DatabaseConfig.DatabasePath();
        optionsBuilder.UseSqlite($"Data Source={cs}");
    }   
            
}