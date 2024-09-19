namespace IhandCashier.Bepe.Constants;

public enum ColumnTypes
{
    Numeric,
    Text,
    Date,
    Checkbox,
    Image,
    Button,
    Detail,
    Currency,
    Datetime,
}

public enum ReceiptStatus
{
    Dipesan,
    Perjalanan,
    Diperiksa,
    Diterima,
    Ditolak,
    Selesai,
    SebagianDiterima,
    Dibatalkan
}

public enum StockStatus
{
    Addition,
    Adjustment,
    Deletion
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
    
    public static string GetEnumName<TEnum>(int value) where TEnum : struct, Enum
    {
        return Enum.GetName(typeof(TEnum), value);
    }
}