namespace Computers
{
    using System;
    using System.Linq;

    public interface ICommandExecutor
    {
        void Execute(string[] splittedCommand, IPC pc, ILaptop laptop, IServer server);
    }
}
