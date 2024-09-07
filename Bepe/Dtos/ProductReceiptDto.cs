using IhandCashier.Bepe.Entities;

namespace IhandCashier.Bepe.Dtos;

public class ProductReceiptDto
{
    public int Id { get; set; }
    public string KodeTransaksi { get; set; }
    public int SupplierId { get; set; }
    
    public string SupplierName { get; set; }
    public string Penerima { get; set; }
    public DateTime Tanggal { get; set; }
    public string Keterangan { get; set; }
    
    public Supplier Supplier { get; set; }
    public IEnumerable<ProductReceiptDetailDto> Details { get; set; }
    
    public ProductReceipt ToEntity()
    {
        return new ProductReceipt
        {
            id = this.Id,
            kode_transaksi = this.KodeTransaksi,
            supplier_id = this.SupplierId,
            penerima = Penerima,
            tanggal = this.Tanggal,
            keterangan = Keterangan,
        };
    }

    // public ProductReceiptViewModel ToViewModel()
    // {
    //     return new ProductReceiptViewModel()
    //     {
    //         
    //     };
    // }
    
}