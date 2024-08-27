using System.Xml.Serialization;
using IhandCashier.Bepe.Helpers;
using IhandCashier.Bepe.Interfaces;
using IhandCashier.Bepe.Types;

namespace IhandCashier.Bepe.Configs;

public class AppSettingConfig
{
    public static AppSetting LoadInitSettings()
    {
        string xmlsettingpath = AppConfig.RESOURCES_FOLDER + ".Datas.Templates.settings.xml";
        var settings = ResourceHelper.ReadAsStreamReader(xmlsettingpath);
        if (settings == null) return new AppSetting()
        {
            Data =
            {
                DataPerHalaman = AppConfig.DATA_ROW_PER_PAGE
            },
            Layouts =
            {
                LebarMenuKiri = AppConfig.SIDE_MENU_WIDTH
            },
            Perusahaan = AppConfig.COMPANY_NAME,
            Thema =
            {
                Selected = "Light"
            }
        };
        
        XmlSerializer serializer = new XmlSerializer(typeof(AppSetting));
        return (AppSetting)serializer.Deserialize(settings);
    }
    
    public static void SaveToAppSettings(AppSetting settings, string path)
    {
        
        var serializer = new XmlSerializer(typeof(AppSetting));
        using (var writer = new StreamWriter(path))
        {
            serializer.Serialize(writer, settings);
        }
    }
    
    public static AppSetting LoadSettings()
    {
        string xmlsettingpath = Path.Combine(FileSystem.AppDataDirectory, AppConfig.DEFAULT_PATH,"Resources", "settings.xml");
        var settings = ResourceHelper.ReadAsStreamReaderFromPath(xmlsettingpath);
        if (settings == null) return LoadInitSettings();
        XmlSerializer serializer = new XmlSerializer(typeof(AppSetting));
        return (AppSetting)serializer.Deserialize(settings);
    }

    public static string CreateAppPath(string folder)
    {
        var path = Path.Combine(FileSystem.AppDataDirectory, AppConfig.DEFAULT_PATH, folder);
        try
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                Console.WriteLine("Folder created at: " + path);
            }

            return path;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error creating folder: " + ex.Message);
            return null;
        }
    }
    
    
}