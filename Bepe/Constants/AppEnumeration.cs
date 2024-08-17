namespace IhandCashier.Bepe.Constants;

public enum ColumnTypes
{
    Numeric,
    Text,
    Date,
    Checkbox
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

public class AppEnumeration()
{
    public Dictionary<Enum, string> DbTypes = new()
    {
        { Constants.DbTypes.SqLite, "sqlite" },
        { Constants.DbTypes.MySql, "mysql" }
    };
}