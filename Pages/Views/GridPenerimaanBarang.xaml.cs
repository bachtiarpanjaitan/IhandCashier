using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

public partial class GridPenerimaanBarang : ContentView
{
    private const string ModuleName = "Data Penerimaan Barang";
    private Pagination<ProductReceiptDto> _pagination;
    ProductReceiptService _service  = ServiceLocator.ServiceProvider.GetService<ProductReceiptService>();
    ProductReceiptDto _selectedProduct;
    public GridPenerimaanBarang()
    {
        InitializeComponent();
        FilterOne.Initialize(ModuleName);
        DatagridProvider.Reset();
        CreateContextMenu();
        
        List<ColumnType> columns = [
            new() { Type = ColumnTypes.Numeric,MappingName = "Id", TextAlignment = TextAlignment.Center,ColumnMode = ColumnWidthMode.FitByCell ,HeaderText = "ID", Format = "N0" },
            new() { Type = ColumnTypes.Text, MappingName = "KodeTransaksi", HeaderText = "KODE" },
            new() { Type = ColumnTypes.Text, MappingName = "SupplierName", HeaderText = "PEMASOK"},
            new() { Type = ColumnTypes.Text, MappingName = "Penerima", HeaderText = "PENERIMA"},
            new() { Type = ColumnTypes.Text, MappingName = "Tanggal", HeaderText = "TANGGAL"},
            new() { Type = ColumnTypes.Text, MappingName = "Keterangan", HeaderText = "KETERANGAN"}
        ];
            
        foreach (var c in columns.Select(col => col.Create())) DatagridProvider.DataGrid.Columns.Add(c);
        _pagination = new Pagination<ProductReceiptDto>(_service, typeof(FilterOne));
        DatagridProvider.DataGrid.CellTapped += OnRightClick;
        Content = DatagridProvider.LayoutDatagrid;
    }

    private void OnRightClick(object sender, DataGridCellTappedEventArgs e)
    {
        _selectedProduct = e.RowData as ProductReceiptDto;
        if (_selectedProduct != null) Console.WriteLine($"Transaksi : {_selectedProduct.KodeTransaksi}");
    }

    private void CreateContextMenu()
    {
        MenuFlyoutItem refreshMenu = new() { Text = "Refresh Data"};
        MenuFlyoutItem editMenu = new() { Text = "Ubah Data"};
        MenuFlyoutItem deleteMenu = new() { Text = "Hapus Data"};
        editMenu.Clicked += OnEditClicked;
        deleteMenu.Clicked += OnDeleteClicked;
        refreshMenu.Clicked += OnRefreshClicked;
        ContextMenu.Add(refreshMenu);
        ContextMenu.Add(editMenu);
        ContextMenu.Add(new MenuFlyoutSeparator());
        ContextMenu.Add(deleteMenu);
    }

    private void OnRefreshClicked(object sender, EventArgs e)
    {
        _pagination.RefreshData();
    }

    private void OnDeleteClicked(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private void OnEditClicked(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
}