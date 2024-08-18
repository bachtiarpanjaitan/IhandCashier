using IhandCashier.Bepe.Helpers;
using IhandCashier.Bepe.Interfaces;
using IhandCashier.Bepe.Types;
using IhandCashier.Bepe.Services;
using IhandCashier.Pages.Windows;

namespace IhandCashier.Bepe.Injections;

public class Boot : IStartupTask
{
    private static AppSetting _settings;
    public Boot() {}
    
    public void Execute()
    {
        _settings = AppSettingService.Settings;
        if (Application.Current != null)
            Application.Current.UserAppTheme = (_settings.Thema.Selected == "Dark") ? AppTheme.Dark : AppTheme.Light;

        if (_settings.Initial) OnInitialInstall();
        else
        {
            if (Application.Current != null)
            {
                Application.Current.MainPage = new AppShell();
                WindowHelper.SetWindowSize(1280,800);
            }
        }
               
    }
    
    private void OnInitialInstall()
    {
        if (Application.Current != null)
        {
            Application.Current.MainPage = new SetupDatabase();
            WindowHelper.SetWindowSize(600,600);

        }
    }

    private void IsAuthenticated()
    {
        if (Application.Current != null) Application.Current.MainPage = new LoginForm();
    }
}