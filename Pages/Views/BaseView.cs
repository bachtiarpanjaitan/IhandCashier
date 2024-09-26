using IhandCashier.Core.Maui.Providers;

namespace IhandCashier.Pages.Views;

public class BaseView : ContentView
{
    public void ResetView()
    {
        DatagridProvider.Reset();
    }
}