using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using Grid = Microsoft.Maui.Controls.Grid;

namespace IhandCashier.Bepe.Components;

public class ImagePreviewPopup : Popup
{
    private Button _btnClose = new()
    {
        HorizontalOptions = LayoutOptions.End,
        VerticalOptions = LayoutOptions.Center,
        Text = "Tutup",
        WidthRequest = 100,
        Margin = new Thickness(5, 0)
    };
    
    private Grid grid = new()
    {
        RowDefinitions =
        {
            new RowDefinition { Height = GridLength.Auto},
            new RowDefinition { Height = 50}
        },
        Padding = 10
    };
    
    private Image image = new()
    {
        HorizontalOptions = LayoutOptions.End,
        VerticalOptions = LayoutOptions.Center,
        BackgroundColor = Colors.Transparent,
        Opacity = 0.9
    };
    
    public ImagePreviewPopup()
    {
        CanBeDismissedByTappingOutsideOfPopup = false;
       _btnClose.Clicked += (sender, args) =>
       {
           image.Source = null;
           Close(true);
       };
       
       Color = Colors.Transparent;
       grid.Add(image,0,0);
       grid.Add(_btnClose,0,1);
       Content = grid;
    }
    
    public void SetImage(string path, int width = 200, int height = 200)
    {
        image.Source = null;
        image.WidthRequest = width;
        image.HeightRequest = height;
        image.Source = ImageSource.FromFile(path);
       
    }
    
    public void ResetImage()
    {
        image.Source = null;
    }
    
}