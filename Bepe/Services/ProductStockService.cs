using IhandCashier.Bepe.Database;
using IhandCashier.Bepe.Dtos;
using IhandCashier.Bepe.Entities;
using IhandCashier.Bepe.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IhandCashier.Bepe.Services;

public class ProductStockService : IDataService<ProductStockDto>
{
    public ProductStockService(AppDbContext context){ }
    public int TotalData()
    {
        using var _context = new AppDbContext(); 
        return _context.ProductStocks.Count();
    }

    public async Task<List<ProductStockDto>> GetPagingData(int pageIndex, int pageSize, string searchQuery = null)
    {
        using var _context = new AppDbContext(); 
        IQueryable<ProductStock> query = _context.ProductStocks
            .Include(x => x.Product)
            .Include(x => x.Unit)
            .ThenInclude(x => x.BasicUnit);
        if (!string.IsNullOrWhiteSpace(searchQuery))
        {
            query = query.Where(item => EF.Functions.Like(item.Product.nama, $"%{searchQuery}%") ||
                                        EF.Functions.Like(item.Product.kode, $"%{searchQuery}%")
            );
        }
        var result =  await query
            .AsNoTracking()
            .Skip(pageIndex * pageSize).Take(pageSize)
            .Select(x => new ProductStockDto()
            {
                id = x.id,
                basic_unit_name = x.Unit.BasicUnit.nama,
                kode = x.Product.kode,
                product_id = x.product_id,
                unit_id = x.unit_id,
                basic_unit_id = x.Unit.basic_unit_id,
                nama = x.Product.nama,
                jumlah = (x.jumlah * x.Unit.konversi)
            })
            .ToListAsync();
        return result;
    }
}