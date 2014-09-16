namespace StudentSystemServices.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;
    using StudentSystem.Models;

    public class StudentTemplate
    {
        public static Expression<Func<Student, StudentTemplate>> FromStudent
        {
            get
            {
                return a => new StudentTemplate
                {
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                };
            }
        }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string LastName { get; set; }
    }
}