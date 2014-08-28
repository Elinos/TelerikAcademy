using System;
using System.Linq;

namespace TaskThree
{
    class File
    {
        string name;
        long sizeBytes;

        public File(string name, long size)
        {
            this.Name = name;
            this.SizeInBytes = size;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (value == null || value == "")
                {
                    throw new ArgumentException("File name cannot be null or empty");
                }
                this.name = value;
            }
        }
        public long SizeInBytes
        {
            get
            {
                return this.sizeBytes;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Size cannot be less than zero");
                }
                this.sizeBytes = value;
            }
        }
    }
}
