namespace IhandCashier.Bepe.Statics;

public class SessionManager
{
    public static string Username { get; set; }
    public static string Theme { get; set; }
    
    public static void SetSession(string username, string theme)
    {
        Username = username;
        Theme = theme;
    }

    // Method untuk mendapatkan session
    public static (string, string) GetSession()
    {
        return (Username, Theme);
    }
}