using IhandCashier.Bepe.Components;
using IhandCashier.Bepe.Constants;
using IhandCashier.Bepe.Entities;
using IhandCashier.Bepe.Providers;
using IhandCashier.Bepe.Types;

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
                new ColumnType { Type = ColumnTypes.Text, MappingName = "id", Width = 100, HeaderText = "ID", Format = "N0" },
                new ColumnType { Type = ColumnTypes.Text, MappingName = "nama", HeaderText = "NAMA SATUAN"},
            ];
            
            foreach (var c in columns.Select(col => col.Create())) DatagridProvider.DataGrid.Columns.Add(c);
            FilterOne<Product>.Initialize(ModuleName);
            Content = DatagridProvider.LayoutDatagrid;
        }
    }
}

