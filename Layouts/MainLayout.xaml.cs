using System.Globalization;
using IhandCashier.Bepe.Components;
using IhandCashier.Bepe.Configs;
using IhandCashier.Bepe.Helpers;
using IhandCashier.Bepe.Statics;
using IhandCashier.Bepe.Types;
using IhandCashier.Pages;

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
        
        Container.Content = new PageHome();
        
    }

    private void LoadMenu()
    {
        if (DeviceInfo.Platform == DevicePlatform.MacCatalyst ||DeviceInfo.Platform == DevicePlatform.WinUI)
        {
            if (Application.Current != null)
            {
                MenuBarItems.Clear();
                var menuCreator = new MenuCreator(AppConfig.PATH_FILE_MENU, Container).CreateMenuAsync().Result;
                foreach (var item in menuCreator)
                {
                    MenuBarItems.Add(item);
                }
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
