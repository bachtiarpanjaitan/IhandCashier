using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IhandCashier.Bepe.Interfaces;

namespace IhandCashier.Bepe.Entities
{
    [Table("basic_units")]
    public class BasicUnit : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nama { get; set; }

        // Navigation property
        public ICollection<Unit> Units { get; set; }
    }
}

