using System;
using IhandCashier.Bepe.Constants;
using IhandCashier.Bepe.Types;

namespace IhandCashier.Bepe.Configs
{
	public class DatabaseConfig
	{
        public const string DatabaseFilename = "ihandcashier.db3";
        private static AppSetting _settings;
        public static string DatabasePath()
        {
            _settings = AppSettingConfig.LoadSettings();
            if (_settings.Database.DbType == AppEnumeration.GetDbTypes[DbTypes.SqLite])
            {
                return _settings.Database.SqLite.DbSource;
            }

            //Default
            var dir = Path.Combine(FileSystem.AppDataDirectory, AppConfig.DEFAULT_PATH,"Data");
            if(!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            return Path.Combine(dir, DatabaseFilename);
        }
            
            
    }
}

