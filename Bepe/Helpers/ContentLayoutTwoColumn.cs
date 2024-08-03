using System;
using IhandCashier.Bepe.Constants;
using System.Linq;

namespace IhandCashier.Bepe.Helpers
{
	public class ContentLayoutTwoColumn
	{

        public Grid grid { get; private set; }
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
        }

        public void SetSideMenu(VerticalStackLayout sm)
        {
            grid.Add(sm, 0, 0);
        }

        public void SetContent(ContentView c)
        {
            var oc = grid.Children.FirstOrDefault(v => grid.GetRow(v) == 0 && grid.GetColumn(v) == 2);
           
            if (oc != null)
            {
                grid.Children.Remove(oc);
                grid.Add(c, 2, 0);
            } else
            {
                grid.Add(c, 2, 0);
            }
        }

        public ContentView GenerateFrame()
		{
            
            var splitter = new BoxView { Color = (Color)Application.Current.Resources["IcBorderColor"], WidthRequest = 2 };
            grid.Add(splitter,1,0);
            var frame = new Frame
            {
                Content = grid,
                BackgroundColor = Colors.Transparent,
                BorderColor = (Color)Application.Current.Resources["IcBorderColor"],
                CornerRadius = 5,
                Padding = 0,
                Margin = 5,
                HasShadow = false
            };

            return frame;
        }
	}
}

