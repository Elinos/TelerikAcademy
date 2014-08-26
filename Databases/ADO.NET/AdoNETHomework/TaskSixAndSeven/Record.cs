using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskSix
{
    class Record
    {
        
        public Record(string name, int score)
        {
            this.Name = name;
            this.Score = score;
        }

        public string Name { get; set; }

        public int Score { get; set; }
    }
}
