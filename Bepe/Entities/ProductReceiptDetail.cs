using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using IhandCashier.Bepe.Interfaces;

namespace IhandCashier.Bepe.Entities
{
    [Table("product_receipt_details")]
    public class ProductReceiptDetail : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        public int product_receipt_id { get; set; }

        [Required]
        public int product_id { get; set; }

        [Required]
        public decimal jumlah { get; set; }

        [Required]
        public int unit_id { get; set; }

        [Required]
        public decimal harga_satuan { get; set; }

        // Navigation properties
        public ProductReceipt ProductReceipt { get; set; }
        public Product Product { get; set; }
        public Unit Unit { get; set; }
    }
}