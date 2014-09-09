using System;
using System.Linq;

namespace Cars.JSONParser
{
    public class JsonCar
    {
        public int Year { get; set; }
        public int TransmissionType { get; set; }
        public string ManufacturerName { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public JsonDealer Dealer { get; set; }
    }
}
