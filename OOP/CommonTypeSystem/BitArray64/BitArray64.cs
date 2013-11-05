using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitArray64
{
    class BitArray64 : IEnumerable<int>
    {
        private ulong bits;

        public BitArray64(ulong number)
        {
            this.bits = number;
        }

        
        public int this[int index]
        {
            get
            {
                return (int)((bits >> index) & 1);
            }
        }
        
        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 63; i >= 0; i--)
            {
                yield return (int)((bits >> i) & 1);
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override bool Equals(object obj)
        {
            BitArray64 comparison = obj as BitArray64;

            if (comparison == null)
            {
                return false;
            }
            else 
            {
                return this.bits == comparison.bits;
            }
           
        }

        public override int GetHashCode()
        {
            return bits.GetHashCode();
        }

        public static bool operator ==(BitArray64 numerOne, BitArray64 numberTwo)
        {
            return BitArray64.Equals(numerOne, numberTwo);
        }

        public static bool operator !=(BitArray64 numerOne, BitArray64 numberTwo)
        {
            return !BitArray64.Equals(numerOne, numberTwo);
        }
    }
}
