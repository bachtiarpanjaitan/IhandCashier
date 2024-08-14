using IhandCashier.Bepe.Database;
using IhandCashier.Bepe.Entities;
using IhandCashier.Bepe.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IhandCashier.Bepe.Services;

public class ProductService : IDataService<Product>
{
    private readonly AppDbContext _context;

    public ProductService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetAsync()
    {
        return await _context.Products.ToListAsync();
    }
    
    public IQueryable<Product> Query()
    {
        return _context.Products.AsQueryable();
    }
    

    public int TotalData()
    {
        return _context.Products.Count();
    }

    public async Task<List<Product>> GetPagingData(int pageIndex, int pageSize, string searchQuery)
    {
        IQueryable<Product> query = _context.Products;
        if (!string.IsNullOrWhiteSpace(searchQuery))
        {
            query = query.Where(item => EF.Functions.Like(item.nama, $"%{searchQuery}%") || 
                                                EF.Functions.Like(item.kode, $"%{searchQuery}%")
                                                );
        }
        return await query.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();
    }

    public async Task AddAsync(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
    }
}