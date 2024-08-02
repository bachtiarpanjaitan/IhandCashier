using IhandCashier.Bepe.Controllers;
using IhandCashier.Bepe.Types;
using IhandCashier.Pages.Views;

namespace IhandCashier.Pages;

public partial class PageDataBarang : PageController
{
	public PageDataBarang()
	{
		InitializeComponent();

        SideMenus.Add("barang", new MenuItemPage { Label = "DATA BARANG", Page = new GridDataBarang() });
        SideMenus.Add("satuan", new MenuItemPage { Label = "DATA SATUAN BARANG", Page = new GridDataSatuanBarang() });

        DefineLayoutTwoColumn();
	}
}
