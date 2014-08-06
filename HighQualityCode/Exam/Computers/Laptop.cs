namespace Computers
{
    using System.Collections.Generic;

    public class Laptop : Computer, ILaptop
    {
        public Laptop(Cpu cpu, RAM ram, IEnumerable<HardDrive> hardDrives, LaptopBattery battery)
            : base(cpu, ram, hardDrives)
        {
            this.Battery = battery;
            this.VideoCard.IsMonochrome = false;
        }

        public LaptopBattery Battery { get; set; }

        public void ChargeBattery(int percentage)
        {
            this.Battery.Charge(percentage);

            this.Motherboard.DrawOnVideoCard(string.Format("Battery status: {0}%", this.Battery.Percentage));
        }
    }
}
