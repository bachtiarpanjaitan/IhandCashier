using IhandCashier.Bepe.Components;
using IhandCashier.Bepe.Constants;
using IhandCashier.Bepe.Database;
using IhandCashier.Bepe.Dtos;
using IhandCashier.Bepe.Entities;
using IhandCashier.Core.Maui.Providers;
using IhandCashier.Bepe.Services;
using IhandCashier.Bepe.Types;
using IhandCashier.Bepe.Helpers;
using IhandCashier.Pages.Forms;
using Syncfusion.Maui.DataGrid;

namespace IhandCashier.Pages.Views
{
    public sealed partial class GridDataSatuanDasarBarang
    {
        
        private const string ModuleName = "Data Satuan Dasar Barang";
        BasicUnitService _service  = ServiceLocator.ServiceProvider.GetService<BasicUnitService>();
        private Pagination<BasicUnitDto> _pagination;
        BasicUnitDto _selected;
        public GridDataSatuanDasarBarang()
        {
            InitializeComponent();
            FilterOne.Initialize(ModuleName);
            DatagridProvider.Reset();
            CreateContextMenu();
            List<ColumnType> columns = [
                new() { Type = ColumnTypes.Numeric,TextAlignment = TextAlignment.Center, MappingName = "id", ColumnMode = ColumnWidthMode.FitByCell , HeaderText = "ID", Format = "N0" },
                new() { Type = ColumnTypes.Text, MappingName = "nama", HeaderText = "NAMA SATUAN"},
            ];
            
            foreach (var c in columns.Select(col => col.Create())) DatagridProvider.DataGrid.Columns.Add(c);
            
            _pagination = new Pagination<BasicUnitDto>(_service, typeof(FilterOne), typeof(FormSatuanDasarBarang));
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

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            bool accept = await Application.Current.MainPage.DisplayAlert($"Hapus Satuan Dasar", $"Anda yakin menghapus satuan dasar {_selected.nama}?.", "Hapus", "Batal");
            if (accept)
            {
                try
                {
                    await _service.DeleteAsync(_selected.ToEntity());
                    Application.Current.MainPage.DisplayAlert("Berhasil", "Satuan dasar berhasil dihapus", "OK");
                    _pagination.RefreshData();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Application.Current.MainPage.DisplayAlert("Gagal", ex.Message, "OK");
                }
            }
        }

        private void OnRefreshClicked(object sender, EventArgs e)
        {
            _pagination.RefreshData();
        }

        private void OnEditClicked(object sender, EventArgs e)
        {
            if (Application.Current != null && Application.Current.MainPage != null)
            {
                if (_selected != null)
                {
                    var manager = new PopupManager();
                    var data = _selected.ToViewModel();
                    manager.ShowPopup(new FormSatuanDasarBarang(data));
                }
                
            }
        }

        private void OnRightClick(object sender, DataGridCellTappedEventArgs e)
        {
            _selected = e.RowData as BasicUnitDto;
            if (_selected != null) Console.WriteLine($"Satuan Dasar : {_selected.nama}");
        }
    }
}

