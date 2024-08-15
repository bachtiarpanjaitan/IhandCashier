using IhandCashier.Bepe.Controllers;
using IhandCashier.Bepe.Types;
using IhandCashier.Pages.Views;

namespace IhandCashier.Pages;

public partial class PageDataPengguna : PageController
{
	public PageDataPengguna()
	{
		InitializeComponent();

        SideMenus.Add("kasir", new MenuItemPage { Label = "DATA KASIR", Page = typeof(GridDataKasir).FullName });
        SideMenus.Add("pemasok", new MenuItemPage { Label = "DATA PEMASOK", Page = typeof(GridDataPemasok).FullName });
        SideMenus.Add("pelanggan", new MenuItemPage { Label = "DATA PELANGGAN", Page = typeof(GridDataPelanggan).FullName });

        DefineLayoutTwoColumn();
	}
}
