using IhandCashier.Bepe.Database;
using IhandCashier.Core;

namespace IhandCashier;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureIhandCashierCore()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
        builder.Services.AddAppServices();

        #region Region Injections

        #endregion
        
        #region Region Initialize Component Provider
        Core.Maui.Providers.DatagridProvider.Initialize();
        #endregion
        
        var app = builder.Build();
        ServiceLocator.ServiceProvider = app.Services;
        return app;
	}
}

