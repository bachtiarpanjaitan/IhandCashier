using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IhandCashier.Bepe.Interfaces;

namespace IhandCashier.Bepe.Entities
{
    [Table("products")]
    public class Product : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        [MaxLength(50)]
        public string kode { get; set; }

        [Required]
        [MaxLength(100)]
        public string nama { get; set; }

        [MaxLength(100)]
        public string gambar { get; set; }
    }
}

