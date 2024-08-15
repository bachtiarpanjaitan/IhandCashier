using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using IhandCashier.Bepe.Interfaces;

namespace IhandCashier.Bepe.Entities
{
    [Table("users")]
    public class User : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        [StringLength(100)]  // Adjust length as needed
        public string nama { get; set; }

        [Required]
        [StringLength(50)]  // Adjust length as needed
        public string username { get; set; }

        [Required]
        public string password { get; set; }

        [StringLength(100)]  // Adjust length as needed
        public string email { get; set; }

        [StringLength(255)]  // Adjust length as needed
        public string avatar { get; set; }

        public bool is_active { get; set; } = true;
    }
}