namespace Computers
{
    using System;
    using System.Linq;

    public interface ILaptop
    {
        LaptopBattery Battery { get; set; }

        void ChargeBattery(int percentage);
    }
}