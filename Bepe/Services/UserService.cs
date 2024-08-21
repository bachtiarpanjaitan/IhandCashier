using IhandCashier.Bepe.Configs;
using IhandCashier.Bepe.Database;
using IhandCashier.Bepe.Dtos;
using IhandCashier.Bepe.Entities;
using IhandCashier.Bepe.Interfaces;
using IhandCashier.Bepe.Statics;
using IhandCashier.Bepe.Types;
using IhandCashier.Bepe.ViewModels;
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
                is_admin = u.is_admin,
                status = u.is_active ? "Aktif" : "Tidak Aktif"
            })
            .ToListAsync();
    }

    public async Task<User> GetByUsername(string username)
    {
        return await _context.Users.FirstOrDefaultAsync(item => item.username == username);
    }

    public UserSession Login(DataLogin data)
    {
        User user = _context.Users.Where(u => u.username == data.Username.Trim()).FirstOrDefaultAsync().Result;
        if(user == null) throw new Exception($"Pengguna dengan {data.Username} tidak ditemukan");
        string ePassword = Crypto.Encrypt(data.Password, AppConfig.APP_KEY);
        if(ePassword != user.password) throw new Exception("Password salah");
        if (!user.is_active) throw new Exception("Akun pengguna sudah tidak aktif");
        
        return new SessionManager().SetSession(new UserSession()
        {
            Username = user.username,
            Avatar = user.avatar,
            Email = user.email,
            IsAdmin = user.is_admin,
            IsActive = user.is_active,
            IsLogin = true
        }).GetSession();
    }
    
    public async Task AddAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }
}