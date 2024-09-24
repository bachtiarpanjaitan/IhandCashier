using IhandCashier.Bepe.Database;
using IhandCashier.Bepe.Entities;
using IhandCashier.Bepe.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IhandCashier.Bepe.Services;

public class ProductReceiptDetailService : IDataService<ProductReceiptDetail>
{
    public ProductReceiptDetailService(AppDbContext context){}
    public int TotalData()
    {
        using var _context = new AppDbContext(); 
        return _context.ProductReceiptDetails.Count();
    }

    public async Task<List<ProductReceiptDetail>> GetPagingData(int pageIndex, int pageSize, string searchQuery = null)
    {
        using var _context = new AppDbContext(); 
        IQueryable<ProductReceiptDetail> query = _context.ProductReceiptDetails;
        if (!string.IsNullOrWhiteSpace(searchQuery))
        {
            query = query.Where(item => EF.Functions.Like(item.product_id.ToString(), $"%{searchQuery}%"));
        }
        return await query.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();
    }
}