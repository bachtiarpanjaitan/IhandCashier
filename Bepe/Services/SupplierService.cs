using IhandCashier.Bepe.Database;
using IhandCashier.Bepe.Entities;
using IhandCashier.Bepe.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IhandCashier.Bepe.Services;

public class SupplierService : IDataService<Supplier>
{
    public SupplierService(AppDbContext context){}
    public int TotalData()
    {
        using var _context = new AppDbContext(); 
        return _context.Suppliers.Count();
    }
    
    public async Task<List<Supplier>> GetAsync()
    {
        using var _context = new AppDbContext(); 
        return await _context.Suppliers.AsNoTracking().ToListAsync();
    }

    public async Task<List<Supplier>> GetPagingData(int pageIndex, int pageSize, string searchQuery = null)
    {
        using var _context = new AppDbContext(); 
        IQueryable<Supplier> query = _context.Suppliers;
        if (!string.IsNullOrWhiteSpace(searchQuery))
        {
            query = query.Where(item => EF.Functions.Like(item.nama, $"%{searchQuery}%")
            );
        }
        return await query.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();
    }
}