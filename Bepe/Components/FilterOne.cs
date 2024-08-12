using System.ComponentModel;

namespace IhandCashier.Bepe.Components;

public class FilterOne<T>  where T : class
{
    private readonly string _moduleName;
    private readonly Entry _search = new()
    {
        HorizontalOptions = LayoutOptions.End,
        VerticalOptions = LayoutOptions.Center,
        Placeholder = "Ketik untuk mencari",
        WidthRequest = 250,
        FontSize = 16,
        FontAttributes = FontAttributes.Bold,
        MinimumWidthRequest = 50
    };
    private readonly Button _searchBtn = new()
    {
        HorizontalOptions = LayoutOptions.End,
        VerticalOptions = LayoutOptions.Center,
        Text = "Cari",
        WidthRequest = 100,
        Margin = new Thickness(10, 0)
    };
    private readonly Label _moduleLabel = new()
    {
        Text = "",
        HorizontalOptions = LayoutOptions.Start,
        VerticalOptions = LayoutOptions.Center,
        MinimumWidthRequest = 150,
        FontAttributes = FontAttributes.Bold,
        FontSize = 20
        
    };
    private readonly Grid _grid = new()
    {
        ColumnDefinitions =
        {
            new ColumnDefinition { Width = GridLength.Auto }, // Kolom untuk label modul
            new ColumnDefinition { Width = GridLength.Star }, // Kolom untuk komponen kanan pertama
            new ColumnDefinition { Width = GridLength.Auto } // Kolom untuk komponen kanan kedua
        }
    };
    
    private readonly Frame _frame = new()
    {
        CornerRadius = 5,
        BackgroundColor = Colors.Transparent,
        Margin = new Thickness(5,0),
    };
    
    public event PropertyChangedEventHandler PropertyChanged;
    

    public FilterOne(string moduleName)
    {
        _moduleName = moduleName;
        _grid.Add(_moduleLabel,0);
        _grid.Add(_search,1);
        _grid.Add(_searchBtn,2);
    }

    private Frame CreateLayout()
    {
        _moduleLabel.Text = _moduleName;
        _frame.Content = _grid;
        return _frame;
    }
    
    public Frame Build()
    {
        return CreateLayout();
    }
    
}