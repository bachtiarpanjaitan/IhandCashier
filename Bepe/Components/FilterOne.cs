using System.ComponentModel;
using IhandCashier.Bepe.Providers;

namespace IhandCashier.Bepe.Components;

public static class FilterOne<T>  where T : class
{
    private readonly static Entry Search = new()
    {
        HorizontalOptions = LayoutOptions.End,
        VerticalOptions = LayoutOptions.Center,
        Placeholder = "Ketik untuk mencari",
        WidthRequest = 250,
        FontSize = 16,
        FontAttributes = FontAttributes.Bold,
        MinimumWidthRequest = 50
    };
    private readonly static Button SearchBtn = new()
    {
        HorizontalOptions = LayoutOptions.End,
        VerticalOptions = LayoutOptions.Center,
        Text = "Cari",
        WidthRequest = 100,
        Margin = new Thickness(10, 0)
    };
    private readonly static Label ModuleLabel = new()
    {
        Text = "",
        HorizontalOptions = LayoutOptions.Start,
        VerticalOptions = LayoutOptions.Center,
        MinimumWidthRequest = 150,
        FontAttributes = FontAttributes.Bold,
        FontSize = 20
        
    };
    private readonly static Grid Grid = new()
    {
        ColumnDefinitions =
        {
            new ColumnDefinition { Width = GridLength.Auto }, // Kolom untuk label modul
            new ColumnDefinition { Width = GridLength.Star }, // Kolom untuk komponen kanan pertama
            new ColumnDefinition { Width = GridLength.Auto } // Kolom untuk komponen kanan kedua
        }
    };
    
    public static event PropertyChangedEventHandler PropertyChanged;


    public static void Initialize(string moduleName)
    {
        ModuleLabel.Text = moduleName;
        Grid.Add(ModuleLabel,0);
        Grid.Add(Search,1);
        Grid.Add(SearchBtn,2);
        DatagridProvider.HeaderFrame.Content = Grid;
    }
}