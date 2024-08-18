using IhandCashier.Bepe.Components;
using IhandCashier.Bepe.Constants;
using IhandCashier.Bepe.Database;
using IhandCashier.Bepe.Entities;
using IhandCashier.Core.Maui.Providers;
using IhandCashier.Bepe.Services;
using IhandCashier.Bepe.Types;
using IhandCashier.Bepe.Helpers;
using Syncfusion.Maui.DataGrid;

namespace IhandCashier.Pages.Views
{
    public partial class GridDataSatuanDasarBarang
    {
        private const string ModuleName = "Data Satuan Dasar Barang";
        BasicUnitService _service  = ServiceLocator.ServiceProvider.GetService<BasicUnitService>();
        public GridDataSatuanDasarBarang()
        {
            InitializeComponent();
            FilterOne.Initialize(ModuleName);
            DatagridProvider.Reset();
            List<ColumnType> columns = [
                new ColumnType { Type = ColumnTypes.Numeric,TextAlignment = TextAlignment.Center, MappingName = "id", ColumnMode = ColumnWidthMode.FitByCell , HeaderText = "ID", Format = "N0" },
                new ColumnType { Type = ColumnTypes.Text, MappingName = "nama", HeaderText = "NAMA SATUAN"},
            ];
            
            foreach (var c in columns.Select(col => col.Create())) DatagridProvider.DataGrid.Columns.Add(c);
            
            _ = new Pagination<BasicUnit>(_service, typeof(FilterOne));
            Content = DatagridProvider.LayoutDatagrid;
        }
        
        
    }
}

