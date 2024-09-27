using IhandCashier.Bepe.Types;

namespace IhandCashier.Bepe.Configs;

public static class MenuConfig
{
    public static List<MenuDataType> GetMenus()
    {
        var menus = new List<MenuDataType>();
        menus.Add(new MenuDataType()
        {
            Label = "Saya",
            Child = new List<MenuDataType>()
            {
                new()
                {
                    Class = "PageProfile",
                    Label = "Profil",
                    Child = null
                },
                new()
                {
                    Class = "PageSetting",
                    Label = "Pengaturan",
                    Child = null
                }
            },
            Class = null
        });
        
        menus.Add(new MenuDataType()
        {
            Label = "Master",
            Child = new List<MenuDataType>()
            {
                new()
                {
                    Class = "PageDataBarang",
                    Label = "Data Barang",
                    Child = null
                },
                new()
                {
                    Class = "PageDataPengguna",
                    Label = "Data Pengguna",
                    Child = null
                }
            },
            Class = null
        });
        
        menus.Add(new MenuDataType()
        {
            Label = "Transaksi",
            Child = new List<MenuDataType>()
            {
                new()
                {
                    Class = "PagePenerimaanBarang",
                    Label = "Penerimaan Barang",
                    Child = null
                },
                new()
                {
                    Class = "PagePenjualanBarang",
                    Label = "Penjualan Barang",
                    Child = null
                },
                new()
                {
                    Class = "PageStokBarang",
                    Label = "Stok Barang",
                    Child = null
                },
                new()
                {
                    Class = "PageReturnBarang",
                    Label = "Return Barang",
                    Child = null
                }
            },
            Class = null
        });
        
        menus.Add(new MenuDataType()
        {
            Label = "Keuangan",
            Child = new List<MenuDataType>()
            {
                new()
                {
                    Class = "PageDownPayment",
                    Label = "Uang Muka",
                    Child = null
                },
                new()
                {
                    Class = "PageDebtReceivable",
                    Label = "Hutang Piutang",
                    Child = null
                }
            },
            Class = null
        });
        
        menus.Add(new MenuDataType()
        {
            Label = "Laporan",
            Child = new List<MenuDataType>()
            {
                new()
                {
                    Class = "PageFinancialReport",
                    Label = "Laporan Keuangan",
                    Child = null
                },
                new()
                {
                    Class = "PageProductReport",
                    Label = "Laporan Barang",
                    Child = null
                }
            },
            Class = null
        });

        return menus;
    }
}