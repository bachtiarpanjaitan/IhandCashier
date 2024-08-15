using IhandCashier.Bepe.Entities;
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
        services.AddScoped<CustomerService>();
        services.AddScoped<ProductPriceService>();
        services.AddScoped<ProductReceiptDetailService>();
        services.AddScoped<ProductReceiptService>();
        services.AddScoped<ProductStockService>();
        services.AddScoped<SupplierService>();
    }
}