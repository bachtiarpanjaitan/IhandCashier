namespace IhandCashier.Bepe.Dtos;

public class ProductStockDto
{
    public int id { get; set; }
    public string kode { get; set; }
    public string nama { get; set; }
    public int product_id { get; set; }
    public int unit_id { get; set; }
    public int basic_unit_id { get; set; }
    public string basic_unit_name { get; set; }
    public decimal jumlah { get; set; }
}