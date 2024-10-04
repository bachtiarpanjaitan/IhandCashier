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
        BasicUnitDto _selected;
        Pagination<BasicUnitDto> _pagination;
        public GridDataSatuanDasarBarang()
        {
            InitializeComponent();
            FilterOne.Initialize(ModuleName);
            ResetView();
            
            List<ColumnType> columns = [
                new() { Type = ColumnTypes.Numeric,TextAlignment = TextAlignment.Center, MappingName = "id", ColumnMode = ColumnWidthMode.FitByCell , HeaderText = "ID", Format = "N0" },
                new() { Type = ColumnTypes.Text, MappingName = "nama", HeaderText = "NAMA SATUAN"},
            ];
            
            SetDatagridColumns(columns);
            Content = DatagridProvider.LayoutDatagrid;
    
            DatagridProvider.ShowLoader();
            Device.BeginInvokeOnMainThread(() =>
            {
                _pagination = new Pagination<BasicUnitDto>(_service, typeof(FilterOne), typeof(FormSatuanDasarBarang));
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

        private void OnClicked(object sender, DataGridCellTappedEventArgs e)
        {
            _selected = e.RowData as BasicUnitDto;
            if (_selected != null) Console.WriteLine($"Satuan Dasar : {_selected.nama}");
        }
    }
}

