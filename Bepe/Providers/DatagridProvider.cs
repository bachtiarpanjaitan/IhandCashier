using System.Collections.Specialized;
using Syncfusion.Maui.DataGrid;

namespace IhandCashier.Bepe.Providers
{
    public static class DatagridProvider
    {
        private static EventHandler _PrevClickedHandlerRef;
        private static EventHandler _NextClickedHandlerRef;
        public static readonly Button PrevButton = new() {Margin = new Thickness(10, 0),WidthRequest = 150,VerticalOptions = LayoutOptions.Center, Text = "Sebelumnya" };
        public static readonly Button NextButton = new() {Margin = new Thickness(10, 0),WidthRequest = 150,VerticalOptions = LayoutOptions.Center, Text = "Selanjutnya" };
        public static readonly Label PageLabel = new() {VerticalOptions = LayoutOptions.Center,VerticalTextAlignment = TextAlignment.Center, Text = "", Margin = new Thickness(10,0)};
        public static readonly Label TotalLabel = new() {VerticalOptions = LayoutOptions.Center,VerticalTextAlignment = TextAlignment.Center, Text = "", Margin = new Thickness(10, 0)};
        private static readonly Grid ContainerPagination = new()
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

        public static readonly Frame HeaderFrame = new()
        {
            CornerRadius = 5,
            BackgroundColor = Colors.Transparent,
            Margin = new Thickness(5,0),
        };
        
        public static readonly Grid LayoutDatagrid = new()
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

        private static readonly Frame FooterFrame =  new()
        {
            CornerRadius = 5,
            BackgroundColor = Colors.Transparent,
            Margin = new Thickness(5, 0),
        };
        public static SfDataGrid DataGrid { get; set; } = new SfDataGrid
        {
            Margin = new Thickness(5),
            Padding = new Thickness(5),
            AutoGenerateColumnsMode = AutoGenerateColumnsMode.None,
            HeaderGridLinesVisibility = GridLinesVisibility.Both,
            GridLinesVisibility = GridLinesVisibility.Both,
            ColumnWidthMode = ColumnWidthMode.None
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
        
        public static void AddPaginationClickHandlers(EventHandler previousHandler, EventHandler nextHandler)
        {
            if (_PrevClickedHandlerRef != null) PrevButton.Clicked -= _PrevClickedHandlerRef;
            
            if (_NextClickedHandlerRef != null) NextButton.Clicked -= _NextClickedHandlerRef;
            
            _PrevClickedHandlerRef = previousHandler;
            _NextClickedHandlerRef = nextHandler;
            
            PrevButton.Clicked += _PrevClickedHandlerRef;
            NextButton.Clicked += _NextClickedHandlerRef;
        }

        public static void Reset()
        {
           DataGrid.Columns.Clear();
           DataGrid.ItemsSource = null;
        }
        

    }
}
