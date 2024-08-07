using IhandCashier.Layouts;
using IhandCashier.Bepe.Database;
using IhandCashier.Bepe.Configs;

namespace IhandCashier;

public partial class App : Application
{
    public App()
	{
        //Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("");

        InitializeComponent();
        TableBuilder.Build();
        MainPage = new MainLayout();

    }
}

