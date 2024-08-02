using IhandCashier.Bepe.Controllers;
using IhandCashier.Bepe.Types;
using IhandCashier.Pages.Views;

namespace IhandCashier.Pages;

public partial class PageDataBarang : PageController
{
	public PageDataBarang()
	{
		InitializeComponent();

		Menus.Add("barang", new MenuItemPage { Label = "DATA BARANG", Page = new GridDataBarang() });
		Menus.Add("satuan", new MenuItemPage { Label = "DATA SATUAN BARANG", Page = new GridDataSatuanBarang() });

        DefineLayoutTwoColumn();
	}
}
