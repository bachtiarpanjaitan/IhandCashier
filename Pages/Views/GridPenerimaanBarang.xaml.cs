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
using IhandCashier.Pages.Forms;
using Syncfusion.Maui.DataGrid;

namespace IhandCashier.Pages.Views;

public partial class GridPenerimaanBarang
{
    private const string ModuleName = "Data Penerimaan Barang";
    ProductReceiptService _service  = ServiceLocator.ServiceProvider.GetService<ProductReceiptService>();
    ProductReceiptDto _selectedProduct;
    public GridPenerimaanBarang()
    {
        InitializeComponent();
        FilterOne.Initialize(ModuleName);
        ResetView();
        
        List<ColumnType> columns = [
            new() { Type = ColumnTypes.Numeric, MappingName = "Id", TextAlignment = TextAlignment.Center,ColumnMode = ColumnWidthMode.FitByCell ,HeaderText = "ID", Format = "N0" },
            new() { Type = ColumnTypes.Detail, MappingName = "Expand", HeaderText = "DETAIL", ColumnMode = ColumnWidthMode.FitByCell},
            new() { Type = ColumnTypes.Text, MappingName = "KodeTransaksi", HeaderText = "KODE" },
            new() { Type = ColumnTypes.Text, MappingName = "ItemCount", HeaderText = "ITEM", Format = "N0", ColumnMode = ColumnWidthMode.FitByCell},
            new() { Type = ColumnTypes.Currency, MappingName = "Total", HeaderText = "TOTAL HARGA"},
            new() { Type = ColumnTypes.Text, MappingName = "SupplierName", HeaderText = "PEMASOK"},
            new() { Type = ColumnTypes.Text, MappingName = "Penerima", HeaderText = "PENERIMA"},
            new() { Type = ColumnTypes.Date, MappingName = "Tanggal", HeaderText = "TANGGAL",ColumnMode = ColumnWidthMode.FitByCell, TextAlignment = TextAlignment.Center},
            new() { Type = ColumnTypes.Text, MappingName = "StatusName", HeaderText = "STATUS"},
            new() { Type = ColumnTypes.Text, MappingName = "Keterangan", HeaderText = "KETERANGAN"}
        ];
            
        foreach (var c in columns.Select(col => col.Create())) DatagridProvider.DataGrid.Columns.Add(c);
        Content = DatagridProvider.LayoutDatagrid;
    
        DatagridProvider.ShowLoader();
        Device.BeginInvokeOnMainThread(() =>
        {
            using var _pagination = new Pagination<ProductReceiptDto>(_service, typeof(FilterOne), typeof(FormPenerimaanBarang));
            SetContextMenuHandler(ContextMenu,new ContextMenuHandlers
            {
                DeleteHandler = OnDeleteClicked,
                EditHandler = OnEditClicked,
                RefreshHandler = (sender, args) => _pagination.RefreshData()
            });
            DatagridProvider.AddDatagridCellHandler(OnClicked, OnEditClicked);
            DatagridProvider.HideLoader();
        });
    }

    private void OnClicked(object sender, DataGridCellTappedEventArgs e)
    {
        _selectedProduct = e.RowData as ProductReceiptDto;
        if (_selectedProduct != null) Console.WriteLine($"Transaksi : {_selectedProduct.KodeTransaksi}");
        DatagridProvider.DataGrid.SelectedIndex = e.RowColumnIndex.RowIndex;
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        bool accept = await Application.Current.MainPage.DisplayAlert($"Hapus Data Penerimaan Barang", $"Anda yakin menghapus penerimaan {_selectedProduct.KodeTransaksi}?.", "Hapus", "Batal");
        if (accept)
        {
            try
            {
                var item = _selectedProduct.ToEntity();
                item.Details = _selectedProduct.ToViewModel().Details.Select(d => d.ToEntity()).ToList();
                await _service.SoftDeleteAsync(item);
                Application.Current.MainPage.DisplayAlert("Berhasil", "Penerimaan Barang berhasil dihapus", "OK");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Application.Current.MainPage.DisplayAlert("Gagal", ex.Message, "OK");
            }
        }
    }

    private void OnEditClicked(object sender, EventArgs e)
    {
        if (Application.Current != null && Application.Current.MainPage != null)
        {
            if (_selectedProduct != null)
            {
                var manager = new PopupManager();
                manager.ShowPopup(new FormPenerimaanBarang(_selectedProduct.ToViewModel()));
            }
                
        }
    }
}