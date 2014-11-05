using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewsSystem.Models
{
    public class Like
    {
        public int ID { get; set; }

        public bool? Value { get; set; }

        public int ArticleID { get; set; }

        public Article Article { get; set; }

        public string UserID { get; set; }

        public AppUser User { get; set; }
    }
}