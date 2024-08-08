using System.ComponentModel.DataAnnotations;
using SQLite;
using IhandCashier.Bepe.Interfaces;

namespace IhandCashier.Bepe.Entities
{
    [Table("basic_units")]
    public class BasicUnit : IEntity
    {
        [Key]
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        [Required]
        public string Nama { get; set; }

        // Navigation property
        [Ignore]
        public ICollection<Unit> Units { get; set; }
    }
}

