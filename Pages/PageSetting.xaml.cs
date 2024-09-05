using IhandCashier.Bepe.Controllers;
using IhandCashier.Bepe.Types;
using IhandCashier.Pages.Views;

namespace IhandCashier.Pages;

public partial class PageSetting : PageController
{
	public PageSetting()
	{
		InitializeComponent();
		
		SideMenus.Add("setting_aplikasi", new MenuItemPage { Label = "APLIKASI", Page =  typeof(SettingApplication).FullName });
		DefineLayoutTwoColumn();
	}
}
