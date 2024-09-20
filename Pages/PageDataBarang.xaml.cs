using IhandCashier.Bepe.Controllers;
using IhandCashier.Bepe.Types;
using IhandCashier.Pages.Views;

namespace IhandCashier.Pages;

public partial class PageDataBarang : PageController
{
	public PageDataBarang()
	{
		InitializeComponent();

        SideMenus.Add("barang", new MenuItemPage { Label = "BARANG", Page =  typeof(GridDataBarang).FullName });
        SideMenus.Add("harga_pembelian", new MenuItemPage { Label = "HARGA PEMBELIAN", Page = typeof(GridDataHargaBarang).FullName });
        SideMenus.Add("satuan", new MenuItemPage { Label = "SATUAN", Page = typeof(GridDataSatuanBarang).FullName });
        SideMenus.Add("basic_satuan", new MenuItemPage { Label = "SATUAN DASAR", Page = typeof(GridDataSatuanDasarBarang).FullName });
        DefineLayoutTwoColumn();
	}
}
