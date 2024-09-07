namespace IhandCashier.Bepe.Dtos.Details;

public class ProductReceiptDetailGrid
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public string UnitName { get; set; }
    public decimal Jumlah { get; set; }
    public decimal HargaSatuan { get; set; }
    public decimal Total { get; set; }
}