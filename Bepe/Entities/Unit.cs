using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using IhandCashier.Bepe.Interfaces;

namespace IhandCashier.Bepe.Entities
{
    [Table("units")]
    public class Unit : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public int basic_unit_id { get; set; }

        [Required]
        [StringLength(50)]  // Adjust length as needed
        public string kode_satuan { get; set; }

        [Required]
        [StringLength(100)]  // Adjust length as needed
        public string nama { get; set; }

        [Required]
        public decimal konversi { get; set; }

        [ForeignKey("basic_unit_id")]
        public BasicUnit BasicUnit { get; set; }
    }
}