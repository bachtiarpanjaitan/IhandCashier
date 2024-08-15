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
        #if WINDOWS
                Microsoft.UI.Xaml.Window window = (Microsoft.UI.Xaml.Window)Window;
                var displayInformation = Windows.Graphics.Display.DisplayInformation.GetForCurrentView();
                var screenWidth = displayInformation.ScreenWidthInRawPixels;
                var screenHeight = displayInformation.ScreenHeightInRawPixels;

                window.Width = screenWidth;
                window.Height = screenHeight;
                window.CenterOnScreen();
        #endif

    }
}

