using System;
using System.ComponentModel.DataAnnotations;
using IhandCashier.Bepe.Interfaces;
using SQLite;

namespace IhandCashier.Bepe.Entities
{
    [Table("products")]
    public class Product : IEntity
    {
        [Key]
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        [Required]
        public string kode { get; set; }

        [Required]
        public string nama { get; set; }

        public string gambar { get; set; }
    }
}

