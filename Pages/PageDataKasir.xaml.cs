using IhandCashier.Bepe.Controllers;
using IhandCashier.Bepe.Types;
using IhandCashier.Pages.Views;

namespace IhandCashier.Pages;

public partial class PageDataKasir : PageController
{
	public PageDataKasir()
	{
		InitializeComponent();

        SideMenus.Add("grid", new MenuItemPage { Label = "DATA KASIR", Page = new GridDataKasir() });
        DefineLayoutTwoColumn();
	}
}
