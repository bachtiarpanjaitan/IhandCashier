using IhandCashier.Bepe.Interfaces;
using IhandCashier.Bepe.Models;
using IhandCashier.Bepe.Services;

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
        
    }
}