using System;
using IhandCashier.Bepe.Components;
using IhandCashier.Bepe.Constants;

namespace IhandCashier.Bepe.Helpers
{
	public class ContentLayoutTwoColumn
	{
        Grid grid = new Grid
        {
            ColumnDefinitions = {
                new ColumnDefinition { Width = new GridLength(AppConfig.SIDE_MENU_WIDTH) },
                new ColumnDefinition { Width = 5 },
                new ColumnDefinition { Width = GridLength.Star }
            },
            RowDefinitions =
            {
                new RowDefinition { Height = GridLength.Star }
            }
        };

        private VerticalStackLayout sideView;
        private VerticalStackLayout contentView;


        public ContentLayoutTwoColumn(VerticalStackLayout sideView, VerticalStackLayout contentView)
		{
            this.sideView = sideView;
            this.contentView = contentView;
		}
        public Frame GenerateFrame()
		{
            Grid.SetColumn(sideView, 0);
            Grid.SetRow(sideView, 0);
            grid.Children.Add(sideView);

            var splitter = new BoxView { Color = (Color)Application.Current.Resources["IcBorderColor"], WidthRequest = 2 };
            Grid.SetColumn(splitter, 1);
            Grid.SetRow(splitter, 0);
            grid.Children.Add(splitter);

            Grid.SetColumn(contentView, 2);
            Grid.SetRow(contentView, 0);
            grid.Children.Add(contentView);

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

