using IhandCashier.Bepe.Constants;
using IhandCashier.Bepe.Helpers;
using IhandCashier.Bepe.Types;
using Syncfusion.Maui.DataGrid;

namespace IhandCashier.Bepe.Providers
{
    public static class DatagridProvider
    {
        public readonly static Button PrevButton = new() {Margin = new Thickness(10, 0),WidthRequest = 150,VerticalOptions = LayoutOptions.Center, Text = "Sebelumnya" };
        public readonly static Button NextButton = new() {Margin = new Thickness(10, 0),WidthRequest = 150,VerticalOptions = LayoutOptions.Center, Text = "Selanjutnya" };
        public readonly static Label PageLabel = new() {VerticalOptions = LayoutOptions.Center,VerticalTextAlignment = TextAlignment.Center, Text = "", Margin = new Thickness(10,0)};
        public readonly static Label TotalLabel = new() {VerticalOptions = LayoutOptions.Center,VerticalTextAlignment = TextAlignment.Center, Text = "", Margin = new Thickness(10, 0)};
        public readonly static PaginationHandler PaginationHandler = new();
        private readonly static Grid ContainerPagination = new()
        {
            ColumnDefinitions =
            {
                new ColumnDefinition { Width = GridLength.Auto }, 
                new ColumnDefinition { Width = GridLength.Auto }, 
                new ColumnDefinition { Width = GridLength.Auto },
                new ColumnDefinition { Width = GridLength.Auto } 
            },
            HorizontalOptions = LayoutOptions.Center
        };

        public readonly static Frame HeaderFrame = new()
        {
            CornerRadius = 5,
            BackgroundColor = Colors.Transparent,
            Margin = new Thickness(5,0),
        };
        
        public readonly static Grid LayoutDatagrid = new()
        {
            ColumnDefinitions = { new ColumnDefinition { Width = GridLength.Star }},
            Padding = new Thickness(5),
            Margin = new Thickness(5),
            RowDefinitions =
            {
                new RowDefinition { Height = 50 },
                new RowDefinition { Height = GridLength.Star },
                new RowDefinition { Height = 50 }
            }
        };

        private readonly static Frame FooterFrame =  new()
        {
            CornerRadius = 5,
            BackgroundColor = Colors.Transparent,
            Margin = new Thickness(5, 0),
        };
        public static SfDataGrid DataGrid { get; } = new SfDataGrid
        {
            ColumnWidthMode = ColumnWidthMode.Fill,
            Margin = new Thickness(5),
            Padding = new Thickness(5),
            AutoGenerateColumnsMode = AutoGenerateColumnsMode.None,
            HeaderGridLinesVisibility = GridLinesVisibility.Both,
            GridLinesVisibility = GridLinesVisibility.Both
        };
        

        public static void Initialize()
        {
           ContainerPagination.Add(PrevButton,0);
           ContainerPagination.Add(PageLabel,1);
           ContainerPagination.Add(NextButton,2);
           ContainerPagination.Add(TotalLabel,3);
           FooterFrame.Content = ContainerPagination;
            
            LayoutDatagrid.Add(HeaderFrame,0,0);
            LayoutDatagrid.Add(DataGrid,0,1);
            LayoutDatagrid.Add(FooterFrame,0,2);

        }
        

    }
}
