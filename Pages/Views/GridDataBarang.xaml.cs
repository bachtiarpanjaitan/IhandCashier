
using CommunityToolkit.Maui.Views;
using IhandCashier.Bepe.Components;
using IhandCashier.Bepe.Constants;
using IhandCashier.Bepe.Database;
using IhandCashier.Bepe.Dtos;
using IhandCashier.Bepe.Entities;
using IhandCashier.Core.Maui.Providers;
using IhandCashier.Bepe.Services;
using IhandCashier.Bepe.Types;
using IhandCashier.Bepe.Helpers;
using IhandCashier.Bepe.Interfaces;
using IhandCashier.Pages.Forms;
using Microsoft.Maui.Controls.Compatibility.Platform.iOS;
using Syncfusion.Maui.DataGrid;

namespace IhandCashier.Pages.Views
{
    public partial class GridDataBarang
    {
        private const string ModuleName = "Data Barang";
        private Pagination<ProductDto> _pagination;
        ProductService _service  = ServiceLocator.ServiceProvider.GetService<ProductService>();
        ProductDto _selectedProduct;
        
        public GridDataBarang()
        {
            InitializeComponent();
            FilterOne.Initialize(ModuleName);
            DatagridProvider.Reset();
            CreateContextMenu();
            
            List<ColumnType> columns = [
                new() { Type = ColumnTypes.Numeric,MappingName = "id", TextAlignment = TextAlignment.Center,ColumnMode = ColumnWidthMode.FitByCell ,HeaderText = "ID", Format = "N0" },
                new() { Type = ColumnTypes.Text, MappingName = "kode", HeaderText = "KODE" },
                new() { Type = ColumnTypes.Text, MappingName = "nama", HeaderText = "NAMA BARANG"},
                new() { Type = ColumnTypes.Image, MappingImage = "resourceGambar" ,MappingName = "resourceGambarThumbnail", Width = 110, HeaderText = "GAMBAR", ImageHeight = 50, ImageWidth = 50}
            ];
            foreach (var c in columns.Select(col => col.Create())) DatagridProvider.DataGrid.Columns.Add(c);
            Content = DatagridProvider.LayoutDatagrid;

            DatagridProvider.ShowLoader();
            Device.BeginInvokeOnMainThread(() =>
            {
                _pagination = new Pagination<ProductDto>(_service, typeof(FilterOne), typeof(FormBarang));
                DatagridProvider.DataGrid.CellTapped += OnRightClick;
                DatagridProvider.HideLoader();
            });
        }
        
        private void OnRightClick(object sender, DataGridCellTappedEventArgs dataGridCellTappedEventArgs)
        {
            _selectedProduct = dataGridCellTappedEventArgs.RowData as ProductDto;
            if (_selectedProduct != null) Console.WriteLine($"Barang : {_selectedProduct.kode}");
        }

        private async  void OnDeleteClicked(object sender, EventArgs e)
        {
            bool accept = await Application.Current.MainPage.DisplayAlert($"Hapus Data Barang", $"Anda yakin menghapus barang {_selectedProduct.kode}?.", "Hapus", "Batal");
            if (accept)
            {
                try
                {
                    await _service.DeleteAsync(_selectedProduct.ToEntity());
                    Application.Current.MainPage.DisplayAlert("Berhasil", "Barang berhasil dihapus", "OK");
                    _pagination.RefreshData();
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
                    manager.ShowPopup(new FormBarang(_selectedProduct.ToViewModel()));
                }
                
            }
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
    }
}

