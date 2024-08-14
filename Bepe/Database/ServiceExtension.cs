using IhandCashier.Bepe.Services;

namespace IhandCashier.Bepe.Database;

public static class ServiceExtension
{
    public static void AddAppServices(this IServiceCollection services)
    {
        services.AddScoped<AppDbContext>();
        
        //==== Tambahkan service disini =====
        services.AddScoped<ProductService>();
        services.AddScoped<UserService>();
        services.AddScoped<UnitService>();
        services.AddScoped<BasicUnitService>();
    }
}