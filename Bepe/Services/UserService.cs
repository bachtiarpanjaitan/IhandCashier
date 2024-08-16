using IhandCashier.Bepe.Database;
using IhandCashier.Bepe.Dtos;
using IhandCashier.Bepe.Entities;
using IhandCashier.Bepe.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IhandCashier.Bepe.Services;

public class UserService : IDataService<UserDto>
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

    public async Task<List<UserDto>> GetPagingData(int pageIndex, int pageSize, string searchQuery)
    {
        IQueryable<User> query = _context.Users;
        if (!string.IsNullOrWhiteSpace(searchQuery))
        {
            query = query.Where(item => EF.Functions.Like(item.nama, $"%{searchQuery}%") || 
                                        EF.Functions.Like(item.email, $"%{searchQuery}%")||
                                        EF.Functions.Like(item.username, $"%{searchQuery}%")
            );
        }
        return await query
            .Skip(pageIndex * pageSize)
            .Take(pageSize)
            .Select(u => new UserDto()
            {
                id = u.id,
                nama = u.nama,
                username = u.username,
                password = u.password,
                email = u.email,
                avatar = u.avatar,
                is_active = u.is_active,
                status = u.is_active ? "Aktif" : "Tidak Aktif"
            })
            .ToListAsync();
    }

    public async Task AddAsync(User product)
    {
        _context.Users.Add(product);
        await _context.SaveChangesAsync();
    }
}