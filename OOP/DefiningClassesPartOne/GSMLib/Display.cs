using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMLib
{
    public class Display
    {
        private float? size;
        private int? numberOfColors;

        public float? Size
        {
            get { return size; }
            set
            {
                if (size < 0 || size > float.MaxValue)
                    throw new ArgumentOutOfRangeException(size.ToString(), "Size must be a positive number!");
                else
                    size = value;
            }
        }

        public int? NumberOfColors
        {
            get { return numberOfColors; }
            set
            {
                if (numberOfColors < 0 || numberOfColors > int.MaxValue)
                    throw new ArgumentOutOfRangeException(numberOfColors.ToString(), "Size must be a positive number!");
                else
                    numberOfColors = value;
            }
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Display size: " + size);
            sb.AppendLine("Display colors: " + numberOfColors);

            return sb.ToString();
        }
    }
}
