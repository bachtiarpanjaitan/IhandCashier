using IhandCashier.Bepe.Database;
using IhandCashier.Bepe.Entities;
using IhandCashier.Bepe.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IhandCashier.Bepe.Services;

public class ProductStockService : IDataService<ProductStock>
{
    private readonly AppDbContext _context;

    public ProductStockService(AppDbContext context)
    {
        _context = context;
    }
    public int TotalData()
    {
        return _context.ProductStocks.Count();
    }

    public async Task<List<ProductStock>> GetPagingData(int pageIndex, int pageSize, string searchQuery = null)
    {
        IQueryable<ProductStock> query = _context.ProductStocks;
        if (!string.IsNullOrWhiteSpace(searchQuery))
        {
            query = query.Where(item => EF.Functions.Like(item.product_id.ToString(), $"%{searchQuery}%")
            );
        }
        return await query.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();
    }
}