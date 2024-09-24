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
    // private readonly AppDbContext _context;

    public ProductService(){}

    public async Task<List<Product>> GetAsync()
    {
        using var _context = new AppDbContext(); 
        return await _context.Products.AsNoTracking().ToListAsync();
    }

    public int TotalData()
    {
        using var _context = new AppDbContext(); 
        return _context.Products.AsNoTracking().Count();
    }

    public async Task<List<ProductDto>> GetPagingData(int pageIndex, int pageSize, string searchQuery)
    {
        using var _context = new AppDbContext(); 
        IQueryable<Product> query = _context.Products;
        if (!string.IsNullOrWhiteSpace(searchQuery))
        {
            query = query.Where(item => EF.Functions.Like(item.nama, $"%{searchQuery}%") || 
                                                EF.Functions.Like(item.kode, $"%{searchQuery}%")
                                                );
        }
        var result =  await query
            .OrderByDescending(i => i.id)
            .AsNoTracking()
            .Skip(pageIndex * pageSize)
            .Take(pageSize)
            .Select(item => new ProductDto()
            {
                id = item.id,
                nama = item.nama,
                kode = item.kode,
                gambar = item.gambar,
                resourceGambar = Path.Combine(AppSettingConfig.CreateAppPath("Images"),item.gambar),
                resourceGambarThumbnail = Path.Combine(AppSettingConfig.CreateAppPath("Images"),"Thumbnails",item.gambar),
            })
            .ToListAsync();
        // DatagridProvider.DataGrid.ItemsSource = result;
        return result;
    }

    public async Task AddAsync(Product product)
    {
        using var _context = new AppDbContext(); 
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        _context.Products.Entry(product).State = EntityState.Detached;
    }

    public async Task UpdateAsync(Product item)
    {
        using var _context = new AppDbContext(); 
        var entity = await _context.Products.AsNoTracking().FirstOrDefaultAsync(e => e.id == item.id);
        _context.Entry(entity).CurrentValues.SetValues(item);
        _context.Update(entity);
        await _context.SaveChangesAsync();
        
        _context.Entry(entity).State = EntityState.Detached;
    }

    public async Task DeleteAsync(Product product)
    {
        using var _context = new AppDbContext(); 
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }
}