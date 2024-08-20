using IhandCashier.Bepe.Types;

namespace IhandCashier.Bepe.ViewModels;

public class SqLiteViewModel
{
    public IcSqLite SqLite { get; set; }

    public SqLiteViewModel()
    {
        SqLite = new IcSqLite();
    }
}