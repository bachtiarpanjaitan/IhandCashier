using IhandCashier.Bepe.Database;
using IhandCashier.Bepe.Entities;
using IhandCashier.Bepe.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IhandCashier.Bepe.Services;

public class ProductReceiptService : IDataService<ProductReceipt>
{
    private readonly AppDbContext _context;

    public ProductReceiptService(AppDbContext context)
    {
        _context = context;
    }
    public int TotalData()
    {
        return _context.ProductReceipts.Count();
    }

    public async Task<List<ProductReceipt>> GetPagingData(int pageIndex, int pageSize, string searchQuery = null)
    {
        IQueryable<ProductReceipt> query = _context.ProductReceipts;
        if (!string.IsNullOrWhiteSpace(searchQuery))
        {
            query = query.Where(item => EF.Functions.Like(item.kode_transaksi, $"%{searchQuery}%") ||
                                        EF.Functions.Like(item.penerima, $"%{searchQuery}%")
            );
        }
        return await query.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();
    }
}