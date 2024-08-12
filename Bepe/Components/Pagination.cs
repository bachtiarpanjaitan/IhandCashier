
using System.ComponentModel;
using System.Runtime.CompilerServices;
using IhandCashier.Bepe.Configs;
using IhandCashier.Bepe.Providers;

namespace IhandCashier.Bepe.Components
{
    public class Pagination<T> : INotifyPropertyChanged where T : class
    {
        private int _pageIndex = 0;
        private readonly int _pageSize = 0;
        private int _total = 0;
        private int _pageCount = 0;
        private Task<List<T>> _pagedData;
        public Task<List<T>> PagedData
        {
            get => _pagedData;
            private set
            {
                _pagedData = value;
                OnPropertyChanged(nameof(PagedData));
                UpdatePageLabel();
            }
        }
        
        public Pagination()
        {
            _pageSize = AppConfig.DATA_ROW_PER_PAGE;
            _ = UpdatePagedData();
            UpdatePageLabel();
            DatagridProvider.PrevButton.Clicked += OnPrevButtonClicked;
            DatagridProvider.NextButton.Clicked += OnNextButtonClicked;
            DatagridProvider.DataGrid.Columns.Clear();
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
        
        public async Task UpdatePagedData()
        {
            PagedData = Task.FromResult(await DatagridProvider.PaginationHandler.Limit(_pageIndex).Take(_pageSize).GetAsync<T>());
            _total = DatagridProvider.PaginationHandler.GetTotalAsync<T>();
                
            var result = (double)_total / _pageSize;
            _pageCount = (int)Math.Ceiling(result);
            DatagridProvider.DataGrid.ItemsSource = PagedData.Result;
        }
        
        private void UpdatePageLabel()
        {
            DatagridProvider.PageLabel.Text = $"{_pageIndex + 1}/{_pageCount}";
            DatagridProvider.TotalLabel.Text = $"Total {_total} data";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
    }
}

