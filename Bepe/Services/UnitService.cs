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

    public async Task<List<Unit>> GetAsync()
    {
        return await _context.Units.ToListAsync();
    }
    
    public IQueryable<Unit> Query()
    {
        return _context.Units.AsQueryable();
    }
    
    public int TotalData()
    {
        return _context.Units.Count();
    }

    public async Task<List<Unit>> GetPagingData(int pageIndex, int pageSize)
    {
        return await _context.Units.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();
    }

    public async Task AddAsync(Unit product)
    {
        _context.Units.Add(product);
        await _context.SaveChangesAsync();
    }
}