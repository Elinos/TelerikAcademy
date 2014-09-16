namespace StudentSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    [ComplexType]
    public class StudentInfo
    {
        public string Email { get; set; }

        public string Address { get; set; }
    }
}