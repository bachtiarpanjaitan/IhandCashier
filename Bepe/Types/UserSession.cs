namespace IhandCashier.Bepe.Types;

public class UserSession
{
    public string Username { get; set; }
    public string Email { get; set; }
    public bool IsLogin { get; set; }
    public string Avatar { get; set; }
    public bool IsAdmin { get; set; }
    public bool IsActive { get; set; }
    
    public UserSession()
    {
        
    }
}