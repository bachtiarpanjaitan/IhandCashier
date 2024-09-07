using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using IhandCashier.Bepe.Entities;

namespace IhandCashier.Bepe.Dtos;

public class ProductReceiptDetailDto
{
    public int Id { get; set; }
    public int ProductReceiptId { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal Jumlah { get; set; }
    public int UnitId { get; set; }
    public string UnitName { get; set; }
    public decimal HargaSatuan { get; set; }
    public decimal Total { get; set; }
    
    public Product Product { get; set; }
    public Unit Unit { get; set; }
    
    public ProductReceiptDetail ToEntity()
    {
        return new ProductReceiptDetail
        {
            id = this.Id,
            product_receipt_id = ProductReceiptId,
            product_id = ProductId,
            jumlah = Jumlah,
            unit_id = UnitId,
            harga_satuan = HargaSatuan,
        };
    }
}