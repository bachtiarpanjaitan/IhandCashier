using IhandCashier.Bepe.Controllers;
using IhandCashier.Bepe.Types;
using IhandCashier.Pages.Views;

namespace IhandCashier.Pages;

public partial class PageDataPengguna : PageController
{
	public PageDataPengguna()
	{
		InitializeComponent();

        SideMenus.Add("kasir", new MenuItemPage { Label = "DATA KASIR", Page = typeof(GridDataKasir).FullName, Icon = "\ueF3D"});
        SideMenus.Add("pemasok", new MenuItemPage { Label = "DATA PEMASOK", Page = typeof(GridDataPemasok).FullName, Icon = "\uF8D9"});
        SideMenus.Add("pelanggan", new MenuItemPage { Label = "DATA PELANGGAN", Page = typeof(GridDataPelanggan).FullName, Icon = "\uF8D7"});

        DefineLayoutTwoColumn();
	}
}
