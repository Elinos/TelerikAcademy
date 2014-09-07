using RandomDataGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using ToyStore.Data;

namespace ToyStore.SampleDataGenerator
{
    public class SampleDataGenerator
    {
        static void Main()
        {
            var random = RandomData.Instance;
            var db = new ToyStoreEntities();
            db.Configuration.AutoDetectChangesEnabled = false;

            var listOfGenerators = new List<IDataGenerator>
            {
                new CategoryDataGenerator(db, random, 100),
                new ManufacturerDataGenerator(db, random, 50),
                new AgeRangeDataGenerator(db, random, 100),
                new ToyDataGenerator(db, random, 20000)
            };

            foreach (var generator in listOfGenerators)
            {
                generator.Generate();
                db.SaveChanges();
            }
        }
    }
}
