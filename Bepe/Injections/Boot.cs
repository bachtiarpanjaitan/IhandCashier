using IhandCashier.Bepe.Configs;
using IhandCashier.Bepe.Database;
using IhandCashier.Bepe.Helpers;
using IhandCashier.Bepe.Interfaces;
using IhandCashier.Bepe.Types;
using IhandCashier.Bepe.Services;
using IhandCashier.Bepe.Statics;
using IhandCashier.Pages.Windows;

namespace IhandCashier.Bepe.Injections;

public class Boot : IStartupTask
{
    private static AppSetting _settings;

    public Boot(){}

    public void Execute()
    {
        if(AppConfig.CLEAR_SESSION_WHEN_START) new SessionManager().ResetSession();
        
        _settings = AppSettingConfig.LoadSettings();
        if (_settings == null) _settings = AppSettingService.Settings;

        if (Application.Current != null)
            Application.Current.UserAppTheme = (_settings.Thema.Selected == "Dark") ? AppTheme.Dark : AppTheme.Light;

        if (_settings.Initial)
        {
            OnInitialInstall();
        }
        else
        {
            if (Application.Current != null)
            {
                if (IsAuthenticated())
                {
                    Application.Current.MainPage = new AppShell()
                    {
                        WidthRequest = AppConfig.MAIN_WIDTH,
                        HeightRequest = AppConfig.MAIN_HEIGHT,
                    };
                }
                else
                {
                    new SessionManager().ResetSession();
                    Application.Current.MainPage = new LoginForm();
                }
                
            }
        }
               
    }
    
    private void OnInitialInstall()
    {
        if (Application.Current != null)
        {
            Application.Current.MainPage = ServiceLocator.ServiceProvider.GetRequiredService<SetupDatabase>();
        }
    }

    private bool IsAuthenticated()
    {
        return new SessionManager().IsLogin();
    }
}