using System;
using System.Linq;
using RandomDataGenerator;
using ToyStore.Data;
using System.Collections.Generic;

namespace ToyStore.SampleDataGenerator
{
    public class AgeRangeDataGenerator : DataGenerator, IDataGenerator
    {
        public AgeRangeDataGenerator(ToyStoreEntities db, RandomData random, int count)
            : base(db, random, count)
        {
        }
        public override void Generate()
        {
            Console.WriteLine("Generating Age ranges");

            var uniqueAgeRanges = new HashSet<AgeRanx>();
            while (uniqueAgeRanges.Count != this.Count)
            {
                var minAge = this.Random.GetInt(0, 20);
                var maxAge = minAge + this.Random.GetInt(1, 5);

                var newAgeRange = new AgeRanx
                {
                    MaxAge = maxAge,
                    MinAge = minAge
                };
                if (!uniqueAgeRanges.Any(a => a.MinAge == minAge && a.MaxAge == maxAge))
                {
                    uniqueAgeRanges.Add(newAgeRange);
                }
            }
            var index = 0;

            foreach (var uniqueAgeRange in uniqueAgeRanges)
            {
                Db.AgeRanges.Add(uniqueAgeRange);
                index++;
                if (index % 100 == 0)
                {
                    Console.Write(".");
                    Db.SaveChanges();
                }
            }
            Console.WriteLine("\nGenerating Age Ranges Done!");
        }
    }
}
