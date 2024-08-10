
using System.ComponentModel;
using System.Runtime.CompilerServices;
using IhandCashier.Bepe.Helpers;
using Syncfusion.Maui.DataGrid;

namespace IhandCashier.Bepe.Components
{
    public class Pagination<T> : INotifyPropertyChanged where T : class
    {
        private int PageIndex = 0;
        private int PageSize = 0;
        private Button prevButton = new Button { Text = "Sebelumnya" };
        private Button nextButton = new Button { Text = "Selanjutnya" };
        private Button pageLabel;
        private Button totalLabel;

        private int Total;
        private int PageCount = 0;
        private Task<List<T>> _PagedData;
        private SfDataGrid _dataGrid;
        public Task<List<T>> PagedData
        {
            get => _PagedData;
            private set
            {
                _PagedData = value;
                OnPropertyChanged(nameof(PagedData));
            }
        }
        
        
        public Pagination(int index, int size)
        {
            PageIndex = index;
            PageSize = size;
        }

        public void SetDataGrid(SfDataGrid grid)
        {
            _dataGrid = grid;
        }

        private StackLayout CreateLayout()
        {
            pageLabel = new Button { Text = $"{PageIndex + 1 }", Margin = new Thickness(10,0,10,0)};
            prevButton.Clicked += OnPrevButtonClicked;
            nextButton.Clicked += OnNextButtonClicked;
            totalLabel = new Button { Text = $"{(PageIndex + 1)}/{PageCount}", Margin = new Thickness(10, 0, 10, 0) };
            
            StackLayout _Layout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Center
            };
            _Layout.Children.Add(prevButton);
            _Layout.Children.Add(pageLabel);
            _Layout.Children.Add(nextButton);
            _Layout.Children.Add(totalLabel);
            _Layout.Margin = new Thickness(0, 0,0,10);

            return _Layout;
        }

        public StackLayout Build()
        {
            _ = UpdatePagedData();
            return CreateLayout();
        }

        private void OnPrevButtonClicked(object sender, EventArgs e)
        {
            if (PageIndex <= 0) return;
            PageIndex--;
            _ = UpdatePagedData();
            UpdatePageLabel();
        }

        private void OnNextButtonClicked(object sender, EventArgs e)
        {
            if ((PageIndex + 1) * PageSize >= Total) return;
            PageIndex++;
            _ = UpdatePagedData();
            UpdatePageLabel();
        }
        
        private async Task UpdatePagedData()
        {
            var ph = new PaginationHandler(PageIndex, PageSize);
            PagedData = Task.FromResult(await ph.GetDataAsync<T>());
            Total = ph.GetTotalDataAsync<T>();
            double result = (double)Total / PageSize;
            PageCount = (int)Math.Ceiling(result);
            _dataGrid.ItemsSource = PagedData.Result;
        }
        
        private void UpdatePageLabel()
        {
            pageLabel.Text = $"{PageIndex + 1}";
            totalLabel.Text = $"{PageIndex + 1}/{PageCount}";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
    }
}

