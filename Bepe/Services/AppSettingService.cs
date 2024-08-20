using IhandCashier.Bepe.Configs;
using IhandCashier.Bepe.Types;

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
                _settings = AppSettingConfig.LoadInitSettings();
            }
            return _settings;
        }
    }
}