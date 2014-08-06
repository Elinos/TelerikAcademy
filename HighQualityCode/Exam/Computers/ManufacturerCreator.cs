namespace Computers
{
    using System;
    using System.Linq;

    public class ManufacturerCreator : IManufacturerCreator
    {
        public Manufacturer CreateManufacturer(string manufacturerName)
        {
            Manufacturer manufacturer;
            if (manufacturerName == "HP")
            {
                manufacturer = new HP();
            }
            else if (manufacturerName == "Dell")
            {
                manufacturer = new Dell();
            }
            else if (manufacturerName == "Lenovo")
            {
                manufacturer = new Lenovo();
            }
            else
            {
                throw new InvalidArgumentException("Invalid manufacturer!");
            }

            return manufacturer;
        }
    }
}