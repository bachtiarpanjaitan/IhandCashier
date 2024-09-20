using IhandCashier.Bepe.Components;
using IhandCashier.Bepe.Constants;
using IhandCashier.Bepe.Database;
using IhandCashier.Bepe.Entities;
using IhandCashier.Bepe.Helpers;
using IhandCashier.Core.Maui.Providers;
using IhandCashier.Bepe.Services;
using IhandCashier.Bepe.Types;
using IhandCashier.Pages.Forms;
using Syncfusion.Maui.DataGrid;

namespace IhandCashier.Pages.Views;

public partial class GridDataPelanggan : ContentView
{
    private const string ModuleName = "Data Pelanggan";
    CustomerService _service  = ServiceLocator.ServiceProvider.GetService<CustomerService>();
    private Pagination<Customer> _pagination;
    Customer _selectedProduct;
    public GridDataPelanggan()
    {
        InitializeComponent();
        
        FilterOne.Initialize(ModuleName);
            
        DatagridProvider.Reset();
        List<ColumnType> columns = [
            new ColumnType { Type = ColumnTypes.Numeric,TextAlignment = TextAlignment.Center,MappingName = "id", ColumnMode = ColumnWidthMode.FitByCell ,HeaderText = "ID", Format = "N0" },
            new ColumnType { Type = ColumnTypes.Text, MappingName = "nama", HeaderText = "NAMA"},
            new ColumnType { Type = ColumnTypes.Text, MappingName = "telepon", HeaderText = "TELEPON"},
            new ColumnType { Type = ColumnTypes.Text, MappingName = "alamat", HeaderText = "ALAMAT"}
        ];
        foreach (var c in columns.Select(col => col.Create())) DatagridProvider.DataGrid.Columns.Add(c);
        Content = DatagridProvider.LayoutDatagrid;
    
        DatagridProvider.ShowLoader();
        Device.BeginInvokeOnMainThread(() =>
        {
            _pagination = new Pagination<Customer>(_service, typeof(FilterOne));
            DatagridProvider.DataGrid.CellTapped += OnRightClick;
            DatagridProvider.HideLoader();
        });
    }

    private void OnRightClick(object sender, DataGridCellTappedEventArgs e)
    {
        _selectedProduct = e.RowData as Customer;
        if (_selectedProduct != null) Console.WriteLine($"Barang : {_selectedProduct.nama}");
    }
}