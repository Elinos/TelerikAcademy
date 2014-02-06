using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FilesShelf.Models
{
    public class Person
    {
        public string FullName { get; set; }

        public override string ToString()
        {
            return this.FullName;
        }
    }
}
