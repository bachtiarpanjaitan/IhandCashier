using CommunityToolkit.Maui.Views;

namespace IhandCashier.Bepe.Helpers;

public class Form : Popup
{
    public Form()
    {
        CanBeDismissedByTappingOutsideOfPopup = false;
        Color = Colors.Transparent;
    }

    public Button BtnClose = new() { Text = "Batal", Margin = new Thickness(10, 0), Padding = new Thickness(15,10) };
    public Button BtnSave = new() { Text = "Simpan", Margin = new Thickness(10, 0), Padding = new Thickness(15,10) };
    
    private Grid grid = new()
    {
        RowDefinitions =
        {
            new RowDefinition(height: 50),
            new RowDefinition(height: GridLength.Star),
            new RowDefinition(height: 50)
        }
    };

    private HorizontalStackLayout footer  = new()
    {
        HorizontalOptions = LayoutOptions.End,
        Padding = new Thickness(10),
    };

    private Label header = new Label()
    {
        FontSize = 20,
        Padding = new Thickness(0,20,0,5),
        FontAttributes = FontAttributes.Bold,
        VerticalOptions = LayoutOptions.Center,
        HorizontalOptions = LayoutOptions.Center
    };

    public Form SetSize(int width, int height)
    {
        Size = new Size(width, height);
        return this;
    }

    public Form SetTitle(string title)
    {
        header.Text = title;
        return this;
    }
    
    public void Create(View content)
    {
        footer.Add(BtnClose);
        footer.Add(BtnSave);
        
        grid.Add(header,0,0);
        grid.Add(content,0,1);
        grid.Add(footer,0,2);
        Content = grid;
    }
}