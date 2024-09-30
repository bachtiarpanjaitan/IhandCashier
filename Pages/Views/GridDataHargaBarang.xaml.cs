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

public partial class GridDataHargaBarang
{
  private const string ModuleName = "Data Harga Barang";
  ProductPriceService _service  = ServiceLocator.ServiceProvider.GetService<ProductPriceService>();
  ProductPriceDto _selectedProduct;
  Pagination<ProductPriceDto> _pagination;
  public GridDataHargaBarang()
  {
    InitializeComponent();
    FilterOne.Initialize(ModuleName);
    ResetView();
    
    List<ColumnType> columns = [
      new() { Type = ColumnTypes.Numeric,MappingName = "id", TextAlignment = TextAlignment.Center,ColumnMode = ColumnWidthMode.FitByCell ,HeaderText = "ID", Format = "N0" },
      new() { Type = ColumnTypes.Text, MappingName = "kode", HeaderText = "KODE",ColumnMode = ColumnWidthMode.FitByCell },
      new() { Type = ColumnTypes.Text, MappingName = "nama", HeaderText = "NAMA BARANG"},
      new() { Type = ColumnTypes.Currency, MappingName = "harga", HeaderText = "HRG.SATUAN"},
      new() { Type = ColumnTypes.Text, MappingName = "unit_nama", HeaderText = "SATUAN"},
      new() { Type = ColumnTypes.Currency, MappingName = "harga_satuan_terkecil", HeaderText = "HRG.SATUAN DASAR"},
      new() { Type = ColumnTypes.Text, MappingName = "basic_unit_nama", HeaderText = "SATUAN DASAR"},
      new() { Type = ColumnTypes.Date, MappingName = "tanggal_berlaku", HeaderText = "TANGGAL BERLAKU"},
    ];
            
    foreach (var c in columns.Select(col => col.Create())) DatagridProvider.DataGrid.Columns.Add(c);
    Content = DatagridProvider.LayoutDatagrid;
    
    DatagridProvider.ShowLoader();
    Device.BeginInvokeOnMainThread(() =>
    {
      _pagination = new Pagination<ProductPriceDto>(_service, typeof(FilterOne));
      SetContextMenuHandler(ContextMenu,new ContextMenuHandlers
      {
        DeleteHandler = OnDeleteClicked,
        EditHandler = OnEditClicked,
        RefreshHandler = (sender, args) => _pagination.RefreshData() 
      });
      DatagridProvider.AddDatagridCellHandler(OnClick);
      DatagridProvider.HideLoader();
    });
  }

  private void OnClick(object sender, DataGridCellTappedEventArgs e)
  {
    _selectedProduct = e.RowData as ProductPriceDto;
    if (_selectedProduct != null) Console.WriteLine($"Barang : {_selectedProduct.kode}");
  }

  private void OnDeleteClicked(object sender, EventArgs e)
  {
    
  }

  private void OnEditClicked(object sender, EventArgs e)
  {
   
  }
}