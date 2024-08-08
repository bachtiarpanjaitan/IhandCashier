
namespace IhandCashier.Pages.Views;

using System.Diagnostics;
using IhandCashier.Bepe.Repositories;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Maui.Controls;
using Syncfusion.Maui.DataGrid;

public partial class GridDataBarang : ContentView
{
    //Grid grid = new()
    //{
    //    ColumnDefinitions = {
    //            new ColumnDefinition { Width = GridLength.Star }
    //    },
    //    RowDefinitions = {
    //            new RowDefinition { Height = GridLength.Star }, // Tabel
    //    },
    //    Padding = new Thickness(5),
    //};

    public GridDataBarang()
    {
        Debug.WriteLine("Initializing GridDataBarang...");
        InitializeComponent();
        //SfDataGrid table = SyncGenerateTable();
        var frame = new Frame { BackgroundColor = Colors.Red, Content = new Label { Text = " Testing View" }, Margin = new Thickness(5) };
        Content = frame;
    }

    //private SfDataGrid SyncGenerateTable()
    //{
    //    ProductRepository vm = new ProductRepository();
    //    var dataGrid = new SfDataGrid
    //    {
    //        HeaderRowHeight = 40,
    //        CanUseViewFilter = true,
    //        RowHeight = 40,
    //        ItemsSource = vm.productInfoCollection,
    //        BackgroundColor = Colors.Black,
    //        WidthRequest = 300,  // Set ukuran lebar untuk debugging
    //        HeightRequest = 500  // Set ukuran tinggi untuk debugging
    //    };
    //    Debug.WriteLine($"DataGrid Rows Count: {vm.productInfoCollection.Count}");
    //    return dataGrid;
    //}
        
}
