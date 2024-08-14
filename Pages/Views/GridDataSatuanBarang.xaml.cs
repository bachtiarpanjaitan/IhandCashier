using IhandCashier.Bepe.Components;
using IhandCashier.Bepe.Constants;
using IhandCashier.Bepe.Providers;
using IhandCashier.Bepe.Services;
using IhandCashier.Bepe.Types;
using Syncfusion.Maui.DataGrid;

namespace IhandCashier.Pages.Views;

public partial class GridDataSatuanBarang : Pagination
{
	private const string ModuleName = "Data Satuan Barang";
	UnitService _service  = ServiceLocator.ServiceProvider.GetService<UnitService>();
	public GridDataSatuanBarang()
	{
		InitializeComponent();
		FilterOne.Initialize(ModuleName);
		DatagridProvider.Reset();
		resetPagination();
		List<ColumnType> columns = [
			new ColumnType { Type = ColumnTypes.Numeric, MappingName = "id",ColumnMode = ColumnWidthMode.FitByCell , HeaderText = "ID", Format = "N0" },
			new ColumnType { Type = ColumnTypes.Numeric, MappingName = "basic_unit_id", HeaderText = "BUI"},
			new ColumnType { Type = ColumnTypes.Text, MappingName = "kode_satuan", HeaderText = "KODE SATUAN"},
			new ColumnType { Type = ColumnTypes.Text, MappingName = "nama", HeaderText = "NAMA SATUAN"},
			new ColumnType { Type = ColumnTypes.Text, MappingName = "konversi", HeaderText = "NILAI KONVERSI", Format = "N0"}
		];
            
		foreach (var c in columns.Select(col => col.Create())) DatagridProvider.DataGrid.Columns.Add(c);
		DatagridProvider.AddClickHandlers(OnPrevButtonClicked, OnNextButtonClicked);
		Content = DatagridProvider.LayoutDatagrid;
		UpdatePagedData();
	}
	
	
	public async Task UpdatePagedData()
	{
		if (Total >= 0)
		{
			Total = _service.TotalData();
			var result = (double)Total / PageSize;
			PageCount = (int)Math.Ceiling(result);
			DatagridProvider.DataGrid.ItemsSource =  _service.GetPagingData(PageIndex, PageSize).Result;
			DatagridProvider.PageLabel.Text = $"{PageIndex + 1}/{PageCount}";
			DatagridProvider.TotalLabel.Text = $"Total {Total} data";
		}
	}
        
	private void OnPrevButtonClicked(object sender, EventArgs e)
	{
		if (PageIndex > 0)
		{
			PageIndex--;
			_ = UpdatePagedData();
		}
           
	}

	private void OnNextButtonClicked(object sender, EventArgs e)
	{
		if ((PageIndex +1) < PageCount)
		{
			PageIndex++;
			_ = UpdatePagedData();
		}
           
	}
	
	private void resetPagination()
	{
		Total = 0;
		PageCount = 0;
	}
}
