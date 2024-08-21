using System.ComponentModel.DataAnnotations;

namespace IhandCashier.Bepe.ViewModels;

public class UserLoginViewModel
{
  public DataLogin Form { get; set; } = new();
}

public class DataLogin
{
  [Required(AllowEmptyStrings = false, ErrorMessage = "Username tidak boleh kosong")]
  public string Username { get; set; }
  
  [Required(AllowEmptyStrings = false, ErrorMessage = "Password tidak boleh kosong")]
  [DataType(DataType.Password)]
  public string Password { get; set; }

}