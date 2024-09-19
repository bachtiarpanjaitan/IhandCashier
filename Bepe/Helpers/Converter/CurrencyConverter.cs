namespace IhandCashier.Bepe.Helpers.Converter;

using System;
using System.Globalization;

public class CurrencyConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is decimal decimalValue)
        {
            // Mengonversi nilai ke format mata uang Rupiah
            return decimalValue.ToString("C", new CultureInfo("id-ID"));
        }
        return value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is string stringValue)
        {
            // Menghapus simbol mata uang dan konversi kembali ke decimal
            stringValue = stringValue.Replace("Rp", "").Replace(".", "").Trim();
            if (decimal.TryParse(stringValue, out decimal decimalValue))
            {
                return decimalValue;
            }
        }
        return 0m;
    }
}
