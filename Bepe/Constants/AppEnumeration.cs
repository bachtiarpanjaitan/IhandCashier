namespace IhandCashier.Bepe.Constants;

public enum ColumnTypes
{
    Numeric,
    Text,
    Date,
    Checkbox,
    Image
}

public enum Themes
{
    Dark,
    Light
}

public enum DbTypes
{
    SqLite,
    MySql
}

public class AppEnumeration
{
    public static Dictionary<Enum, string> GetDbTypes = new()
    {
        { Constants.DbTypes.SqLite, "sqlite" },
        { Constants.DbTypes.MySql, "mysql" }
    };
}