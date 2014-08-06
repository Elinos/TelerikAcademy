namespace Computers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Dell : Manufacturer
    {
        public override PC CreatePC()
        {
            var ram = new RAM(8);
            var cpu = new Cpu64Bit(4);
            HardDrive[] hardDrive = new[] { new HardDrive(1000, false, 0) };
            var pc = new PC(cpu, ram, hardDrive);
            return pc;
        }

        public override Laptop CreateLaptop()
        {
            var ram = new RAM(8);
            var cpu = new Cpu32Bit(4);
            HardDrive[] hardDrive = new[] { new HardDrive(1000, false, 0) };
            var battery = new LaptopBattery();
            var laptop = new Laptop(cpu, ram, hardDrive, battery);
            return laptop;
        }

        public override Server CreateServer()
        {
            var ram = new RAM(64);
            var cpu = new Cpu64Bit(8);
            var hardDrivesList = new List<HardDrive> { new HardDrive(0, true, 2, new List<HardDrive> { new HardDrive(2000, false, 0), new HardDrive(2000, false, 0) }) };
            var server = new Server(cpu, ram, hardDrivesList);
            return server;
        }
    }
}