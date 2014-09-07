using System;
using System.Linq;
using RandomDataGenerator;
using ToyStore.Data;
using System.Collections.Generic;

namespace ToyStore.SampleDataGenerator
{
    public class ManufacturerDataGenerator : DataGenerator, IDataGenerator
    {
        public ManufacturerDataGenerator(ToyStoreEntities db, RandomData random, int count)
            : base(db, random, count)
        {
        }
        public override void Generate()
        {
            Console.WriteLine("Generating Manufacturers");


            var uniqueManufacturersNames = new HashSet<string>();

            while (uniqueManufacturersNames.Count != this.Count)
            {
                uniqueManufacturersNames.Add(this.Random.GetString(2, 50));
            }
            var index = 0;
            foreach (var uniqueName in uniqueManufacturersNames)
            {
                var newManufacturer = new Manufacturer
                {
                    Name = uniqueName,
                    Country = this.Random.GetString(2, 50)
                };
                Db.Manufacturers.Add(newManufacturer);
                index++;
                if (index % 100 == 0)
                {
                    Console.Write(".");
                    Db.SaveChanges();
                }
            }

            Console.WriteLine("\nGenerating Manufacturers Done!");
        }
    }
}
