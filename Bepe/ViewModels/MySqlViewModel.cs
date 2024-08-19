using IhandCashier.Bepe.Types;

namespace IhandCashier.Bepe.ViewModels;

public class MySqlViewModel
{
    public MySql MySql { get; set; }

    public MySqlViewModel()
    {
        MySql = new MySql();
    }
}