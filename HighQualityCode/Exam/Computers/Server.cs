namespace Computers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Server : Computer, IServer
    {
        public Server(Cpu cpu, RAM ram, IEnumerable<HardDrive> hardDrives)
            : base(cpu, ram, hardDrives)
        {
            this.VideoCard.IsMonochrome = true;
        }

        public void Process(int data)
        {
            this.Motherboard.SaveRamValue(data);
            var number = this.Motherboard.LoadRamValue();
            var result = this.Cpu.SquareNumber(number);
            this.Motherboard.DrawOnVideoCard(result);
        }
    }
}