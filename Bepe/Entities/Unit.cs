using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IhandCashier.Bepe.Interfaces;

namespace IhandCashier.Bepe.Entities
{
    [Table("units")]
    public class Unit : IEntity
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public int? basic_unit_id { get; set; }

        [Required]
        [MaxLength(50)]
        public string kode_satuan { get; set; }

        [Required]
        [MaxLength(100)]
        public string nama { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal konversi { get; set; }

        [ForeignKey("basic_unit_id")]
        public BasicUnit BasicUnit { get; set; }
    }
}

