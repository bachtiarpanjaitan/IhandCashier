using System;
using IhandCashier.Bepe.Interfaces;
namespace IhandCashier.Bepe.Models
{
    public class Product 
    {

        public int id { get; set; }
        public string kode { get; set; }
        public string nama { get; set; }
        public string gambar { get; set; }

        public Product(
            int id,
            string kode,
            string nama,
            string gambar
        )
        {
            this.id = id;
            this.kode = kode;
            this.nama = nama;
            this.gambar = gambar;
        }
    }
}

