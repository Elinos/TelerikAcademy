using System;
using System.Linq;
using RandomDataGenerator;
using ToyStore.Data;

namespace ToyStore.SampleDataGenerator
{
    public class CategoryDataGenerator: DataGenerator, IDataGenerator
    {
        public CategoryDataGenerator(ToyStoreEntities db, RandomData random, int count)
            : base(db, random, count)
        {
        }
        public override void Generate()
        {
            Console.WriteLine("Generating Categories");
            for (int i = 0; i < this.Count; i++)
            {
                var newCategory = new Category
                {
                    Name = this.Random.GetString(2, 50)
                };

                Db.Categories.Add(newCategory);

                if (i % 100 == 0)
                {
                    Console.Write(".");
                    Db.SaveChanges();
                }
            }
            Console.WriteLine("\nGenerating Categories Done!");
        }
    }
}
