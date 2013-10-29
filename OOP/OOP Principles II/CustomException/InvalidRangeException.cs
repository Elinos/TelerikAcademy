using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomException
{
    class InvalidRangeException<T> : ApplicationException
    {
        private const string Message = "Out of range";
        public T Start { get; private set; }
        public T End { get; private set; }

        public InvalidRangeException(T start, T end)
            : base(Message, null)
        {
            this.Start = start;
            this.End = end;
        }
    }
}
