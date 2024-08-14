using IhandCashier.Bepe.Entities;

namespace IhandCashier.Bepe.Interfaces;

public interface IDataService<T>
{
    int TotalData();
    Task<List<T>> GetPagingData(int pageIndex, int pageSize, string searchQuery = null);
}