
using CommunityToolkit.Maui.Views;
using IhandCashier.Bepe.Components;
using IhandCashier.Bepe.Constants;
using IhandCashier.Bepe.Database;
using IhandCashier.Bepe.Dtos;
using IhandCashier.Core.Maui.Providers;
using IhandCashier.Bepe.Services;
using IhandCashier.Bepe.Types;
using IhandCashier.Bepe.Helpers;
using IhandCashier.Pages.Forms;
using Syncfusion.Maui.DataGrid;

namespace IhandCashier.Pages.Views
{
    public partial class GridDataBarang
    {
        private const string ModuleName = "Data Barang";
        ProductService _service  = ServiceLocator.ServiceProvider.GetService<ProductService>();
        ProductDto _selectedProduct;
        Pagination<ProductDto> _pagination;
        
        public GridDataBarang()
        {
            InitializeComponent();
            FilterOne.Initialize(ModuleName);
            ResetView();
            List<ColumnType> columns = [
                new ()  { Type = ColumnTypes.Numeric,MappingName = "id", TextAlignment = TextAlignment.Center,ColumnMode = ColumnWidthMode.FitByCell ,HeaderText = "ID", Format = "N0" },
                new() { Type = ColumnTypes.Text, MappingName = "kode", HeaderText = "KODE" },
                new() { Type = ColumnTypes.Text, MappingName = "nama", HeaderText = "NAMA BARANG"},
                // new() { Type = ColumnTypes.Image, MappingImage = "resourceGambar" ,MappingName = "resourceGambarThumbnail", Width = 110, HeaderText = "GAMBAR", ImageHeight = 50, ImageWidth = 50}
            ];
            SetDatagridColumns(columns);
            Content = DatagridProvider.LayoutDatagrid;

            DatagridProvider.ShowLoader();
            Device.BeginInvokeOnMainThread(() =>
            {
                _pagination = new Pagination<ProductDto>(_service, typeof(FilterOne), typeof(FormBarang));
                SetContextMenuHandler(ContextMenu,new ContextMenuHandlers
                {
                    DeleteHandler = OnDeleteClicked,
                    EditHandler = OnEditClicked,
                    RefreshHandler = (sender, args) => _pagination.RefreshData()
                });
                DatagridProvider.AddDatagridCellHandler(OnClick,OnEditClicked);
                DatagridProvider.HideLoader();
            });
        }
        
        
        private void OnClick(object sender, DataGridCellTappedEventArgs dataGridCellTappedEventArgs)
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
    }
}

