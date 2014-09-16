namespace StudentSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Homework
    {
        public int Id { get; set; }

        [Required]
        public string FileUrl { get; set; }

        [Required]
        public DateTime TimeSent { get; set; }

        public int CourseId { get; set; }

        [Required]
        public virtual Course Course { get; set; }

        public int StudentId { get; set; }

        [Required]
        public virtual Student Student { get; set; }
    }
}