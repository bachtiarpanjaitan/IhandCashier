using IhandCashier.Bepe.Database;
using IhandCashier.Bepe.Entities;
using IhandCashier.Bepe.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IhandCashier.Bepe.Services;

public class ProductReceiptDetailService : IDataService<ProductReceiptDetail>
{
    private readonly AppDbContext _context;

    public ProductReceiptDetailService(AppDbContext context)
    {
        _context = context;
    }
    public int TotalData()
    {
        return _context.ProductReceiptDetails.Count();
    }

    public async Task<List<ProductReceiptDetail>> GetPagingData(int pageIndex, int pageSize, string searchQuery = null)
    {
        IQueryable<ProductReceiptDetail> query = _context.ProductReceiptDetails;
        if (!string.IsNullOrWhiteSpace(searchQuery))
        {
            query = query.Where(item => EF.Functions.Like(item.product_id.ToString(), $"%{searchQuery}%"));
        }
        return await query.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();
    }
}