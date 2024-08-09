using IhandCashier.Layouts;
using IhandCashier.Bepe.Database;
using Syncfusion.Licensing;

namespace IhandCashier;

public partial class App : Application
{
    public App()
	{
        InitializeComponent();
        SyncfusionLicenseProvider.RegisterLicense("MzQxNTM1MUAzMjM2MmUzMDJlMzBRTUc0OFIxOUVCNFgvcHk1aDFqY2V6dGtqSzJPYmRhTitpejY3ZEsySERBPQ==");
        TableBuilder.Build();
        MainPage = new MainLayout();

    }
}

