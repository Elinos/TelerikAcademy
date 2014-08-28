using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Task
{
    class TaskFive
    {
        static void Main(string[] args)
        {
            var seq = new List<int> { -2, 1, 1, -2, -3 };

            List<int> positiveNumbers = GetPositiveNumbers(seq);
            Console.WriteLine(String.Join(", ", positiveNumbers));
        }

        public static List<int> GetPositiveNumbers(List<int> list)
        {
            List<int> positiveNumbers = list.Where(x => x >= 0).ToList();
            return positiveNumbers;
        }
    }
}
