
using System.Collections.ObjectModel;
using System.Diagnostics;
using IhandCashier.Bepe.Controllers;
using IhandCashier.Bepe.Models;
using IhandCashier.Bepe.Repositories;
using Syncfusion.Maui.DataGrid;

namespace IhandCashier.Pages;

public partial class PageProfile : PageController
{
	public PageProfile()
	{
        InitializeComponent();
        MydataGrid.ItemsSource = getData();
    }

    private SfDataGrid SyncGenerateTable()
    {
        ProductRepository vm = new ProductRepository();
        if (vm == null)
        {
            Debug.WriteLine("BindingContext is not set or is not of type ProductRepository.");
            return null;
        }
        var dataGrid = new SfDataGrid
        {
            HeaderRowHeight = 40,
            CanUseViewFilter = true,
            RowHeight = 40,
            ItemsSource = vm.ProductCollection,
            BackgroundColor = Colors.Black,
            WidthRequest = 300,  // Set ukuran lebar untuk debugging
            HeightRequest = 500  // Set ukuran tinggi untuk debugging
        };
        Debug.WriteLine($"DataGrid Rows Count: {vm.ProductCollection.Count}");

        return dataGrid;
    }

    private ObservableCollection<Product> getData()
    {
        ProductRepository vm = new ProductRepository();
        return vm.ProductCollection;
    }
}
