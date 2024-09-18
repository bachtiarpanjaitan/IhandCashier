#nullable enable
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using IhandCashier.Bepe.Interfaces;

namespace IhandCashier.Bepe.Entities
{
    [Table("product_receipts")]
    public class ProductReceipt : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        public string kode_transaksi { get; set; }

        [Required] 
        public int status { get; set; } = 0;

        [Required]
        public int supplier_id { get; set; }

        public string penerima { get; set; }

        [Required]
        public DateTime tanggal { get; set; }

        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public DateTime? deleted_at { get; set; }
        public string? keterangan { get; set; }

        // Navigation propertyx
        [ForeignKey("supplier_id")]
        public Supplier Supplier { get; set; }
        public ICollection<ProductReceiptDetail> Details { get; set; }
    }
}