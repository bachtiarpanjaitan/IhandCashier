using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IhandCashier.Bepe.Types;
using IhandCashier.Pages.Views;

namespace IhandCashier.Pages;

public partial class PageReturnBarang
{
    public PageReturnBarang()
    {
        InitializeComponent();
        SideMenus.Add("return_beli", new MenuItemPage { Label = "RETURN BELI", Page =  typeof(GridReturnBeli).FullName });
        SideMenus.Add("return_jual", new MenuItemPage { Label = "RETURN JUAL", Page =  typeof(GridReturnJual).FullName });

        DefineLayoutTwoColumn();
    }
}