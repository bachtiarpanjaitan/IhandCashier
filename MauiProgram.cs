using IhandCashier.Bepe.Components;
using IhandCashier.Bepe.Configs;
using IhandCashier.Bepe.Entities;
using IhandCashier.Bepe.Interfaces;
using IhandCashier.Bepe.Providers;
using IhandCashier.Bepe.Services;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Maui.Core.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace IhandCashier;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .ConfigureSyncfusionCore()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
        builder.Services.AddDbContext<AppDbContext>(options =>
		{
            string cs = DatabaseConfig.DatabasePath();
            options.UseSqlite($"Data Source={cs}");
        });
        
        builder.Services.AddScoped<ProductService>();
        builder.Services.AddScoped<UserService>();
        builder.Services.AddScoped<UnitService>();
        builder.Services.AddScoped<BasicUnitService>();
        
        #region Initialize Component Provider
        DatagridProvider.Initialize();
        #endregion
       

        var app = builder.Build();
        ServiceLocator.ServiceProvider = app.Services;
        return app;
	}
}

