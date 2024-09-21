using System.Text.RegularExpressions;
using Syncfusion.Maui.DataGrid;

namespace IhandCashier.Bepe.Statics;

public class Helper
{
    public static string SplitCamelCase(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }
        
        // Regex to insert space before each uppercase letter except the first one
        string pattern = @"(?<!^)(?=[A-Z])";
        string replacement = " ";
        
        return Regex.Replace(input, pattern, replacement);
    }
    
    public static string FormatToCurrency(double amount)
    {
        return string.Format(System.Globalization.CultureInfo.CreateSpecificCulture("id-ID"), "{0:C2}", amount);
    }

    public static DataGridStyle SetDataGridStyle()
    {
        return new DataGridStyle()
        {
            AlternateRowBackground = Application.Current.UserAppTheme == AppTheme.Light
                ? Color.FromArgb("#f7f4f0")
                : Color.FromArgb("#404040"),
            RowTextColor = Application.Current.UserAppTheme == AppTheme.Light
                ? Color.FromArgb("#171717")
                : Color.FromArgb("#E1E1E1"),
            SelectionBackground = Brush.Transparent,
            CurrentCellBorderColor = Color.FromArgb("#fca544")
            
        };
    }
}