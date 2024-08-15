using IhandCashier.Bepe.Components;
using IhandCashier.Bepe.Constants;
using IhandCashier.Bepe.Database;
using IhandCashier.Bepe.Entities;
using IhandCashier.Bepe.Helpers;
using IhandCashier.Bepe.Providers;
using IhandCashier.Bepe.Services;
using IhandCashier.Bepe.Types;
using Syncfusion.Maui.DataGrid;

namespace IhandCashier.Pages.Views;

public partial class GridDataKasir : ContentView
{
	private const string ModuleName = "Data Kasir";
	UserService _service  = ServiceLocator.ServiceProvider.GetService<UserService>();
	public GridDataKasir()
	{
		InitializeComponent();
		
		FilterOne.Initialize(ModuleName);
            
		DatagridProvider.Reset();
		List<ColumnType> columns = [
			new ColumnType { Type = ColumnTypes.Numeric,MappingName = "id", ColumnMode = ColumnWidthMode.FitByCell ,HeaderText = "ID", Format = "N0" },
			new ColumnType { Type = ColumnTypes.Text, MappingName = "username", HeaderText = "USERNAME" },
			new ColumnType { Type = ColumnTypes.Text, MappingName = "nama", HeaderText = "NAMA"},
			new ColumnType { Type = ColumnTypes.Text, MappingName = "email", HeaderText = "EMAIL"},
			new ColumnType { Type = ColumnTypes.Text, MappingName = "avatar", HeaderText = "TELEPON"},
			new ColumnType { Type = ColumnTypes.Text, MappingName = "is_active", HeaderText = "AKTIF"}
		];
		foreach (var c in columns.Select(col => col.Create())) DatagridProvider.DataGrid.Columns.Add(c);
		_ = new Pagination<User>(_service, typeof(FilterOne));
		Content = DatagridProvider.LayoutDatagrid;
    }
}
