namespace Computers
{
    using System;
    using System.Linq;

    public class CommandExecutor : ICommandExecutor
    {
        public void Execute(string[] splittedCommand, IPC pc, ILaptop laptop, IServer server)
        {
            var commandName = splittedCommand[0];
            var commandArguments = int.Parse(splittedCommand[1]);

            if (commandName == "Charge")
            {
                laptop.ChargeBattery(commandArguments);
            }
            else if (commandName == "Process")
            {
                server.Process(commandArguments);
            }
            else if (commandName == "Play")
            {
                pc.Play(commandArguments);
            }
        }
    }
}
