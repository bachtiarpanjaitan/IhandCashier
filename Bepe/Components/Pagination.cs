
using System.ComponentModel;
using System.Runtime.CompilerServices;
using IhandCashier.Bepe.Helpers;
using Syncfusion.Maui.Core;
using Syncfusion.Maui.DataGrid;

namespace IhandCashier.Bepe.Components
{
    public sealed class Pagination<T> : INotifyPropertyChanged where T : class
    {
        private int _pageIndex = 0;
        private readonly int _pageSize = 0;
        private readonly Button _prevButton = new() {Margin = new Thickness(10, 0),WidthRequest = 150,VerticalOptions = LayoutOptions.Center, Text = "Sebelumnya" };
        private readonly Button _nextButton = new() {Margin = new Thickness(10, 0),WidthRequest = 150,VerticalOptions = LayoutOptions.Center, Text = "Selanjutnya" };
        private readonly Label _pageLabel = new() {VerticalOptions = LayoutOptions.Center,VerticalTextAlignment = TextAlignment.Center, Text = "", Margin = new Thickness(10,0)};
        private readonly Label _totalLabel = new() {VerticalOptions = LayoutOptions.Center,VerticalTextAlignment = TextAlignment.Center, Text = "", Margin = new Thickness(10, 0)};

        private readonly Grid _containerLayout = new()
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
        
        private readonly Frame _frameContainerLayout =  new()
        {
            CornerRadius = 5,
            BackgroundColor = Colors.Transparent,
            Margin = new Thickness(5, 0),
        };

        private int _total = 0;
        private int _pageCount = 0;
        private Task<List<T>> _pagedData;
        private readonly SfDataGrid _dataGrid;
        public Task<List<T>> PagedData
        {
            get => _pagedData;
            private set
            {
                _pagedData = value;
                OnPropertyChanged(nameof(PagedData));
            }
        }
        
        
        public Pagination(int index, int size, SfDataGrid grid)
        {
            _pageIndex = index;
            _pageSize = size;
            _dataGrid = grid;
            _containerLayout.Add(_prevButton,0);
            _containerLayout.Add(_pageLabel,1);
            _containerLayout.Add(_nextButton,2);
            _containerLayout.Add(_totalLabel,3);
        }

        private Frame CreateLayout()
        {
            UpdatePageLabel();
            _frameContainerLayout.Content = _containerLayout;
            _prevButton.Clicked += OnPrevButtonClicked;
            _nextButton.Clicked += OnNextButtonClicked;
            return _frameContainerLayout;
        }

        public Frame Build()
        {
            _ = UpdatePagedData();
            return CreateLayout();
        }

        private void OnPrevButtonClicked(object sender, EventArgs e)
        {
            if (_pageIndex <= 0) return;
            _pageIndex--;
            _ = UpdatePagedData();
        }

        private void OnNextButtonClicked(object sender, EventArgs e)
        {
            if ((_pageIndex + 1) * _pageSize >= _total) return;
            _pageIndex++;
            _ = UpdatePagedData();
        }
        
        private async Task UpdatePagedData()
        {
            var ph = new PaginationHandler(_pageIndex, _pageSize);
            PagedData = Task.FromResult(await ph.GetDataAsync<T>());
            _total = ph.GetTotalDataAsync<T>();
            
            var result = (double)_total / _pageSize;
            _pageCount = (int)Math.Ceiling(result);
            _dataGrid.ItemsSource = PagedData.Result;
            UpdatePageLabel();
        }
        
        private void UpdatePageLabel()
        {
            _pageLabel.Text = $"{_pageIndex + 1}/{_pageCount}";
            _totalLabel.Text = $"Total {_total} data";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
    }
}

