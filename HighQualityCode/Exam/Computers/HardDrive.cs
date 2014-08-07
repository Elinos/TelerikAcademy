namespace Computers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HardDrive
    {
        private readonly bool isInRaid;

        private readonly int hardDrivesInRaid;

        private readonly List<HardDrive> hds;

        private readonly int capacity;

        private readonly Dictionary<int, string> data;

        public HardDrive(int capacity, bool isInRaid, int hardDrivesInRaid)
        {
            this.isInRaid = isInRaid;
            this.hardDrivesInRaid = hardDrivesInRaid;

            this.capacity = capacity;
            this.data =
                new Dictionary<int, string>(capacity);

            this.hds = new List<HardDrive>();
        }

        internal HardDrive(int capacity, bool isInRaid, int hardDrivesInRaid, List<HardDrive> hardDrives)
        {
            this.isInRaid = isInRaid;
            this.hardDrivesInRaid = hardDrivesInRaid;
            this.capacity = capacity;

            this.data = new Dictionary<int, string>(capacity);
            this.hds = new List<HardDrive>();
            this.hds = hardDrives;
        }

        private int Capacity
        {
            get
            {
                if (this.isInRaid)
                {
                    if (!this.hds.Any())
                    {
                        return 0;
                    }

                    return this.hds.First().Capacity;
                }
                else
                {
                    return this.capacity;
                }
            }
        }

        public void SaveData(int addr, string newData)
        {
            if (this.isInRaid)
            {
                foreach (var hardDrive in this.hds)
                {
                    hardDrive.SaveData(addr, newData);
                }
            }
            else
            {
                this.data[addr] = newData;
            }
        }

        public string LoadData(int address)
        {
            if (this.isInRaid)
            {
                if (!this.hds.Any())
                {
                    throw new ArgumentException("No hard drive in the RAID array!");
                }

                return this.hds.First().LoadData(address);
            }
            else
            {
                return this.data[address];
            }
        }
    }
}