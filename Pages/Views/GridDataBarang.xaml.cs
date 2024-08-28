
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
            List<ColumnType> columns = [
                new ColumnType { Type = ColumnTypes.Numeric,MappingName = "id", TextAlignment = TextAlignment.Center,ColumnMode = ColumnWidthMode.FitByCell ,HeaderText = "ID", Format = "N0" },
                new ColumnType { Type = ColumnTypes.Text, MappingName = "kode", HeaderText = "KODE" },
                new ColumnType { Type = ColumnTypes.Text, MappingName = "nama", HeaderText = "NAMA BARANG"},
                new ColumnType { Type = ColumnTypes.Image, MappingName = "resourceGambar", Width = 150, HeaderText = "GAMBAR", ImageHeight = 50, ImageWidth = 50}
            ];
            foreach (var c in columns.Select(col => col.Create())) DatagridProvider.DataGrid.Columns.Add(c);
            _pagination = new Pagination<ProductDto>(_service, typeof(FilterOne), typeof(FormBarang));
            Content = DatagridProvider.LayoutDatagrid;
            
            DatagridProvider.DataGrid.CellTapped += OnRightClick;
            
        }
        
        private void OnRightClick(object sender, DataGridCellTappedEventArgs dataGridCellTappedEventArgs)
        {
            ContextMenu.Clear();
            _selectedProduct = dataGridCellTappedEventArgs.RowData as ProductDto;
            
            MenuFlyoutItem editMenu = new() { Text = "Ubah Data"};
            MenuFlyoutItem deleteMenu = new() { Text = "Hapus Data"};
            editMenu.Clicked += OnEditClicked;
            deleteMenu.Clicked += OnDeleteClicked;
            ContextMenu.Add(editMenu);
            ContextMenu.Add(deleteMenu);

            Console.WriteLine($"Barang : {_selectedProduct.nama}");
        }

        private async  void OnDeleteClicked(object sender, EventArgs e)
        {
            bool accept = await Application.Current.MainPage.DisplayAlert($"Hapus Data Barang", $"Anda yakin menghapus barang {_selectedProduct.nama}?.", "Hapus", "Batal");
            if (accept)
            {
                try
                {
                    await _service.DeleteAsync(_selectedProduct.ToProduct());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Application.Current.MainPage.DisplayAlert("Berhasil", "Barang berhasil dihapus", "OK");
            _pagination.RefreshData();
        }

        private void OnEditClicked(object sender, EventArgs e)
        {
           
        }
    }
}

