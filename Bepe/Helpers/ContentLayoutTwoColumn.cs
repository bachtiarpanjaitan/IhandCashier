using System;
using IhandCashier.Bepe.Configs;
using System.Linq;

namespace IhandCashier.Bepe.Helpers
{
	public class ContentLayoutTwoColumn
	{

        public Grid grid { get; private set; }
        private Grid ContentPlaceholder;
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

            ContentPlaceholder = new Grid();
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
            
            var splitter = new BoxView { Color = (Color) Application.Current.Resources["IcBorderColor"], WidthRequest = 2 };
            grid.Add(splitter,1,0);
            var frame = new Frame
            {
                Content = grid,
                BackgroundColor = Colors.Transparent,
                BorderColor = (Color)Application.Current.Resources["IcBorderColor"],
                CornerRadius = 5,
                Padding = 0,
                Margin = new Thickness(0,0,0,5),
                HasShadow = false
            };

            return frame;
        }
	}
}

