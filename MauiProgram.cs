using CommunityToolkit.Maui;
using IhandCashier.Bepe.Configs;
using IhandCashier.Bepe.Database;
using IhandCashier.Bepe.Interfaces;
using IhandCashier.Core;
using IhandCashier.Pages.Windows;

namespace IhandCashier;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureIhandCashierCore()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
        builder.Services.AddAppServices();

        #region Region Service
			builder.Services.AddTransient<SetupDatabase>();
        #endregion
        
        #region Region Initialize Component Provider
        Core.Maui.Providers.DatagridProvider.Initialize();
        #endregion
        
		#if WINDOWS
			builder.Services.AddTransient<IFolderPicker, FolderPicker>();
		#elif MACCATALYST
		    builder.Services.AddTransient<IFolderPicker, FolderPicker>();
		#endif
        
        var app = builder.Build();
        ServiceLocator.ServiceProvider = app.Services;
        return app;
	}
}

