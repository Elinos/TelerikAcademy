namespace StudentSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class Student
    {
        public Student()
        {
            this.Courses = new HashSet<Course>();
            this.Homeworks = new HashSet<Homework>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(2)]  
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string LastName { get; set; }

        public StudentInfo AdditionalInformation { get; set; }

        public virtual Student Assistant { get; set; }

        [InverseProperty("Assistant")]
        public virtual ICollection<Student> Trainees { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public virtual ICollection<Homework> Homeworks { get; set; }
    }
}