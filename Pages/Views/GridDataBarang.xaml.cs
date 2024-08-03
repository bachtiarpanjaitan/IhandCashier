
namespace IhandCashier.Pages.Views;
using Basapadi.Datagrid;
using Basapadi.Datagrid.Types;
using Microsoft.Maui.Controls;
using Syncfusion.Maui.DataGrid;
using System.Collections.ObjectModel;

public partial class GridDataBarang : ContentView
{
    Grid grid = new()
    {
        ColumnDefinitions = {
                new ColumnDefinition { Width = GridLength.Star }
        },
        RowDefinitions = {
                new RowDefinition { Height = 35 },   // Toolbar
                new RowDefinition { Height = GridLength.Star }, // Tabel
                new RowDefinition { Height = 35 }    // Pagination
        },
        Padding = 5,
    };

    public GridDataBarang()
    {
        InitializeComponent();
        GenerateFrameWithTable();
    }

    private void GenerateFrameWithTable()
    {
        try
        {
            var topElement = new Frame { HeightRequest=30, CornerRadius=5 };
            var bottomElement = new Frame { HeightRequest=30, CornerRadius=5 };
            var table = GenerateTable();

            grid.Add(topElement, 0, 0);
            grid.Add(table, 0, 1);
            grid.Add(bottomElement, 0, 2);

            Content = grid;
        }catch(Exception e)
        {
            Console.WriteLine("ERRORRR :", e.Message);
        }
    }

    private SfDataGrid SyncGenerateTable()
    {
        var dataGrid = new SfDataGrid
        {
            //ItemsSource = new List<Person>
            //{
            //    new Person { Name = "John", Age = 30 },
            //    new Person { Name = "Jane", Age = 25 },
            //    new Person { Name = "Doe", Age = 40 }
            //},
            BackgroundColor = Colors.White,
            HeaderRowHeight = 40,
            RowHeight = 40
        };

        return dataGrid;
    }

    private ScrollView GenerateTable()
    {

        List<BGridHeader> columns = new List<BGridHeader>
        {
            new BGridHeader() { Label = "Test 1"},
            new BGridHeader() { Label = "Test 2"},
            new BGridHeader() { Label = "Test 3"},
            new BGridHeader() { Label = "Test 4"},
            new BGridHeader() { Label = "Test 5"}
        };
        Datagrid grid = new();

        grid.SetHeader(columns);
        return new ScrollView
        {
            Content = grid.Build(),
            Padding = new Thickness(0,5,0,5),
        };
    }
        
}
