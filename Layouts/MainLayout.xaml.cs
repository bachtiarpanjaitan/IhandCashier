using System.Diagnostics;
using System.Globalization;
using System.Runtime;
using IhandCashier.Bepe.Components;
using IhandCashier.Bepe.Configs;
using IhandCashier.Bepe.Helpers;
using IhandCashier.Bepe.Statics;
using IhandCashier.Bepe.Types;
using IhandCashier.Core.Maui.Providers;
using IhandCashier.Pages;
using Syncfusion.Maui.DataGrid;

namespace IhandCashier.Layouts;

public partial class MainLayout
{
    public Dictionary<string, MenuFlyoutItem> ListMenu = new ();
        
    private System.Timers.Timer _timer;
    private readonly CultureInfo _cultureInfo = new("id-ID");
    private UserSession userSession = new SessionManager().GetSession();
    private  IList<MenuBarItem> menuBar;
    
    public MainLayout()
    {
        InitializeComponent();
        
        SetupClock();
        MenuBarItems.Clear();
        ListMenu = new MenuCreator().CreateMenu(MenuBarItems);
        
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
        Container.Content = new PageDataBarang();
        
        if (Application.Current.MainPage is AppShell shell)
        {
            foreach (var value in ListMenu.Values)
            {
                value.Clicked += (sender, args) =>
                {
                    if (sender is MenuFlyoutItem menuBarItem)
                    {
                        try
                        {
                            var data = menuBarItem?.CommandParameter as string;
                            var type = Type.GetType(AppConfig.PAGES_NAMESPACE + "." + data);
                            if (type == null) return;
                            var instance = Activator.CreateInstance(type);
                            Container.ChangeContent((ContentView)instance);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error Click : {ex.Message}");
                        }
                    }
                };
            }
        }

    }

    [Obsolete]
    private void SetupClock()
    {
        _timer = new System.Timers.Timer(1000);
        _timer.Elapsed += OnTimerElapsed;
        _timer.AutoReset = true;
        _timer.Enabled = true;
        
        LUser.Text = $" {userSession.Username} ";
        Copyright.Text = $"\u00a9 {DateTime.Now.Year} HMP Basapadi";
        Console.SetOut(new LabelWriter(LogLabel));
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
            long memoryUsage = GC.GetTotalMemory(false);
            var memoryGc = Math.Round(memoryUsage / 1024.0 / 1024.0,2);
            
            Process currentProcess = Process.GetCurrentProcess();
            long privateMemorySize = currentProcess.PrivateMemorySize64;
            var memoryCp = Math.Round(privateMemorySize / 1024.0 / 1024.0, 2);
            
            LMemory.Text = $"GC: {memoryGc} MB, CP: {memoryCp} MB";
        } );
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        _timer?.Stop();
        _timer?.Dispose();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
    }
}
