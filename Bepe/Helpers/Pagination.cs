using IhandCashier.Bepe.Configs;
using IhandCashier.Bepe.Interfaces;
using IhandCashier.Bepe.Providers;

namespace IhandCashier.Bepe.Helpers
{
    public class Pagination<T>
    {
        private int _pageIndex = 0;
        private int _pageSize = 0;
        private int _total = 0;
        private int _pageCount = 0;
        private static IDataService<T> _dataService;
        public Pagination(IDataService<T> dataService)
        {
            _dataService = dataService;
            _pageIndex = 0;
            _pageSize = AppConfig.DATA_ROW_PER_PAGE;
            ResetDataPagination();
            _ = UpdatePagedData();
            DatagridProvider.AddClickHandlers(OnPrevButtonClicked, OnNextButtonClicked);
        }
        
        private void OnPrevButtonClicked(object sender, EventArgs e)
        {
            if (_pageIndex > 0)
            {
                _pageIndex--;
                _ = UpdatePagedData();
            }
           
        }

        private void OnNextButtonClicked(object sender, EventArgs e)
        {
            if ((_pageIndex +1) < _pageCount)
            {
                _pageIndex++;
                _ = UpdatePagedData();
            }
           
        }
        
        public async Task UpdatePagedData()
        {
            if (_total >= 0)
            {
                _total = _dataService.TotalData();
                var result = (double)_total / _pageSize;
                _pageCount = (int)Math.Ceiling(result);
                DatagridProvider.DataGrid.ItemsSource = await _dataService.GetPagingData(_pageIndex, _pageSize).ConfigureAwait(true);
                DatagridProvider.PageLabel.Text = $"{_pageIndex + 1}/{_pageCount}";
                DatagridProvider.TotalLabel.Text = $"Total {_total} data";
            }
        }

        private void ResetDataPagination()
        {
            _total = 0;
            _pageCount = 0;
        }
    }
}

