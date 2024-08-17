using IhandCashier.Bepe.Configs;
using IhandCashier.Bepe.Models;

namespace IhandCashier.Bepe.Services;

public class AppSettingService
{
    private static AppSetting _settings;

    public static AppSetting Settings
    {
        get
        {
            if (_settings == null)
            {
                _settings = AppSettingConfig.LoadSettings();
            }
            return _settings;
        }
    }
}