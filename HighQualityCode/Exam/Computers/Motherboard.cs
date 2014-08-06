namespace Computers
{
    using System;
    using System.Linq;

    public class Motherboard : IMotherboard
    {
        private readonly RAM ram;

        private readonly VideoCard videoCard;

        public Motherboard(RAM ram, VideoCard videoCard)
        {
            this.ram = ram;
            this.videoCard = videoCard;
        }

        public int LoadRamValue()
        {
            var data = this.ram.LoadValue();
            return data;
        }

        public void SaveRamValue(int value)
        {
            this.ram.SaveValue(value);
        }

        public void DrawOnVideoCard(string data)
        {
            this.videoCard.Draw(data);
        }
    }
}