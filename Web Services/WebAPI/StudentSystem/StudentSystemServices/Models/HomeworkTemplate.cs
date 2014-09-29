namespace StudentSystemServices.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;
    using StudentSystem.Models;

    public class HomeworkTemplate
    {
        public static Expression<Func<Homework, HomeworkTemplate>> FromHomework
        {
            get
            {
                return a => new HomeworkTemplate
                {
                    FileUrl = a.FileUrl,
                };
            }
        }

        [Required]
        public string FileUrl { get; set; }

        public DateTime TimeSent { get; set; }
    }
}