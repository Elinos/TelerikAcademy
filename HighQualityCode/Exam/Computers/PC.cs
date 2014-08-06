namespace Computers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PC : Computer, IPC
    {
        public PC(Cpu cpu, RAM ram, IEnumerable<HardDrive> hardDrives)
            : base(cpu, ram, hardDrives)
        {
            this.VideoCard.IsMonochrome = false;
        }

        public void Play(int guessNumber)
        {
            this.Cpu.GenerateRandomNumber(1, 10);
            var number = this.Cpu.GenerateRandomNumber(1, 10);

            if (number != guessNumber)
            {
                this.Motherboard.DrawOnVideoCard(string.Format("You didn't guess the number {0}.", number));
            }
            else
            {
                this.Motherboard.DrawOnVideoCard("You win!");
            }
        }
    }
}