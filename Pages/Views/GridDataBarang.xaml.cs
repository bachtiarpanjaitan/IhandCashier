
using IhandCashier.Bepe.Components;
using IhandCashier.Bepe.Constants;
using IhandCashier.Bepe.Providers;
using IhandCashier.Bepe.Services;
using IhandCashier.Bepe.Types;
using Syncfusion.Maui.DataGrid;

namespace IhandCashier.Pages.Views
{
    public partial class GridDataBarang : Pagination
    {
        private const string ModuleName = "Data Barang";
        ProductService _service  = ServiceLocator.ServiceProvider.GetService<ProductService>();
        public GridDataBarang()
        {
            InitializeComponent();
            FilterOne.Initialize(ModuleName);
            DatagridProvider.Reset();
            resetPagination();
            List<ColumnType> columns = [
                new ColumnType { Type = ColumnTypes.Numeric,MappingName = "id", ColumnMode = ColumnWidthMode.FitByCell ,HeaderText = "ID", Format = "N0" },
                new ColumnType { Type = ColumnTypes.Text, MappingName = "kode", HeaderText = "KODE" },
                new ColumnType { Type = ColumnTypes.Text, MappingName = "nama", HeaderText = "NAMA BARANG"},
                new ColumnType { Type = ColumnTypes.Text, MappingName = "gambar", HeaderText = "GAMBAR"}
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
}

