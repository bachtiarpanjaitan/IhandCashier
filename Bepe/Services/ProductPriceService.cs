using IhandCashier.Bepe.Database;
using IhandCashier.Bepe.Entities;
using IhandCashier.Bepe.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IhandCashier.Bepe.Services;

public class ProductPriceService : IDataService<ProductPrice>
{
    private readonly AppDbContext _context;

    public ProductPriceService(AppDbContext context)
    {
        _context = context;
    }
    public int TotalData()
    {
        return _context.ProductPrices.Count();
    }

    public async Task<List<ProductPrice>> GetPagingData(int pageIndex, int pageSize, string searchQuery = null)
    {
        IQueryable<ProductPrice> query = _context.ProductPrices;
        if (!string.IsNullOrWhiteSpace(searchQuery))
        {
            query = query.Where(item => EF.Functions.Like(item.tanggal_berlaku.ToString(), $"%{searchQuery}%")
            );
        }
        return await query.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();
    }
}