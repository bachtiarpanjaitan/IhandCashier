using IhandCashier.Bepe.Components;
using IhandCashier.Bepe.Configs;
using IhandCashier.Bepe.Interfaces;
using IhandCashier.Core.Maui.Providers;

namespace IhandCashier.Bepe.Helpers
{
    public sealed class Pagination<T>
    {
        private int _pageIndex = 0;
        private int _pageSize = 0;
        private int _total = 0;
        private int _pageCount = 0;
        private string _search = null;
        private static IDataService<T> _dataService = null;
        private Type _typeHeader = null;
        
        public Pagination(IDataService<T> dataService, Type typeHeader)
        {
            ResetDataPagination(); //keep on top
            
            _typeHeader = typeHeader;
            _dataService = dataService;
            _pageIndex = 0;
            _pageSize = AppConfig.DATA_ROW_PER_PAGE;
            _ = UpdatePagedData();
            GetComponentHandler();
            DatagridProvider.AddPaginationClickHandlers(OnPrevButtonClicked, OnNextButtonClicked);
        }
        
        private void OnPrevButtonClicked(object sender, EventArgs e)
        {
            if (_pageIndex <= 0) return;
            _pageIndex--;
            _ = UpdatePagedData();

        }

        private void OnNextButtonClicked(object sender, EventArgs e)
        {
            if ((_pageIndex + 1) >= _pageCount) return;
            _pageIndex++;
            _ = UpdatePagedData();

        }

        private async Task UpdatePagedData()
        {
            _total = _dataService.TotalData();
            if (_total >= 0)
            {
                try
                {
                    var result = (double)_total / _pageSize;
                    _pageCount = (int)Math.Ceiling(result);
                    DatagridProvider.PageLabel.Text = $"{_pageIndex + 1}/{_pageCount}";
                    DatagridProvider.TotalLabel.Text = $"Total {_total} data";
                    DatagridProvider.DataGrid.ItemsSource = await _dataService.GetPagingData(_pageIndex, _pageSize, _search).ConfigureAwait(true);
                    Console.WriteLine($"Data Total {_total} rows.");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error Pagination::UpdatePagedData() : ", e.Message);
                }
            }
        }

        private void GetComponentHandler()
        {
            if (_typeHeader == typeof(FilterOne)) FilterOne.FilterOneHandlers(OnSearchHandler);
            
        }

        private void OnSearchHandler(object sender, TextChangedEventArgs e)
        {
            _search = e.NewTextValue;
            Device.BeginInvokeOnMainThread(() =>
            {
                _ = UpdatePagedData();
            });
        }

        private void ResetDataPagination()
        {
            _total = 0;
            _pageCount = 0;
            _search = null;
            _typeHeader = null;
            _dataService = null;
        }
    }
}

