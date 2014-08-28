using System;
using System.Linq;
namespace _11.Task
{
    public class ListItem<T>
    {
        public T Value { get; set; }
        public ListItem<T> NextItem { get; set; }
    }
}
