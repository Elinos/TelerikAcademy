namespace Computers
{
    using System;
    using System.Linq;

    /// <summary>
    /// Iterface for motherboard component.
    /// It can load values from the RAM, save values to the RAM and draw on the video card.
    /// </summary>
    public interface IMotherboard
    {
        /// <summary>
        /// Loads values from computer RAM.
        /// </summary>
        /// <returns>The stored value</returns>
        int LoadRamValue();

        /// <summary>
        /// Saves value to comuters RAM
        /// </summary>
        /// <param name="value">The value the will be saved.</param>
        void SaveRamValue(int value);

        /// <summary>
        /// Draws the corresponding data to the video card.
        /// </summary>
        /// <param name="data">The data that we want to draw.</param>
        void DrawOnVideoCard(string data);
    }
}