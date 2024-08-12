using IhandCashier.Bepe.Database;
using Microsoft.EntityFrameworkCore;

namespace IhandCashier.Bepe.Helpers
{
    public class PaginationHandler
    {
        private int _index = 0;
        private int _size = 0;
        private readonly BaseRepository _baseRepository = new();
        public PaginationHandler()
        {

        }

        public PaginationHandler Limit(int index)
        {
            _index = index;
            return this;
        }
        
        public PaginationHandler Take(int size)
        {
            _size = size;
            return this;
        }
        
        public async Task<List<T>> GetAsync<T>() where T : class
        {
            try
            {
                var items = await _baseRepository.GetData<T>()
                    .Skip(_index * _size)
                    .Take(_size)
                    .ToListAsync();
                return items;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error PaginationHandler:40 : {e.Message}");
            }

            throw new InvalidOperationException();
        }
        
        public int GetTotalAsync<T>() where T : class
        {
            return _baseRepository.GetData<T>().Count();
        }
    }
}

