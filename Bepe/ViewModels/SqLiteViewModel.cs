using IhandCashier.Bepe.Types;

namespace IhandCashier.Bepe.ViewModels;

public class SqLiteViewModel
{
    public SqLite SqLite { get; set; }

    public SqLiteViewModel()
    {
        SqLite = new SqLite();
    }
}