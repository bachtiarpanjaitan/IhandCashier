using IhandCashier.Bepe.Database;
using Microsoft.EntityFrameworkCore;

namespace IhandCashier.Bepe.Helpers
{
    public class PaginationHandler
    {
        private int Index = 0;
        private int Size = 0;
        private readonly BaseRepository _baseRepository = new();
        public PaginationHandler(int index, int size)
        {
            Index = index;
            Size = size;
        }
        
        public async Task<List<T>> GetDataAsync<T>() where T : class
        {
            try
            {
                var items = await _baseRepository.GetEntities<T>()
                    .Skip(Index * Size)
                    .Take(Size)
                    .ToListAsync();
                return items;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error AppDbContext:29 : {e.Message}");
            }

            throw new InvalidOperationException();
        }
        
        public int GetTotalDataAsync<T>() where T : class
        {
            return _baseRepository.GetEntities<T>().Count();
        }
    }
}
