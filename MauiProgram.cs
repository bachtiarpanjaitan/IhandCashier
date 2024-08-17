using IhandCashier.Bepe.Database;
using IhandCashier.Bepe.Injections;
using IhandCashier.Bepe.Interfaces;
using IhandCashier.Bepe.Providers;
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
        builder.Services.AddAppServices();

        #region Region Injections

        #endregion
        
        #region Region Initialize Component Provider
        DatagridProvider.Initialize();
        #endregion
        
        var app = builder.Build();
        ServiceLocator.ServiceProvider = app.Services;
        return app;
	}
}

