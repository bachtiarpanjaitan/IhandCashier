using IhandCashier.Bepe.Database;
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

        #region Initialize Component Provider
        DatagridProvider.Initialize();
        #endregion
        
        var app = builder.Build();
        ServiceLocator.ServiceProvider = app.Services;
        return app;
	}
}

