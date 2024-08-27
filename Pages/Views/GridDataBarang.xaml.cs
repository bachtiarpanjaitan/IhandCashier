
using CommunityToolkit.Maui.Views;
using IhandCashier.Bepe.Components;
using IhandCashier.Bepe.Constants;
using IhandCashier.Bepe.Database;
using IhandCashier.Bepe.Dtos;
using IhandCashier.Bepe.Entities;
using IhandCashier.Core.Maui.Providers;
using IhandCashier.Bepe.Services;
using IhandCashier.Bepe.Types;
using IhandCashier.Bepe.Helpers;
using IhandCashier.Bepe.Interfaces;
using IhandCashier.Pages.Forms;
using Syncfusion.Maui.DataGrid;

namespace IhandCashier.Pages.Views
{
    public partial class GridDataBarang
    {
        private const string ModuleName = "Data Barang";
        ProductService _service  = ServiceLocator.ServiceProvider.GetService<ProductService>();
        public GridDataBarang()
        {
            InitializeComponent();
            FilterOne.Initialize(ModuleName);
            DatagridProvider.Reset();
            List<ColumnType> columns = [
                new ColumnType { Type = ColumnTypes.Numeric,MappingName = "id", TextAlignment = TextAlignment.Center,ColumnMode = ColumnWidthMode.FitByCell ,HeaderText = "ID", Format = "N0" },
                new ColumnType { Type = ColumnTypes.Text, MappingName = "kode", HeaderText = "KODE" },
                new ColumnType { Type = ColumnTypes.Text, MappingName = "nama", HeaderText = "NAMA BARANG"},
                new ColumnType { Type = ColumnTypes.Image, MappingName = "resourceGambar", Width = 150, HeaderText = "GAMBAR", ImageHeight = 50, ImageWidth = 50}
            ];
            foreach (var c in columns.Select(col => col.Create())) DatagridProvider.DataGrid.Columns.Add(c);
            _ = new Pagination<ProductDto>(_service, typeof(FilterOne), typeof(FormBarang));
            Content = DatagridProvider.LayoutDatagrid;
            
            
        }
        
        
    }
}

