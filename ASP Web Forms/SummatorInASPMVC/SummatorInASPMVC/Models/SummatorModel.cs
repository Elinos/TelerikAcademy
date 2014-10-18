using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SummatorInASPMVC.Models
{
    public class SummatorModel
    {
        [Display(Name = "First Number")]
        public int FirstNumber { get; set; }

        [Display(Name = "Second Number")]
        public int SecondNumber { get; set; }

        [Display(Name = "Result")]
        public int Result { get; set; }
    }
}