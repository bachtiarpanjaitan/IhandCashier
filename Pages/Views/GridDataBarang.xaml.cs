
using IhandCashier.Bepe.Components;
using IhandCashier.Bepe.Constants;
using IhandCashier.Bepe.Entities;
using IhandCashier.Bepe.Providers;
using IhandCashier.Bepe.Types;
using Syncfusion.Maui.DataGrid;

namespace IhandCashier.Pages.Views
{
    public partial class GridDataBarang : ContentView
    {
        private const string ModuleName = "Data Barang";
        public GridDataBarang()
        {
            InitializeComponent();
            new Pagination<Product>();
            List<ColumnType> columns = [
                new ColumnType { Type = ColumnTypes.Numeric,MappingName = "id", ColumnMode = ColumnWidthMode.FitByCell ,HeaderText = "ID", Format = "N0" },
                new ColumnType { Type = ColumnTypes.Text, MappingName = "kode", HeaderText = "KODE" },
                new ColumnType { Type = ColumnTypes.Text, MappingName = "nama", HeaderText = "NAMA BARANG"},
                new ColumnType { Type = ColumnTypes.Text, MappingName = "gambar", HeaderText = "GAMBAR"}
            ];
            
            foreach (var c in columns.Select(col => col.Create())) DatagridProvider.DataGrid.Columns.Add(c);
            FilterOne.Initialize(ModuleName);
            Content = DatagridProvider.LayoutDatagrid;
        }
    }
}

