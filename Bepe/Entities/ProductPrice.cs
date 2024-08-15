using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using IhandCashier.Bepe.Interfaces;

namespace IhandCashier.Bepe.Entities
{
    [Table("product_prices")]
    public class ProductPrice : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        public int product_id { get; set; }

        [Required]
        public int unit_id { get; set; }

        [Required]
        public decimal harga { get; set; }

        [Required]
        public DateTime tanggal_berlaku { get; set; }

        // Navigation properties
        [ForeignKey("product_id")]
        public Product Product { get; set; } 

        [ForeignKey("unit_id")]
        public Unit Unit { get; set; }
    }
}