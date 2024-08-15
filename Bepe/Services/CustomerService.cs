using IhandCashier.Bepe.Database;
using IhandCashier.Bepe.Entities;
using IhandCashier.Bepe.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IhandCashier.Bepe.Services;

public class CustomerService : IDataService<Customer>
{
    private readonly AppDbContext _context;

    public CustomerService(AppDbContext context)
    {
        _context = context;
    }
    public int TotalData()
    {
        return _context.Customers.Count();
    }

    public async Task<List<Customer>> GetPagingData(int pageIndex, int pageSize, string searchQuery = null)
    {
        IQueryable<Customer> query = _context.Customers;
        if (!string.IsNullOrWhiteSpace(searchQuery))
        {
            query = query.Where(item => EF.Functions.Like(item.nama, $"%{searchQuery}%")
            );
        }
        return await query.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();
    }
}