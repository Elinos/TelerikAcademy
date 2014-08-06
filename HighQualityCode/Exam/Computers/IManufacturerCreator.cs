namespace Computers
{
    using System;
    using System.Linq;

    public interface IManufacturerCreator
    {
        Manufacturer CreateManufacturer(string manufacturerName);
    }
}