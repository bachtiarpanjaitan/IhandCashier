using IhandCashier.Bepe.Configs;
using IhandCashier.Bepe.Types;
using IhandCashier.Bepe.Services;
using StackLayout = Microsoft.Maui.Controls.Compatibility.StackLayout;

namespace IhandCashier.Bepe.Helpers
{
	public class ContentLayoutTwoColumn
	{
        
        public Grid grid { get; private set; }
        private Grid ContentPlaceholder;
        AppSetting _settings = AppSettingService.Settings;
        public ContentLayoutTwoColumn()
        {
            grid = new Grid
            {
                ColumnDefinitions = {
                new ColumnDefinition { Width = new GridLength(AppConfig.SIDE_MENU_WIDTH) },
                new ColumnDefinition { Width = 5 },
                new ColumnDefinition { Width = GridLength.Star }
            },
                RowDefinitions =
            {
                new RowDefinition { Height = GridLength.Star }
            },

            };
            ContentPlaceholder = new Grid
            {
                Children =
                {
                    new StackLayout()
                    {
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center,
                        Children =
                        {
                            new Image(){
                                Source = "logo.icns",
                                WidthRequest = 100,
                                HeightRequest = 100,
                                HorizontalOptions = LayoutOptions.Center,
                                VerticalOptions = LayoutOptions.Center
                            },
                            new Label(){ HorizontalTextAlignment = TextAlignment.Center, FontSize = 20, FontAttributes = FontAttributes.Bold,Text = _settings.Perusahaan },
                            new Label(){ Text = "Klik menu disamping untuk membuka data."}
                        }
                    }
                }
            };
            grid.Add(ContentPlaceholder, 2, 0);
        }

        public void SetSideMenu(VerticalStackLayout sm)
        {
            grid.Add(sm, 0, 0);
        }

        public void SetContent(ContentView c)
        {
            ContentPlaceholder.Children.Clear();
            ContentPlaceholder.Children.Add(c);
        }

        public Frame GenerateFrame()
        {
            var splitter = new BoxView { Color = Color.FromArgb("#592f02"), WidthRequest = 2 };
            grid.Add(splitter,1,0);
            var frame = new Frame
            {
                Content = grid,
                BackgroundColor = Colors.Transparent,
                BorderColor = Color.FromArgb("#592f02"),
                CornerRadius = 10,
                Padding = 0,
                Margin = new Thickness(0,0,0,5),
                HasShadow = false
            };

            return frame;
        }
	}
}

