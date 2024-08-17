using System.Xml.Serialization;
using IhandCashier.Bepe.Helpers;
using IhandCashier.Bepe.Types;

namespace IhandCashier.Bepe.Configs;

public class AppSettingConfig
{
    public static AppSetting LoadSettings()
    {
        var resource = "IhandCashier.Resources.Datas";
        var settings = ResourceHelper.ReadAsStreamReader(resource + ".Templates.settings.xml");
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
}