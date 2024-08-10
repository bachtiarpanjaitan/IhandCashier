using System;
using IhandCashier.Bepe.Interfaces;
namespace IhandCashier.Bepe.Models
{
    public class ProductModel(
        int id,
        string kode,
        string nama,
        string gambar)
    {

        public int id { get; set; } = id;
        public string kode { get; set; } = kode;
        public string nama { get; set; } = nama;
        public string gambar { get; set; } = gambar;
    }
}

