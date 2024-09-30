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

namespace IhandCashier.Pages.Views;

public partial class GridDataSatuanBarang
{
	private const string ModuleName = "Data Satuan Barang";
	UnitService _service  = ServiceLocator.ServiceProvider.GetService<UnitService>();
	private Pagination<UnitDto> _pagination;
	UnitDto _selected;
	public GridDataSatuanBarang()
	{
		InitializeComponent();
		FilterOne.Initialize(ModuleName);
		ResetView();
		List<ColumnType> columns = [
			new ColumnType { Type = ColumnTypes.Numeric,TextAlignment = TextAlignment.Center, MappingName = "id",ColumnMode = ColumnWidthMode.FitByCell , HeaderText = "ID", Format = "N0" },
			new ColumnType { Type = ColumnTypes.Text, MappingName = "kode_satuan", HeaderText = "KODE SATUAN"},
			new ColumnType { Type = ColumnTypes.Text, MappingName = "nama", HeaderText = "NAMA SATUAN"},
			new ColumnType { Type = ColumnTypes.Text, MappingName = "BasicUnit.nama", HeaderText = "SATUAN DASAR"},
			new ColumnType { Type = ColumnTypes.Numeric, TextAlignment = TextAlignment.End ,MappingName = "konversi", HeaderText = "NILAI KONVERSI", Format = "N0"}
		];
            
		foreach (var c in columns.Select(col => col.Create())) DatagridProvider.DataGrid.Columns.Add(c);
		Content = DatagridProvider.LayoutDatagrid;
    
		DatagridProvider.ShowLoader();
		Device.BeginInvokeOnMainThread(() =>
		{
			_pagination = new Pagination<UnitDto>(_service, typeof(FilterOne), typeof(FormSatuanBarang));
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
		_selected = dataGridCellTappedEventArgs.RowData as UnitDto;
		if (_selected != null) Console.WriteLine($"Satuan : {_selected.kode_satuan}");
	}
	
	private async  void OnDeleteClicked(object sender, EventArgs e)
	{
		bool accept = await Application.Current.MainPage.DisplayAlert($"Hapus Satuan Barang", $"Anda yakin menghapus satuan {_selected.kode_satuan}?.", "Hapus", "Batal");
		if (accept)
		{
			try
			{
				await _service.DeleteAsync(_selected.ToEntity());
				Application.Current.MainPage.DisplayAlert("Berhasil", "Satuan berhasil dihapus", "OK");
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
				manager.ShowPopup(new FormSatuanBarang(data));
			}
                
		}
	}

	private void OnRefreshClicked(object sender, EventArgs e)
	{
		_pagination.RefreshData();
	}
}
