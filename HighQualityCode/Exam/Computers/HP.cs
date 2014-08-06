namespace Computers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HP : Manufacturer
    {
        public override PC CreatePC()
        {
            var ram = new RAM(2);
            var cpu = new Cpu32Bit(2);
            HardDrive[] hardDrive = new[] { new HardDrive(500, false, 0) };
            PC pc = new PC(cpu, ram, hardDrive);

            return pc;
        }

        public override Laptop CreateLaptop()
        {
            var ram = new RAM(4);
            var cpu = new Cpu64Bit(2);
            HardDrive[] hardDrive = new[] { new HardDrive(500, false, 0) };
            var laptopBattery = new LaptopBattery();
            var laptop = new Laptop(cpu, ram, hardDrive, laptopBattery);
            return laptop;
        }

        public override Server CreateServer()
        {
            var serverRam = new RAM(32);
            var cpu = new Cpu32Bit(4);
            var hardDrivesList = new List<HardDrive> { new HardDrive(0, true, 2, new List<HardDrive> { new HardDrive(1000, false, 0), new HardDrive(1000, false, 0) }) };
            var server = new Server(cpu, serverRam, hardDrivesList);
            return server;
        }
    }
}