using System.Xml.Serialization;

namespace IhandCashier.Bepe.Types;

[XmlRoot("ic-application")]
public class AppSetting
{
    [XmlElement("ic-perusahaan")]
    public string Perusahaan { get; set; }

    [XmlElement("ic-thema")]
    public IcThema Thema { get; set; }

    [XmlElement("ic-data")]
    public IcData Data { get; set; }

    [XmlElement("ic-layouts")]
    public IcLayouts Layouts { get; set; }
}

public class IcThema
{
    [XmlElement("ic-selected")]
    public string Selected { get; set; }

    [XmlArray("ic-options")]
    [XmlArrayItem("ic-option")]
    public List<string> Options { get; set; }
}

public class IcData
{
    [XmlElement("ic-data_per_halaman")]
    public int DataPerHalaman { get; set; }
}

public class IcLayouts
{
    [XmlElement("ic-lebar_menu_kiri")]
    public int LebarMenuKiri { get; set; }
}