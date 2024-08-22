using IhandCashier.Bepe.Components;
using IhandCashier.Bepe.Constants;
using IhandCashier.Bepe.Database;
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
	public GridDataSatuanBarang()
	{
		InitializeComponent();
		FilterOne.Initialize(ModuleName);
		DatagridProvider.Reset();
		List<ColumnType> columns = [
			new ColumnType { Type = ColumnTypes.Numeric,TextAlignment = TextAlignment.Center, MappingName = "id",ColumnMode = ColumnWidthMode.FitByCell , HeaderText = "ID", Format = "N0" },
			new ColumnType { Type = ColumnTypes.Text, MappingName = "kode_satuan", HeaderText = "KODE SATUAN"},
			new ColumnType { Type = ColumnTypes.Text, MappingName = "nama", HeaderText = "NAMA SATUAN"},
			new ColumnType { Type = ColumnTypes.Text, MappingName = "BasicUnit.nama", HeaderText = "SATUAN DASAR"},
			new ColumnType { Type = ColumnTypes.Numeric, TextAlignment = TextAlignment.End ,MappingName = "konversi", HeaderText = "NILAI KONVERSI", Format = "N0"}
		];
            
		foreach (var c in columns.Select(col => col.Create())) DatagridProvider.DataGrid.Columns.Add(c);
		
		_ = new Pagination<Unit>(_service, typeof(FilterOne));
		Content = DatagridProvider.LayoutDatagrid;
	}
	
	
	
}
