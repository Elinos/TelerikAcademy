namespace Computers
{
    using System;
    using System.Linq;

    public class VideoCard
    {
        public bool IsMonochrome { get; set; }

        public void Draw(string data)
        {
            if (this.IsMonochrome)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(data);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(data);
                Console.ResetColor();
            }
        }
    }
}