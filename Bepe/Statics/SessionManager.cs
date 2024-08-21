using IhandCashier.Bepe.Configs;
using IhandCashier.Bepe.Types;

namespace IhandCashier.Bepe.Statics;

public class SessionManager
{
    public SessionManager(){}
    public SessionManager SetSession(UserSession session)
    {
        Preferences.Set("Username", Crypto.Encrypt(session.Username,AppConfig.APP_KEY));
        Preferences.Set("Email", Crypto.Encrypt(session.Email,AppConfig.APP_KEY));
        Preferences.Set("IsAdmin", session.IsAdmin);
        Preferences.Set("IsActive", session.IsActive);
        Preferences.Set("IsLogin", session.IsLogin);
        Preferences.Set("Avatar", session.Avatar);
        return this;
    }

    public UserSession GetSession()
    {
        return new UserSession()
        {
            Username = Crypto.Decrypt(Preferences.Get("Username", String.Empty),AppConfig.APP_KEY),
            Email = Crypto.Decrypt(Preferences.Get("Email",String.Empty),AppConfig.APP_KEY),
            IsLogin = Preferences.Get("IsLogin", false),
            IsAdmin = Preferences.Get("IsAdmin", false),
            IsActive = Preferences.Get("IsActive", false),
            Avatar = Preferences.Get("Avatar", string.Empty),
        };
    }

    public bool IsLogin()
    {
        return Preferences.Get("IsLogin", false);
    }
    public void ResetSession()
    {
        Preferences.Clear();
    }
}