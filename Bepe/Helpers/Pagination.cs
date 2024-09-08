using CommunityToolkit.Maui.Views;
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
        private Type _form;
        
        /// <summary>
        /// Mengelola Pagination data di datagrid.
        /// </summary>
        /// <typeparam name="T">Entity atau DTO.</typeparam>
        /// <param name="dataService">Service Entity</param>
        /// <param name="typeHeader">Header Datagrid yang ingin digunakan</param>
        /// <param name="form">Type Form data yang digunakan pada header</param>
        /// <author>Bachtiar Panjaitan</author>
        public Pagination(IDataService<T> dataService, Type typeHeader, Type form = null){
            ResetDataPagination(); //keep on top
            DatagridProvider.Indicator.IsRunning = true;
            DatagridProvider.Indicator.IsVisible = true;
            _typeHeader = typeHeader;
            _form = form;
            _dataService = dataService;
            _pageIndex = 0;
            _pageSize = AppConfig.DATA_ROW_PER_PAGE;
            _ = UpdatePagedData();
            GetComponentHandler();
            DatagridProvider.AddPaginationClickHandlers(OnPrevButtonClicked, OnNextButtonClicked);
        }

        public void RefreshData()
        {
            DatagridProvider.Indicator.IsRunning = true;
            DatagridProvider.Indicator.IsVisible = true;
            _ = UpdatePagedData();
        }

        private void OnPrevButtonClicked(object sender, EventArgs e)
        {
            if (_pageIndex <= 0) return;
            DatagridProvider.Indicator.IsRunning = true;
            DatagridProvider.Indicator.IsVisible = true;
            _pageIndex--;
            _ = UpdatePagedData();

        }

        private void OnNextButtonClicked(object sender, EventArgs e)
        {
            if ((_pageIndex + 1) >= _pageCount) return;
            DatagridProvider.Indicator.IsRunning = true;
            DatagridProvider.Indicator.IsVisible = true;
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
                    Console.WriteLine($"Error Pagination:: Message : {e.Message}");
                }
            }
            DatagridProvider.Indicator.IsRunning = false;
            DatagridProvider.Indicator.IsVisible = false;
        }

        private async void GetComponentHandler()
        {
            if (_typeHeader == typeof(FilterOne))
            {
                FilterOne.SearchHandler(OnSearchHandler);
                FilterOne.AddFormClickHandler(OnAddFormClicked);
            }
            
        }

        private void OnAddFormClicked(object sender, EventArgs e)
        {
            if (Application.Current != null && Application.Current.MainPage != null)
            {
                if (_form == null) return;
                var manager = new PopupManager();
                manager.ShowPopup(_form);
            }
                
        }

        private void OnSearchHandler(object sender, TextChangedEventArgs e)
        {
            DatagridProvider.Indicator.IsRunning = true;
            DatagridProvider.Indicator.IsVisible = true;
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

