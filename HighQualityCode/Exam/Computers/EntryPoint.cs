namespace Computers
{
    using System;

    public class EntryPoint
    {
        public static void Main()
        {
            IManufacturerCreator manufacturerCreator = new ManufacturerCreator();

            var manufacturerName = Console.ReadLine();
            Manufacturer manufacturer = manufacturerCreator.CreateManufacturer(manufacturerName);

            IPC pc = manufacturer.CreatePC();
            ILaptop laptop = manufacturer.CreateLaptop();
            IServer server = manufacturer.CreateServer();
            ICommandExecutor commandExecutor = new CommandExecutor();

            while (true)
            {
                var rawCommand = Console.ReadLine();
                if (rawCommand == null)
                {
                    Console.WriteLine("Invalid command!");
                }

                if (rawCommand.StartsWith("Exit"))
                {
                    break;
                }

                var splittedCommand = rawCommand.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (splittedCommand.Length != 2)
                {
                    Console.WriteLine("Invalid command!");
                }

                commandExecutor.Execute(splittedCommand, pc, laptop, server);
            }
        }
    }
}