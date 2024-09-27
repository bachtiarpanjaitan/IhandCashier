using IhandCashier.Bepe.Controllers;
using IhandCashier.Bepe.Types;
using IhandCashier.Pages.Views;

namespace IhandCashier.Pages;

public partial class PageDataBarang : PageController
{
	public PageDataBarang()
	{
		InitializeComponent();
        SideMenus.Add("barang", new MenuItemPage { Label = "BARANG", Page =  typeof(GridDataBarang).FullName, Icon = "\uE8EF"});
        SideMenus.Add("harga_pembelian", new MenuItemPage { Label = "HARGA PEMBELIAN", Page = typeof(GridDataHargaBarang).FullName, Icon = "\uf05b"});
        SideMenus.Add("satuan", new MenuItemPage { Label = "SATUAN", Page = typeof(GridDataSatuanBarang).FullName, Icon = "\uE268"});
        SideMenus.Add("basic_satuan", new MenuItemPage { Label = "SATUAN DASAR", Page = typeof(GridDataSatuanDasarBarang).FullName, Icon = "\uE3F2"});
        DefineLayoutTwoColumn();
	} 
}
