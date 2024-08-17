using IhandCashier.Bepe.Injections;
using IhandCashier.Bepe.Interfaces;
using Syncfusion.Licensing;

namespace IhandCashier;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        var basapadi = new Basapadi.Config();
        SyncfusionLicenseProvider.RegisterLicense(basapadi.SyncfusionKey("BEPE_23"));
        
        new Boot().Execute();
        MainPage = new AppShell();
    }
}

