using IhandCashier.Bepe.Configs;
using IhandCashier.Bepe.Providers;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Maui.Core.Hosting;

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

        #region Initialize Component Provider
        DatagridProvider.Initialize();
        #endregion
       

        var app = builder.Build();
        return app;
	}
}

