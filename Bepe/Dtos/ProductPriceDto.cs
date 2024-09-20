using IhandCashier.Bepe.Entities;
using IhandCashier.Bepe.ViewModels;

namespace IhandCashier.Bepe.Dtos;

public class ProductPriceDto
{
  public int id { get; set; }
  public string kode { get; set; }
  public string nama { get; set; }
  public int product_id { get; set; }
  public int unit_id { get; set; }
  public string unit_nama { get; set; }
  
  public string basic_unit_nama { get; set; }
  public double harga { get; set; }
  public DateTime tanggal_berlaku { get; set; }
  
  public ProductPrice ToEntity()
  {
    return new ProductPrice
    {
      id = this.id,
      product_id = this.product_id,
      unit_id = this.unit_id,
      harga = (decimal) this.harga,
      tanggal_berlaku = tanggal_berlaku,
    };
  }

  public ProductPriceViewModel ToViewModel()
  {
    return null;
  }
}