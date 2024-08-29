using IhandCashier.Bepe.Entities;
using IhandCashier.Bepe.ViewModels;

namespace IhandCashier.Bepe.Dtos;

public class ProductDto
{
    public int id { get; set; }
    public string kode { get; set; }
    public string nama { get; set; }
    public string gambar { get; set; }
    public ImageSource resourceGambar { get; set; }

    public Product ToProduct()
    {
        return new Product
        {
            id = this.id,
            gambar = this.gambar,
            kode = this.kode,
            nama = this.nama,
        };
    }

    public ProductViewModel ToProductViewModel()
    {
        return new ProductViewModel()
        {
            Id = this.id,
            Gambar = this.gambar,
            Kode = this.kode,
            Nama = this.nama,
        };
    }
}