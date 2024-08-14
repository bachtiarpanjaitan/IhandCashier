using IhandCashier.Bepe.Database;
using IhandCashier.Bepe.Entities;
using IhandCashier.Bepe.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IhandCashier.Bepe.Services;

public class BasicUnitService : IDataService<BasicUnit>
{
    private readonly AppDbContext _context;

    public BasicUnitService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<BasicUnit>> GetAsync()
    {
        return await _context.BasicUnits.ToListAsync();
    }
    
    public IQueryable<BasicUnit> Query()
    {
        return _context.BasicUnits.AsQueryable();
    }
    
    public int TotalData()
    {
        return _context.BasicUnits.Count();
    }

    public async Task<List<BasicUnit>> GetPagingData(int pageIndex, int pageSize)
    {
        return await _context.BasicUnits.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();
    }

    public async Task AddAsync(BasicUnit product)
    {
        _context.BasicUnits.Add(product);
        await _context.SaveChangesAsync();
    }
}