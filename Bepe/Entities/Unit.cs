using System;
using System.ComponentModel.DataAnnotations;
using IhandCashier.Bepe.Interfaces;
using SQLite;

namespace IhandCashier.Bepe.Entities
{
    [Table("units")]
    public class Unit : IEntity
	{
        [Key]
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        
        public int? basic_unit_id { get; set; }

        [Required]
        public string kode_satuan { get; set; }

        [Required]
        public string nama { get; set; }

        [Required]
        public decimal konversi { get; set; }

        [Ignore]
        public BasicUnit basic_unit_ { get; set; }
    }
}

