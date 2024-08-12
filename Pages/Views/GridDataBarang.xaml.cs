
using IhandCashier.Bepe.Components;
using IhandCashier.Bepe.Constants;
using IhandCashier.Bepe.Entities;
using IhandCashier.Bepe.Types;
using Syncfusion.Maui.DataGrid;

namespace IhandCashier.Pages.Views
{
    public partial class GridDataBarang : ContentView
    {
        public GridDataBarang()
        {
            InitializeComponent();
            var grid = new IcDataGrid<Product>([
                new ColumnType { Type = ColumnTypes.Text, MappingName = "id", HeaderText = "ID", Format = "N0"},
                new ColumnType { Type = ColumnTypes.Text, MappingName = "kode", HeaderText = "KODE" },
                new ColumnType { Type = ColumnTypes.Text, MappingName = "nama", HeaderText = "NAMA BARANG"},
                new ColumnType { Type = ColumnTypes.Text, MappingName = "gambar", HeaderText = "GAMBAR"}

            ], "Data Barang");
            Content = grid.GetView();
        }
    }
}

