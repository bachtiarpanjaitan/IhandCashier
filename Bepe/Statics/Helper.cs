using System.Text.RegularExpressions;

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
    
    public static string FormatToCurrency(decimal amount)
    {
        return string.Format(System.Globalization.CultureInfo.CreateSpecificCulture("id-ID"), "{0:N0}", amount);
    }
}