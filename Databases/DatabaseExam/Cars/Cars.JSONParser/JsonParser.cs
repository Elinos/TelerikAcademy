using Cars.Data;
using Cars.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.JSONParser
{
    public class JsonParser
    {
        private List<JsonCar> currentListOfCars;
        private string rootPath;
        private CarsContext db;

        public JsonParser(CarsContext db, string rootPath)
        {
            this.rootPath = rootPath;
            this.db = db;
        }

        public void ParseAllFiles()
        {
            Console.WriteLine("Importing cars from JSON");
            db.Configuration.AutoDetectChangesEnabled = false;
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("From file No {0}", i + 1);
                currentListOfCars = this.LoadFile(rootPath + "data." + i + ".json");
                foreach (var car in currentListOfCars)
                {
                    var index = 0;
                    var currentCarToImport = new Car
                    {
                        Year = car.Year,
                        TransmissionType = (TransmissionType)car.TransmissionType,
                        Model = car.Model,
                        Price = car.Price
                    };
                    var manufacturer = this.db.Manufacturers.FirstOrDefault(m => m.Name == car.ManufacturerName);
                    if (manufacturer == null)
                    {
                        manufacturer = new Manufacturer
                        {
                            Name = car.ManufacturerName
                        };
                    }
                    currentCarToImport.Manufacturer = manufacturer;

                    var dealer = this.db.Dealers.FirstOrDefault(d => d.Name == car.Dealer.Name);
                    if (dealer == null)
                    {
                        dealer = new Dealer
                        {
                            Name = car.Dealer.Name
                        };
                    }
                    var city = this.db.Cities.FirstOrDefault(c => c.Name == car.Dealer.City);
                    if (city == null)
                    {
                        city = new City
                        {
                            Name = car.Dealer.City
                        };
                    }
                    dealer.Cities.Add(city);
                    currentCarToImport.Dealer = dealer;
                    db.Cars.Add(currentCarToImport);
                    db.SaveChanges();
                    index++;
                    if (index % 100 == 0)
                    {
                        Console.Write(".");
                    }
                }
                db.SaveChanges();
                Console.WriteLine("Importing from file No {0} finished!", i + 1);
            }
            db.Configuration.AutoDetectChangesEnabled = true;
            Console.WriteLine("Importing cars from JSON finished!");
        }

        public List<JsonCar> LoadFile(string path)
        {
            var fileAsString = File.ReadAllText(path);
            var listOfCars = JsonConvert.DeserializeObject<List<JsonCar>>(fileAsString);
            return listOfCars;
        }
    }
}
