using IhandCashier.Bepe.Configs;
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

        var app = builder.Build();
        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            dbContext.Database.Migrate(); // Terapkan migrasi
                                          // Atau, jika menggunakan seed data:
                                          // SeedData.Initialize(dbContext);
        }
        return app;
	}
}

