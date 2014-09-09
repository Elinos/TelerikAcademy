using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Cars.Models
{
    public class City
    {
        private ICollection<Dealer> dealers;
        public City()
        {
            this.dealers = new HashSet<Dealer>();
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(10)]
        [Required]
        [Index("IX_Name", IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<Dealer> Cities
        {
            get
            {
                return this.dealers;
            }
            set
            {
                this.dealers = value;
            }
        }
    }
}
