using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IhandCashier.Bepe.Types;
using IhandCashier.Core.Maui.Providers;
using IhandCashier.Pages.Views;

namespace IhandCashier.Pages;

public partial class PageStokBarang
{
    public PageStokBarang()
    {
        InitializeComponent();
        SideMenus.Add("stok_barang", new MenuItemPage { Label = "STOK", Page =  typeof(GridStokBarang).FullName });
        SideMenus.Add("stok_penyesuaian_barang", new MenuItemPage { Label = "PENYESUAIAN", Page =  typeof(GridPenyesuaianBarang).FullName });

        DefineLayoutTwoColumn();
    }
}