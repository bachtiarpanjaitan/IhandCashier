using IhandCashier.Bepe.Injections;
using IhandCashier.Core;

namespace IhandCashier;

public partial class App
{
    public App()
    {
        InitializeComponent();
        Loader.Load();
        new Boot().Execute();
    }
}

