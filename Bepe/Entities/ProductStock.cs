using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using IhandCashier.Bepe.Interfaces;

namespace IhandCashier.Bepe.Entities
{
    [Table("product_stocks")]
    public class ProductStock : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        public int product_id { get; set; }

        [Required]
        public int unit_id { get; set; }

        [Required]
        [Column(TypeName = "decimal(15, 2)")]
        public decimal jumlah { get; set; }

        // Navigation properties
        [ForeignKey("product_id")]
        public Product Product { get; set; }
        
        [ForeignKey("unit_id")]
        public Unit Unit { get; set; }
    }
}