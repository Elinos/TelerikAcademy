using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Cars.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(10)]
        [Required]
        [Index("IX_Name", IsUnique = true)]
        public string Name { get; set; }
    }
}
