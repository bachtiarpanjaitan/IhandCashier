using System;
using System.ComponentModel.DataAnnotations;
using IhandCashier.Bepe.Interfaces;
using SQLite;

namespace IhandCashier.Bepe.Entities
{
    [Table("users")]
    public class User : IEntity
	{
        [Key]
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        [Required]
        public string nama { get; set; }

        [Required]
        public string username { get; set; }

        [Required]
        public string password { get; set; }

        public string email { get; set; }

        public string avatar { get; set; }
    }
}

