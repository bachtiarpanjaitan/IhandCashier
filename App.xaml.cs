using IhandCashier.Layouts;
using IhandCashier.Bepe.Database;

namespace IhandCashier;

public partial class App : Application
{
    public App()
	{
        //Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(Basapadi.Config.SyncfusionKey("BEPE"));
        InitializeComponent();

        TableBuilder.Build();

        MainPage = new MainLayout();

    }
}

