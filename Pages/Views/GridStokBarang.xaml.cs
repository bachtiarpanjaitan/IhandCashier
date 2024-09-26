using IhandCashier.Bepe.Components;
using IhandCashier.Bepe.Constants;
using IhandCashier.Bepe.Database;
using IhandCashier.Bepe.Dtos;
using IhandCashier.Bepe.Helpers;
using IhandCashier.Bepe.Services;
using IhandCashier.Bepe.Types;
using IhandCashier.Core.Maui.Providers;
using Syncfusion.Maui.DataGrid;

namespace IhandCashier.Pages.Views;

public partial class GridStokBarang
{
    
    private const string ModuleName = "Data Stok Barang";
    private Pagination<ProductStockDto> _pagination;
    ProductStockService _service  = ServiceLocator.ServiceProvider.GetService<ProductStockService>();
    public GridStokBarang()
    {
        InitializeComponent();
        FilterOne.Initialize(ModuleName, new FilterOneComponent(){ShowAddButton = false});
        ResetView();
        
        List<ColumnType> columns = [
            new() { Type = ColumnTypes.Numeric,MappingName = "id", TextAlignment = TextAlignment.Center,ColumnMode = ColumnWidthMode.FitByCell ,HeaderText = "ID", Format = "N0" },
            new() { Type = ColumnTypes.Text, MappingName = "kode", HeaderText = "KODE" },
            new() { Type = ColumnTypes.Text, MappingName = "nama", HeaderText = "NAMA BARANG"},
            new() { Type = ColumnTypes.Numeric, MappingName = "jumlah", HeaderText = "JUMLAH", Format = "N0", TextAlignment = TextAlignment.End},
            new() { Type = ColumnTypes.Text, MappingName = "basic_unit_name", HeaderText = "SATUAN"}
        ];
            
        foreach (var c in columns.Select(col => col.Create())) DatagridProvider.DataGrid.Columns.Add(c);
        Content = DatagridProvider.LayoutDatagrid;
    
        DatagridProvider.ShowLoader();
        Device.BeginInvokeOnMainThread(() =>
        {
            _pagination = new Pagination<ProductStockDto>(_service, typeof(FilterOne));
            DatagridProvider.AddDatagridCellHandler(OnClicked);
            DatagridProvider.HideLoader();
        });
    }

    private void OnClicked(object sender, DataGridCellTappedEventArgs e)
    {
        
    }
}