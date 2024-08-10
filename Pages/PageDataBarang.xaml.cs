using IhandCashier.Bepe.Controllers;
using IhandCashier.Bepe.Types;
using IhandCashier.Pages.Views;

namespace IhandCashier.Pages;

public partial class PageDataBarang : PageController
{
	public PageDataBarang()
	{
		InitializeComponent();

        SideMenus.Add("barang", new MenuItemPage { Label = "DATA BARANG", Page =  typeof(GridDataBarang).FullName });
        SideMenus.Add("satuan", new MenuItemPage { Label = "DATA SATUAN BARANG", Page = typeof(GridDataSatuanBarang).FullName });
        
        DefineLayoutTwoColumn();
	}
}
