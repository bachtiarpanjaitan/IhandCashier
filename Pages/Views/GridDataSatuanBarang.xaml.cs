using IhandCashier.Bepe.Components;
using IhandCashier.Bepe.Constants;
using IhandCashier.Bepe.Entities;
using IhandCashier.Bepe.Providers;
using IhandCashier.Bepe.Types;
namespace IhandCashier.Pages.Views;

public partial class GridDataSatuanBarang : ContentView
{
	private String ModuleName = "Data Satuan Barang";
	public GridDataSatuanBarang()
	{
		InitializeComponent();

		new Pagination<Unit>();
		List<ColumnType> columns = [
			new ColumnType { Type = ColumnTypes.Text, MappingName = "id", Width = 100, HeaderText = "ID", Format = "N0" },
			new ColumnType { Type = ColumnTypes.Numeric, MappingName = "basic_unit_id", HeaderText = "BUI"},
			new ColumnType { Type = ColumnTypes.Text, MappingName = "kode_satuan", HeaderText = "KODE SATUAN"},
			new ColumnType { Type = ColumnTypes.Text, MappingName = "nama", HeaderText = "NAMA SATUAN"},
			new ColumnType { Type = ColumnTypes.Text, MappingName = "konversi", HeaderText = "NILAI KONVERSI", Format = "N0"}
		];
            
		foreach (var c in columns.Select(col => col.Create())) DatagridProvider.DataGrid.Columns.Add(c);
		FilterOne<Product>.Initialize(ModuleName);
		Content = DatagridProvider.LayoutDatagrid;
	}
}
