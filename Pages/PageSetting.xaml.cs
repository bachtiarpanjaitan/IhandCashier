using IhandCashier.Bepe.Controllers;
using IhandCashier.Bepe.Types;
using IhandCashier.Pages.Views;

namespace IhandCashier.Pages;

public partial class PageSetting
{
	public PageSetting()
	{
		InitializeComponent();
		
		SideMenus.Add("setting_aplikasi", new MenuItemPage { Label = "APLIKASI", Page =  typeof(SettingApplication).FullName, Icon = "\ue1b1"});
		SideMenus.Add("setting_hak_akses", new MenuItemPage { Label = "HAK AKSES", Page =  typeof(SettingAcl).FullName, Icon = "\ue32a"});

		DefineLayoutTwoColumn();
	}
}
