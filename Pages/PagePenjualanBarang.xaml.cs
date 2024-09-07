using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IhandCashier.Bepe.Controllers;
using IhandCashier.Bepe.Types;
using IhandCashier.Pages.Views;

namespace IhandCashier.Pages;

public partial class PagePenjualanBarang
{
    public PagePenjualanBarang()
    {
        InitializeComponent();
        SideMenus.Add("penjualan_barang", new MenuItemPage { Label = "PENJUALAN", Page =  typeof(GridPenjualanBarang).FullName });
        DefineLayoutTwoColumn();
    }
}