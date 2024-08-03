using IhandCashier.Layouts;

namespace IhandCashier;

public partial class App : Application
{
    [Obsolete]
    public App()
	{
        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzQxNTM1MUAzMjM2MmUzMDJlMzBRTUc0OFIxOUVCNFgvcHk1aDFqY2V6dGtqSzJPYmRhTitpejY3ZEsySERBPQ==");
        InitializeComponent();

		MainPage = new MainLayout();

    }
}

