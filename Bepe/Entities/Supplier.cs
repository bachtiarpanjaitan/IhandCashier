using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using IhandCashier.Bepe.Interfaces;

namespace IhandCashier.Bepe.Entities
{
    [Table("suppliers")]
    public class Supplier : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        [StringLength(100)]  // Adjust the length as needed
        public string nama { get; set; }

        public string alamat { get; set; }

        [StringLength(50)]  // Adjust the length as needed
        public string telepon { get; set; }
    }
}