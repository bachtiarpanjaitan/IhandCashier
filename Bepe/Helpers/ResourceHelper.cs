using System.Reflection;

namespace IhandCashier.Bepe.Helpers;

public class ResourceHelper
{
    public static string ReadAsString(string resourceName)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var resourceStream = assembly.GetManifestResourceStream(resourceName);

        if (resourceStream == null)
        {
            return null;
        }

        using (var reader = new StreamReader(resourceStream))
        {
            return reader.ReadToEnd();
        }
    }
    
    public static StreamReader ReadAsStreamReader(string resourceName)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var resourceStream = assembly.GetManifestResourceStream(resourceName);

        if (resourceStream == null)
        {
            return null;
        }

        var reader = new StreamReader(resourceStream);
        return reader;
    }
}