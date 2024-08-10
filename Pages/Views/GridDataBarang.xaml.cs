
namespace IhandCashier.Pages.Views;

using Bepe.Repositories;
using Microsoft.Maui.Controls;
using Syncfusion.Maui.DataGrid;
public partial class GridDataBarang : ContentView
{
    public GridDataBarang()
    {
        InitializeComponent();
        ProductRepository vm = new();
        SfDataGrid dataGrid = new()
        {
            ItemsSource = vm.ProductCollection,
            ColumnWidthMode = ColumnWidthMode.Fill,
            RowHeight = 30,
            Margin = new Thickness(5),
            Padding = new Thickness(5),
        };
        
        Content = dataGrid;
    }

}
