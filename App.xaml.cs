using IhandCashier.Layouts;
using IhandCashier.Bepe.Database;
using Syncfusion.Licensing;

namespace IhandCashier;

public partial class App : Application
{
    public App()
	{
        InitializeComponent();
        var basapadi = new Basapadi.Config();
        var key = basapadi.SyncfusionKey("BEPE_23");
        SyncfusionLicenseProvider.RegisterLicense(key);
        TableBuilder.Build();
        MainPage = new MainLayout();

    }
}

