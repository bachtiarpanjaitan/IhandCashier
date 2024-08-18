using System.Xml.Serialization;

namespace IhandCashier.Bepe.Types;

[XmlRoot("ic-application")]
public class AppSetting
{
    [XmlElement("ic-perusahaan")]
    public string Perusahaan { get; set; }
    
    [XmlElement("ic-initial")]
    public bool Initial { get; set; }
    
    [XmlElement("ic-database")]
    public IcDatabase Database { get; set; }

    [XmlElement("ic-thema")]
    public IcThema Thema { get; set; }

    [XmlElement("ic-data")]
    public IcData Data { get; set; }

    [XmlElement("ic-layouts")]
    public IcLayouts Layouts { get; set; }
}

public class IcDatabase
{
    [XmlElement("ic-dbtype")]
    public string DbType { get; set; }
    
    [XmlElement("ic-sqlite")]
    public SqLite SqLite { get; set; }
    
    [XmlElement("ic-mysql")]
    public MySql MySql { get; set; }
}

public class MySql
{
    [XmlElement("ic-dbserver")]
    public string DbServer { get; set; }
    
    [XmlElement("ic-port")]
    public string Port { get; set; }
    
    [XmlElement("ic-database")]
    public string Database { get; set; }
    
    [XmlElement("ic-username")]
    public string Username { get; set; }
    
    [XmlElement("ic-password")]
    public string Password { get; set; }
    
    [XmlElement("ic-pooling")]
    public string Pooling { get; set; }
    
    [XmlElement("ic-maxpoolsize")]
    public string MaxPoolSize { get; set; }
    
    [XmlElement("ic-minpoolsize")]
    public string MinPoolSize { get; set; }
    
    [XmlElement("ic-charset")]
    public string Charset { get; set; }
    
    [XmlElement("ic-sslmode")]
    public string SslMode { get; set; }
    
    [XmlElement("ic-connectiontimeout")]
    public string ConnectionTimeout { get; set; }
}

public class SqLite
{
    [XmlElement("ic-dbsource")]
    public string DbSource { get; set; }
    [XmlElement("ic-version")]
    public string Version { get; set; }
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