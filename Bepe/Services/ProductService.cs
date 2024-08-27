using IhandCashier.Bepe.Configs;
using IhandCashier.Bepe.Database;
using IhandCashier.Bepe.Dtos;
using IhandCashier.Bepe.Entities;
using IhandCashier.Bepe.Interfaces;
using IhandCashier.Core.Maui.Providers;
using Microsoft.EntityFrameworkCore;

namespace IhandCashier.Bepe.Services;

public class ProductService : IDataService<ProductDto>
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

    public async Task<List<ProductDto>> GetPagingData(int pageIndex, int pageSize, string searchQuery)
    {
        IQueryable<Product> query = _context.Products;
        if (!string.IsNullOrWhiteSpace(searchQuery))
        {
            query = query.Where(item => EF.Functions.Like(item.nama, $"%{searchQuery}%") || 
                                                EF.Functions.Like(item.kode, $"%{searchQuery}%")
                                                );
        }
        var result =  await query
            .OrderByDescending(i => i.id)
            .Skip(pageIndex * pageSize)
            .Take(pageSize)
            .Select(item => new ProductDto()
            {
                id = item.id,
                nama = item.nama,
                kode = item.kode,
                gambar = item.gambar,
                resourceGambar = ImageSource.FromFile(Path.Combine(AppSettingConfig.CreateAppPath("Images"),item.gambar))
            })
            .ToListAsync();
        DatagridProvider.DataGrid.ItemsSource = result;
        return result;
    }

    public async Task AddAsync(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
    }
}