using IhandCashier.Bepe.Types;

namespace IhandCashier.Bepe.ViewModels;

public class MySqlViewModel
{
    public IcMySql MySql { get; set; }

    public MySqlViewModel()
    {
        MySql = new IcMySql();
    }
}