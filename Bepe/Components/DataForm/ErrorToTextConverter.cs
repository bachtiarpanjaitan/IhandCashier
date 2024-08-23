using System.Globalization;

namespace IhandCashier.Bepe.Components.DataForm;

public class ErrorToTextConverter : IValueConverter
{

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var errors = value as IEnumerable<string>;
        return errors != null && errors.Any() ? string.Join(Environment.NewLine, errors) : string.Empty;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}