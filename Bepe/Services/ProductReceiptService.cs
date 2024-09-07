using IhandCashier.Bepe.Database;
using IhandCashier.Bepe.Dtos;
using IhandCashier.Bepe.Dtos.Details;
using IhandCashier.Bepe.Entities;
using IhandCashier.Bepe.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IhandCashier.Bepe.Services;

public class ProductReceiptService : IDataService<ProductReceiptDto>
{
    private readonly AppDbContext _context;

    public ProductReceiptService(AppDbContext context)
    {
        _context = context;
    }
    public int TotalData()
    {
        return _context.ProductReceipts.AsNoTracking().Where(x => x.deleted_at == null).Count();
    }

    public async Task<List<ProductReceiptDto>> GetPagingData(int pageIndex, int pageSize, string searchQuery = null)
    {
        IQueryable<ProductReceipt> query = _context.ProductReceipts
            .Include(s => s.Supplier)
            .Where(x => x.deleted_at == null);
        if (!string.IsNullOrWhiteSpace(searchQuery))
        {
            query = query.Where(item => EF.Functions.Like(item.kode_transaksi, $"%{searchQuery}%") ||
                                        EF.Functions.Like(item.penerima, $"%{searchQuery}%")
            );
        }
        var result = await query.Skip(pageIndex * pageSize).Take(pageSize)
            .Include(d => d.Details).ThenInclude(x => x.Product)
            .Include(d => d.Details).ThenInclude(x => x.Unit)
            .Select(item => new ProductReceiptDto()
            {
                Id = item.id,
                KodeTransaksi = item.kode_transaksi,
                SupplierId = item.supplier_id,
                Penerima = item.penerima,
                Tanggal = item.tanggal,
                Keterangan = item.keterangan,
                SupplierName = item.Supplier.nama,
                ItemCount = item.Details.Count(),
                // Details = item.Details
                Details = item.Details.Select(d => new ProductReceiptDetailDto()
                {
                    Id = d.id,
                    ProductReceiptId = d.product_receipt_id,
                    ProductId = d.product_id,
                    ProductName = d.Product != null ? d.Product.nama : null,
                    Jumlah = d.jumlah,
                    UnitId = d.unit_id,
                    UnitName = d.Unit != null ? d.Unit.nama : null,
                    HargaSatuan = d.harga_satuan,
                    Total = (d.harga_satuan * d.jumlah),
                }).ToList(),
                Views = item.Details.Select(d => new ProductReceiptDetailGrid()
                {
                    Id = d.id,
                    ProductName = d.Product != null ? d.Product.nama : null,
                    UnitName = d.Unit != null ? d.Unit.nama : null,
                    Jumlah = d.jumlah,
                    HargaSatuan = d.harga_satuan,
                    Total = (d.harga_satuan * d.jumlah)
                }).ToList()
            })
            .ToListAsync();
        return result;
    }
}