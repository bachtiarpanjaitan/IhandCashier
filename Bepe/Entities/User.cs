using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [MaxLength(50)]
        public string nama { get; set; }

        [Required]
        [MaxLength(20)]
        public string username { get; set; }

        [Required]
        [MaxLength(150)]
        public string password { get; set; }

        public string email { get; set; }

        public string avatar { get; set; }
    }
}

