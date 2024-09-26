using IhandCashier.Bepe.Components;
using IhandCashier.Bepe.Constants;
using IhandCashier.Bepe.Database;
using IhandCashier.Bepe.Dtos;
using IhandCashier.Bepe.Helpers;
using IhandCashier.Core.Maui.Providers;
using IhandCashier.Bepe.Services;
using IhandCashier.Bepe.Types;
using IhandCashier.Pages.Forms;
using Syncfusion.Maui.DataGrid;

namespace IhandCashier.Pages.Views;

public partial class GridDataKasir
{
	private const string ModuleName = "Data Kasir";
	UserService _service  = ServiceLocator.ServiceProvider.GetService<UserService>();
	private Pagination<UserDto> _pagination;
	UserDto _selectedProduct;
	public GridDataKasir()
	{
		InitializeComponent();
		
		FilterOne.Initialize(ModuleName);
            
		ResetView();
		List<ColumnType> columns = [
			new ColumnType { Type = ColumnTypes.Numeric,TextAlignment = TextAlignment.Center,MappingName = "id", ColumnMode = ColumnWidthMode.FitByCell ,HeaderText = "ID", Format = "N0" },
			new ColumnType { Type = ColumnTypes.Text, MappingName = "username", HeaderText = "USERNAME" },
			new ColumnType { Type = ColumnTypes.Text, MappingName = "nama", HeaderText = "NAMA"},
			new ColumnType { Type = ColumnTypes.Text, MappingName = "email", HeaderText = "EMAIL"},
			new ColumnType { Type = ColumnTypes.Text, MappingName = "avatar", HeaderText = "TELEPON"},
			new ColumnType { Type = ColumnTypes.Text, MappingName = "status", HeaderText = "STATUS"}
		];
		foreach (var c in columns.Select(col => col.Create())) DatagridProvider.DataGrid.Columns.Add(c);
		Content = DatagridProvider.LayoutDatagrid;
    
		DatagridProvider.ShowLoader();
		Device.BeginInvokeOnMainThread(() =>
		{
			_pagination = new Pagination<UserDto>(_service, typeof(FilterOne));
			DatagridProvider.AddDatagridCellHandler(OnClick);
			DatagridProvider.HideLoader();
		});
    }

	private void OnClick(object sender, DataGridCellTappedEventArgs e)
	{
		_selectedProduct = e.RowData as UserDto;
		if (_selectedProduct != null) Console.WriteLine($"Barang : {_selectedProduct.username}");
	}
}
