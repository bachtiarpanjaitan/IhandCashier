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
    public ImagePreviewPopup()
    {
       _btnClose.Clicked += (sender, args) =>
       {
           Close(true);
       };
       
       Color = Colors.Transparent;
    }
    
    public void SetImage(ImageSource imageSource, int width = 200, int height = 200)
    {
        Grid grid = new()
        {
            RowDefinitions =
            {
                new RowDefinition { Height = GridLength.Auto},
                new RowDefinition { Height = 50}
            },
            Padding = 10
        };
        grid.Add(new Image
        {
            HorizontalOptions = LayoutOptions.End,
            VerticalOptions = LayoutOptions.Center,
            Source = imageSource,
            WidthRequest = width,
            HeightRequest = height,
            BackgroundColor = Colors.Transparent,
            Opacity = 0.9
        },0,0);
        grid.Add(_btnClose,0,1);
        Content = grid;
    }
    
}