using IhandCashier.Bepe.Database;
using IhandCashier.Bepe.Entities;
using IhandCashier.Bepe.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IhandCashier.Bepe.Services;

public class UserService : IDataService<User>
{
    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<User>> GetAsync()
    {
        return await _context.Users.ToListAsync();
    }
    
    public IQueryable<User> Query()
    {
        return _context.Users.AsQueryable();
    }
    
    public int TotalData()
    {
        return _context.Users.Count();
    }

    public async Task<List<User>> GetPagingData(int pageIndex, int pageSize)
    {
        return await _context.Users.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();
    }

    public async Task AddAsync(User product)
    {
        _context.Users.Add(product);
        await _context.SaveChangesAsync();
    }
}