using System.Globalization;
using IhandCashier.Bepe.Components;
using IhandCashier.Bepe.Configs;
using IhandCashier.Bepe.Helpers;
using IhandCashier.Bepe.Statics;
using IhandCashier.Bepe.Types;
using IhandCashier.Core.Maui.Providers;
using IhandCashier.Pages;
using Syncfusion.Maui.DataGrid;

namespace IhandCashier.Layouts;

public partial class MainLayout : ContentPage
{
    private System.Timers.Timer _timer;
    private readonly CultureInfo _cultureInfo = new("id-ID");
    private UserSession userSession = new SessionManager().GetSession();
    public MainLayout()
    {
        InitializeComponent();
        LoadMenu();
        SetupClock();
        
        Shell.SetNavBarIsVisible(this, DeviceInfo.Platform == DevicePlatform.WinUI);
        DatagridProvider.DataGrid.RowHeight = 35;
        DatagridProvider.DataGrid.DefaultStyle = Helper.SetDataGridStyle();
        DatagridProvider.DataGrid.SelectionMode = DataGridSelectionMode.SingleDeselect;
        DatagridProvider.PrevButton.ImageSource = new FontImageSource()
        {
            Glyph = "\ueaa7", 
            FontFamily = "MaterialIcons",
            Size = 20,
            Color = Colors.DarkOrange
        };
        DatagridProvider.NextButton.ImageSource = new FontImageSource()
        {
            Glyph = "\ueaaa", //
            FontFamily = "MaterialIcons",
            Size = 20,
            Color = Colors.DarkOrange,
        };
        DatagridProvider.PrevButton.ContentLayout =
            new Button.ButtonContentLayout(Button.ButtonContentLayout.ImagePosition.Left, 10);
        DatagridProvider.NextButton.ContentLayout =
            new Button.ButtonContentLayout(Button.ButtonContentLayout.ImagePosition.Right, 10);
        Container.Content = new PageHome();
        
    }

    private void LoadMenu()
    {
        if (DeviceInfo.Platform == DevicePlatform.MacCatalyst ||DeviceInfo.Platform == DevicePlatform.WinUI)
        {
            if (Application.Current != null)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    MenuBarItems.Clear();
                    var menuCreator = new MenuCreator(AppConfig.PATH_FILE_MENU, Container).CreateMenuAsync().Result;
                    foreach (var item in menuCreator)
                    {
                        MenuBarItems.Add(item);
                    }
                });
            }
        }
        
        LUser.Text = $" {userSession.Username} ";
        Copyright.Text = $"\u00a9 {DateTime.Now.Year} HMP Basapadi";
        Console.SetOut(new LabelWriter(LogLabel));
    }

    [Obsolete]
    private void SetupClock()
    {
        _timer = new System.Timers.Timer(1000);
        _timer.Elapsed += OnTimerElapsed;
        _timer.AutoReset = true;
        _timer.Enabled = true;
    }

    [Obsolete]
    private void OnTimerElapsed(object sender, EventArgs e)
    {
        Device.BeginInvokeOnMainThread(() =>
        {
            var dayOfWeek = DateTime.Now.ToString("dddd", _cultureInfo);
            var date = DateTime.Now.ToString("dd MMMM yyyy", _cultureInfo);
            var time = DateTime.Now.ToString("HH:mm:ss", _cultureInfo);
            LJamAplikasi.Text = $"{dayOfWeek}, {date}, {time}";
        });
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        _timer?.Stop();
        _timer?.Dispose();
    }

}
