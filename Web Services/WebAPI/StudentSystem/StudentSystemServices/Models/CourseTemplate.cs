namespace StudentSystemServices.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;
    using StudentSystem.Models;

    public class CourseTemplate
    {
        public static Expression<Func<Course, CourseTemplate>> FromCourse
        {
            get
            {
                return a => new CourseTemplate
                {
                    Name = a.Name,
                    Description = a.Description,
                };
            }
        }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}