using System.Text.RegularExpressions;
using CommunityToolkit.Maui.Views;
using IhandCashier.Bepe.Types;
using Syncfusion.Maui.DataGrid;
using Syncfusion.Maui.DataSource;

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
        grid.Add(_datagrid,0,0);
        grid.Add(_btnClose,0,1);
        
        _datagrid.AutoGeneratingColumn += datagrid_AutoGeneratingColumn;
        Content = grid;
    }

    private void datagrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        foreach (var column in _datagrid.Columns)
        {
            // Periksa tipe kolom yang digenerate dan terapkan format yang diinginkan
            if (column is DataGridNumericColumn numericColumn)
            {
                // Terapkan format N0 (tanpa desimal)
                numericColumn.Format = "N0";
            }

            column.HeaderText = SplitCamelCase(column.HeaderText);
        }
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