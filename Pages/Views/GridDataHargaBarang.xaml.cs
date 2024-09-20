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
  private Pagination<ProductPriceDto> _pagination;
  ProductPriceService _service  = ServiceLocator.ServiceProvider.GetService<ProductPriceService>();
  ProductPriceDto _selectedProduct;
  
  public GridDataHargaBarang()
  {
    InitializeComponent();
    FilterOne.Initialize(ModuleName);
    DatagridProvider.Reset();
    CreateContextMenu();
    
    List<ColumnType> columns = [
      new() { Type = ColumnTypes.Numeric,MappingName = "id", TextAlignment = TextAlignment.Center,ColumnMode = ColumnWidthMode.FitByCell ,HeaderText = "ID", Format = "N0" },
      new() { Type = ColumnTypes.Text, MappingName = "kode", HeaderText = "KODE" },
      new() { Type = ColumnTypes.Text, MappingName = "nama", HeaderText = "NAMA BARANG"},
      new() { Type = ColumnTypes.Text, MappingName = "unit_nama", HeaderText = "SATUAN"},
      new() { Type = ColumnTypes.Currency, MappingName = "harga", HeaderText = "HARGA SATUAN"},
      new() { Type = ColumnTypes.Text, MappingName = "basic_unit_nama", HeaderText = "SATUAN TERKECIL"},
      new() { Type = ColumnTypes.Date, MappingName = "tanggal_berlaku", HeaderText = "TANGGAL BERLAKU"},
    ];
            
    foreach (var c in columns.Select(col => col.Create())) DatagridProvider.DataGrid.Columns.Add(c);
    _pagination = new Pagination<ProductPriceDto>(_service, typeof(FilterOne));
    DatagridProvider.DataGrid.CellTapped += OnRightClick;
    Content = DatagridProvider.LayoutDatagrid;
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

  private void OnRightClick(object sender, DataGridCellTappedEventArgs e)
  {
    _selectedProduct = e.RowData as ProductPriceDto;
    if (_selectedProduct != null) Console.WriteLine($"Barang : {_selectedProduct.kode}");
  }
  private void OnRefreshClicked(object sender, EventArgs e)
  {
    
  }

  private void OnDeleteClicked(object sender, EventArgs e)
  {
    
  }

  private void OnEditClicked(object sender, EventArgs e)
  {
   
  }
}