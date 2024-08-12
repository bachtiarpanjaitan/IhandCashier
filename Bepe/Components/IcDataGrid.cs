using IhandCashier.Bepe.Configs;
using IhandCashier.Bepe.Types;
using Syncfusion.Maui.DataGrid;

namespace IhandCashier.Bepe.Components
{
    public class IcDataGrid<T> where T : class
    {
        private readonly SfDataGrid _datagrid = new()
        {
            ColumnWidthMode = ColumnWidthMode.Fill,
            Margin = new Thickness(5),
            Padding = new Thickness(5),
            AutoGenerateColumnsMode = AutoGenerateColumnsMode.None,
            HeaderGridLinesVisibility = GridLinesVisibility.Both,
            GridLinesVisibility = GridLinesVisibility.Both,
            RowHeight = 35
        };
        
        private Grid stack = new ()
        {
            ColumnDefinitions = {
                new ColumnDefinition { Width = GridLength.Star }
            },
            RowDefinitions =
            {
                new RowDefinition { Height = 50 },
                new RowDefinition { Height = GridLength.Star },
                new RowDefinition { Height = 50 }
            },
            Padding = new Thickness(5),
            Margin = new Thickness(5),
        };
        
        public IcDataGrid(List<ColumnType> columns, string moduleName)
        {
            foreach (var c in columns.Select(col => col.Create())) _datagrid.Columns.Add(c);
            var pagination = new Pagination<T>(0, AppConfig.DATA_ROW_PER_PAGE, _datagrid);
            var filter = new FilterOne<T>(moduleName);
            var viewPagination = pagination.Build();
            var viewFilter = filter.Build();
            stack.Add(viewFilter,0);
            stack.Add(_datagrid,0,1);
            stack.Add(viewPagination,0,2);
            
        }
        public Grid GetView()
        {
            return stack;
        }
    }
}

