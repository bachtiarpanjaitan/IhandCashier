
using IhandCashier.Bepe.Components;
using IhandCashier.Bepe.Entities;
using Syncfusion.Maui.DataGrid;

namespace IhandCashier.Pages.Views
{
    public partial class GridDataBarang : ContentView
    {
        public GridDataBarang()
        {
            InitializeComponent();
            SfDataGrid dataGrid = new()
            {
                ColumnWidthMode = ColumnWidthMode.Fill,
                RowHeight = 35,
                Margin = new Thickness(5),
                Padding = new Thickness(5),
            };
            var pagination = new Pagination<Product>(0, 20);
            pagination.SetDataGrid(dataGrid);
        
            var grid = new Grid
            {
                ColumnDefinitions = {
                    new ColumnDefinition { Width = GridLength.Star }
                },
                RowDefinitions =
                {
                    new RowDefinition { Height = GridLength.Star },
                    new RowDefinition { Height = 40 }
                },
            };
            grid.Add(dataGrid,0,0);
            grid.Add(pagination.Build(),0,1);
        
            Content = grid;
        }

    }
}

