using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FilesShelf.Models
{
    public class Genre
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
