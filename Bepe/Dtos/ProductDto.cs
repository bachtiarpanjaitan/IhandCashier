namespace IhandCashier.Bepe.Dtos;

public class ProductDto
{
    public int id { get; set; }
    public string kode { get; set; }
    public string nama { get; set; }
    public string gambar { get; set; }
    public ImageSource resourceGambar { get; set; }
}