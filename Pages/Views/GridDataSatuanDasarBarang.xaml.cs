using IhandCashier.Bepe.Components;
using IhandCashier.Bepe.Constants;
using IhandCashier.Bepe.Database;
using IhandCashier.Bepe.Entities;
using IhandCashier.Bepe.Providers;
using IhandCashier.Bepe.Types;
using Syncfusion.Maui.DataGrid;

namespace IhandCashier.Pages.Views
{
    public partial class GridDataSatuanDasarBarang : ContentView
    {
        private const string ModuleName = "Data Satuan Dasar Barang";
        public GridDataSatuanDasarBarang()
        {
            InitializeComponent();
            new Pagination<BasicUnit>();
            List<ColumnType> columns = [
                new ColumnType { Type = ColumnTypes.Numeric, MappingName = "id", ColumnMode = ColumnWidthMode.FitByCell , HeaderText = "ID", Format = "N0" },
                new ColumnType { Type = ColumnTypes.Text, MappingName = "nama", HeaderText = "NAMA SATUAN"},
            ];
            
            foreach (var c in columns.Select(col => col.Create())) DatagridProvider.DataGrid.Columns.Add(c);
            FilterOne.Initialize(ModuleName);
            Content = DatagridProvider.LayoutDatagrid;
        }
    }
}

