
namespace IhandCashier.Pages.Views;

using System.Diagnostics;
using IhandCashier.Bepe.Repositories;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Maui.Controls;
using Syncfusion.Maui.DataGrid;

public partial class GridDataBarang : ContentView
{
    public GridDataBarang()
    {
        Debug.WriteLine("Initializing GridDataBarang...");
        InitializeComponent();
        ProductRepository vm = new();
        GridBarang.ItemsSource = vm.ProductCollection;
    }

}
