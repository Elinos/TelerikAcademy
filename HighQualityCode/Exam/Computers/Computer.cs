namespace Computers
{
    using System;
    using System.Collections.Generic;

    public abstract class Computer
    {
        public Computer(Cpu cpu, RAM ram, IEnumerable<HardDrive> hardDrives)
        {
            this.Cpu = cpu;
            this.Ram = ram;
            this.HardDrives = hardDrives;
            this.VideoCard = new VideoCard();
            this.Motherboard = new Motherboard(this.Ram, this.VideoCard);
        }

        public IEnumerable<HardDrive> HardDrives { get; set; }

        public VideoCard VideoCard { get; set; }

        public Cpu Cpu { get; set; }

        public RAM Ram { get; set; }

        public IMotherboard Motherboard { get; set; }
    }
}