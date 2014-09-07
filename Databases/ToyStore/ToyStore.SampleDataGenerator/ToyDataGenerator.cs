using System;
using System.Linq;
using RandomDataGenerator;
using ToyStore.Data;
using System.Collections.Generic;

namespace ToyStore.SampleDataGenerator
{
    public class ToyDataGenerator : DataGenerator, IDataGenerator
    {
        public ToyDataGenerator(ToyStoreEntities db, RandomData random, int count)
            : base(db, random, count)
        {
        }

        public override void Generate()
        {
            Console.WriteLine("Generating Toys");

            var ageRangesIds = this.Db.AgeRanges.Select(a => a.AgeRangeId).ToList();
            var manufacturersIds = this.Db.Manufacturers.Select(m => m.ManufacturerID).ToList();
            var categoriesIds = this.Db.Categories.Select(c => c.CategoryID).ToList();

            for (int i = 0; i < this.Count; i++)
            {
                var newToy = new Toy
                {
                    Name = this.Random.GetString(2, 50),
                    Price = (decimal)Math.Round(this.Random.GetDouble(0.1, 100), 2),
                    Type = this.Random.GetChance(90) ? this.Random.GetString(2, 50) : null,
                    Color = this.Random.GetChance(90) ? this.Random.GetString(2, 50) : null,
                    ManufacturerID = manufacturersIds[this.Random.GetInt(0, manufacturersIds.Count - 1)],
                    AgeRangeID = ageRangesIds[this.Random.GetInt(0, manufacturersIds.Count - 1)]
                };
                if (categoriesIds.Count > 0)
                {
                    var uniqueCategoriesIds = new HashSet<int>();
                    var categoriesInToy = this.Random.GetInt(1, Math.Min(categoriesIds.Count - 1, 10));
                    while (uniqueCategoriesIds.Count != categoriesInToy)
                    {
                        uniqueCategoriesIds.Add(categoriesIds[this.Random.GetInt(0, categoriesIds.Count - 1)]);
                    }
                    foreach (var uniqueCategorieId in uniqueCategoriesIds)
                    {
                        newToy.Categories.Add(this.Db.Categories.Find(uniqueCategorieId));
                    }
                }

                this.Db.Toys.Add(newToy);
                if (i % 100 == 0)
                {
                    Console.Write(".");
                    Db.SaveChanges();
                }
            }
            Console.WriteLine("\nGenerating Toys Done!");
        }
    }
}
