using IhandCashier.Bepe.Configs;
using IhandCashier.Bepe.Database;
using IhandCashier.Bepe.Providers;
using Microsoft.EntityFrameworkCore;

namespace IhandCashier.Bepe.Components
{
    public class Pagination<T> where T : class
    {
        private int _pageIndex = 0;
        private readonly int _pageSize = 0;
        private int _total = 0;
        private int _pageCount = 0;
        private IQueryable<T> _query;
        public Pagination()
        {
            _query = new BaseRepository().Query<T>();
            _pageIndex = 0;
            _pageSize = AppConfig.DATA_ROW_PER_PAGE;
            _ = UpdatePagedData();
            DatagridProvider.DataGrid.Columns.Clear();
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
        
        public async Task<List<T>> UpdatePagedData()
        {
            _total = await _query.CountAsync();
            if (_total >= 0)
            {
                var result = (double)_total / _pageSize;
                _pageCount = (int)Math.Ceiling(result);
                DatagridProvider.DataGrid.ItemsSource = await _query.Skip(_pageIndex * _pageSize).Take(_pageSize).ToListAsync();
                UpdatePageLabel();
            }

            throw new InvalidOperationException();
        }
        
        private void UpdatePageLabel()
        {
            DatagridProvider.PageLabel.Text = $"{_pageIndex + 1}/{_pageCount}";
            DatagridProvider.TotalLabel.Text = $"Total {_total} data";
        }
        
    }
}

