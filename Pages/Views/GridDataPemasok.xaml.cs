using IhandCashier.Bepe.Components;
using IhandCashier.Bepe.Constants;
using IhandCashier.Bepe.Database;
using IhandCashier.Bepe.Entities;
using IhandCashier.Bepe.Helpers;
using IhandCashier.Bepe.Providers;
using IhandCashier.Bepe.Services;
using IhandCashier.Bepe.Types;
using Syncfusion.Maui.DataGrid;

namespace IhandCashier.Pages.Views;

public partial class GridDataPemasok : ContentView
{
    private const string ModuleName = "Data Pemasok";
    SupplierService _service  = ServiceLocator.ServiceProvider.GetService<SupplierService>();
    public GridDataPemasok()
    {
        InitializeComponent();
        
        FilterOne.Initialize(ModuleName);
            
        DatagridProvider.Reset();
        List<ColumnType> columns = [
            new ColumnType { Type = ColumnTypes.Numeric,MappingName = "id", ColumnMode = ColumnWidthMode.FitByCell ,HeaderText = "ID", Format = "N0" },
            new ColumnType { Type = ColumnTypes.Text, MappingName = "nama", HeaderText = "NAMA"},
            new ColumnType { Type = ColumnTypes.Text, MappingName = "telepon", HeaderText = "TELEPON"},
            new ColumnType { Type = ColumnTypes.Text, MappingName = "alamat", HeaderText = "ALAMAT"}
        ];
        foreach (var c in columns.Select(col => col.Create())) DatagridProvider.DataGrid.Columns.Add(c);
        _ = new Pagination<Supplier>(_service, typeof(FilterOne));
        Content = DatagridProvider.LayoutDatagrid;
    }
}