using IhandCashier.Bepe.Database;
using IhandCashier.Bepe.Entities;
using IhandCashier.Bepe.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IhandCashier.Bepe.Services;

public class SupplierService : IDataService<Supplier>
{
    private readonly AppDbContext _context;

    public SupplierService(AppDbContext context)
    {
        _context = context;
    }
    public int TotalData()
    {
        return _context.Suppliers.Count();
    }

    public async Task<List<Supplier>> GetPagingData(int pageIndex, int pageSize, string searchQuery = null)
    {
        IQueryable<Supplier> query = _context.Suppliers;
        if (!string.IsNullOrWhiteSpace(searchQuery))
        {
            query = query.Where(item => EF.Functions.Like(item.nama, $"%{searchQuery}%")
            );
        }
        return await query.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();
    }
}