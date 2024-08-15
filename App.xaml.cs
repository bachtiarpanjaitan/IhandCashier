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
        SyncfusionLicenseProvider.RegisterLicense(basapadi.SyncfusionKey("BEPE_23"));
        TableBuilder.Build();
        MainPage = new AppShell();
    }
}

