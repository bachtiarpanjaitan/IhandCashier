using IhandCashier.Bepe.Database;
using IhandCashier.Bepe.Dtos;
using IhandCashier.Bepe.Entities;
using IhandCashier.Bepe.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IhandCashier.Bepe.Services;

public class UnitService : IDataService<UnitDto>
{
    public UnitService(AppDbContext context){}
    
    public int TotalData()
    {
        using var _context = new AppDbContext(); 
        return _context.Units.AsNoTracking().Count();
    }
    
    public async Task<List<Unit>> GetAsync()
    {
        using var _context = new AppDbContext(); 
        return await _context.Units.AsNoTracking().ToListAsync();
    }

    public async Task<List<UnitDto>> GetPagingData(int pageIndex, int pageSize,string searchQuery)
    {
        using var _context = new AppDbContext(); 
        IQueryable<Unit> query = _context.Units
            .AsNoTracking()
            .Include(b => b.BasicUnit);
        if (!string.IsNullOrWhiteSpace(searchQuery))
        {
            query = query.Where(item => EF.Functions.Like(item.nama, $"%{searchQuery}%") || 
                                        EF.Functions.Like(item.kode_satuan, $"%{searchQuery}%") ||
                                        EF.Functions.Like(item.BasicUnit.nama, $"%{searchQuery}%")
            );
        }
        return await query
            .Skip(pageIndex * pageSize)
            .Take(pageSize)
            .Select(item => new UnitDto()
            {
                id = item.id,
                basic_unit_id = item.basic_unit_id,
                kode_satuan = item.kode_satuan,
                nama = item.nama,
                konversi = item.konversi,
                BasicUnit = item.BasicUnit
            })
            .ToListAsync();
    }

    public async Task AddAsync(Unit unit)
    {
        using var _context = new AppDbContext(); 
        _context.Units.Add(unit);
        await _context.SaveChangesAsync();
        _context.Units.Entry(unit).State = EntityState.Detached;
    }
    
    public async Task UpdateAsync(Unit item)
    {
        using var _context = new AppDbContext(); 
        var entity = await _context.Units.AsNoTracking().FirstOrDefaultAsync(e => e.id == item.id);
        _context.Entry(entity).CurrentValues.SetValues(item);
        _context.Update(entity);
        await _context.SaveChangesAsync();
        
        _context.Entry(entity).State = EntityState.Detached;
    }

    public async Task DeleteAsync(Unit unit)
    {
        using var _context = new AppDbContext(); 
        _context.Units.Remove(unit);    
        await _context.SaveChangesAsync();
    }
}