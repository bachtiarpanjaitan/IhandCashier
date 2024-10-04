using System.Globalization;
using System.Text.RegularExpressions;
using CommunityToolkit.Maui.Views;
using Syncfusion.Maui.DataGrid;

namespace IhandCashier.Bepe.Components;

public class DetailPreviewPopup : Popup
{
    private Button _btnClose = new()
    {
        HorizontalOptions = LayoutOptions.End,
        VerticalOptions = LayoutOptions.Center,
        Text = "Tutup",
        WidthRequest = 100,
        Margin = new Thickness(5, 0)
    };
    public DetailPreviewPopup()
    {
        _btnClose.Clicked += (sender, args) =>
        {
            _datagrid.ItemsSource = null;
            Close(true);
        };
       
        Color = Colors.Transparent;
    }
    
    private SfDataGrid _datagrid = new ()
    {
        Margin = new Thickness(5),
        Padding = new Thickness(5),
        ColumnWidthMode = ColumnWidthMode.Fill,
        HeaderGridLinesVisibility = GridLinesVisibility.Both,
        GridLinesVisibility = GridLinesVisibility.Both,
        AutoGenerateColumnsMode = AutoGenerateColumnsMode.ResetAll,
        DefaultStyle =
        {
            CurrentRowHighlightColor = Colors.Bisque,
            CurrentCellBorderColor = Colors.Bisque,
            AlternateRowBackground = Colors.Beige
        },
        AllowDraggingColumn = true,
        AllowResizingColumns = true,
        AllowGroupExpandCollapse = true
    };
    
    public void SetData(object data)
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
        
        _datagrid.ItemsSource = data;
        grid.Add(_datagrid,0);
        grid.Add(_btnClose,0,1);
        _datagrid.AutoGeneratingColumn += (sender, args) =>
        {
            if (args.Column is DataGridNumericColumn column)
            {
                if(column.MappingName.ToLower().Contains("harga") || column.MappingName.ToLower().Contains("total"))
                {
                    column.Format = "C2";
                    column.CultureInfo = new CultureInfo("id-ID");
                }
                else column.Format = "N0";
            }

            args.Column.HeaderText = SplitCamelCase(args.Column.HeaderText);
        };
        
        Content = grid;
    }

    public static string SplitCamelCase(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }
        
        // Regex to insert space before each uppercase letter except the first one
        string pattern = @"(?<!^)(?=[A-Z])";
        string replacement = " ";
        
        return Regex.Replace(input, pattern, replacement);
    }
}