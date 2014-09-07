using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BookStore.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
        public int? AuthorId { get; set; }
        public virtual Author Author { get; set; }
        public int? BookId { get; set; }
        public virtual Book Book { get; set; }
        public string Text { get; set; }
    }
}
