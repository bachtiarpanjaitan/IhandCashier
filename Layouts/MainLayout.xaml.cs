using IhandCashier.Bepe.Configs;
using IhandCashier.Bepe.Helpers;
using System.Globalization;

namespace IhandCashier.Layouts;

public partial class MainLayout : ContentPage
{
    private System.Timers.Timer _timer;
    private readonly CultureInfo _cultureInfo = new CultureInfo("id-ID");

    public MainLayout()
	{
		InitializeComponent();
        _ = LoadMenu();
        SetupClock();

    }

    private async Task LoadMenu()
    {
        try
        {
            List<MenuBarItem> menuCreator = await new MenuCreator(AppConfig.PATH_FILE_MENU, this.MainTabbedPage).CreateMenuAsync();
            foreach (var item in menuCreator)
            {
                this.MenuBarItems.Add(item);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"LOAD MENU ERROR: {ex.Message} {ex.Source}");
        }
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
