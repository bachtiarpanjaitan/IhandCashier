using IhandCashier.Bepe.Types;
using Microsoft.Maui.Controls;
using Syncfusion.Maui.DataGrid;

namespace IhandCashier.Bepe.Components
{
    public class IcDataGrid<T> where T : class
    {
        
        private SfDataGrid datagrid = new()
        {
            ColumnWidthMode = ColumnWidthMode.Fill,
            Margin = new Thickness(5),
            Padding = new Thickness(5),
            AutoGenerateColumnsMode = AutoGenerateColumnsMode.None,
            HeaderGridLinesVisibility = GridLinesVisibility.Both,
            GridLinesVisibility = GridLinesVisibility.Both,
        };
        
        private Grid stack = new ()
        {
            ColumnDefinitions = {
                new ColumnDefinition { Width = GridLength.Star }
            },
            RowDefinitions =
            {
                new RowDefinition { Height = GridLength.Star },
                new RowDefinition { Height = 40 }
            },
            Padding = new Thickness(5),
            Margin = new Thickness(5),
        };
        
        public IcDataGrid(List<ColumnType> columns)
        {
            foreach (var c in columns.Select(col => col.Create())) datagrid.Columns.Add(c);
            var pagination = new Pagination<T>(0, 20, datagrid);
            var viewPagination = pagination.Build();
            stack.Add(datagrid,0,0);
            stack.Add(viewPagination,0,1);
        }
        public Grid GetView()
        {
            return stack;
        }
    }
}

