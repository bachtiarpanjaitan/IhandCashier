using IhandCashier.Bepe.Database;
using IhandCashier.Bepe.Entities;
using IhandCashier.Bepe.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IhandCashier.Bepe.Services;

public class UnitService : IDataService<Unit>
{
    private readonly AppDbContext _context;

    public UnitService(AppDbContext context)
    {
        _context = context;
    }
    
    public int TotalData()
    {
        return _context.Units.Count();
    }

    public async Task<List<Unit>> GetPagingData(int pageIndex, int pageSize,string searchQuery)
    {
        IQueryable<Unit> query = _context.Units;
        if (!string.IsNullOrWhiteSpace(searchQuery))
        {
            query = query.Where(item => EF.Functions.Like(item.nama, $"%{searchQuery}%") || 
                                        EF.Functions.Like(item.kode_satuan, $"%{searchQuery}%")
            );
        }
        return await query.WithNavigation()
            .Include(b => b.BasicUnit)
            .Skip(pageIndex * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task AddAsync(Unit product)
    {
        _context.Units.Add(product);
        await _context.SaveChangesAsync();
    }
}