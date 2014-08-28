using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Task
{
    public class Number
    {
        public int Value { get; set; }
        public int Count { get; set; }

        public Number(int value, int count)
        {
            this.Value = value;
            this.Count = count;
        }
    }
}
