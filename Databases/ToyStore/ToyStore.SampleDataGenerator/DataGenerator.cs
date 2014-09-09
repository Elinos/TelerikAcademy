using System;
using System.Linq;
using RandomDataGenerator;
using ToyStore.Data;

namespace ToyStore.SampleDataGenerator
{
    public abstract class DataGenerator : IDataGenerator
    {
        private ToyStoreEntities db;
        private RandomData random;
        private int count;

        public DataGenerator(ToyStoreEntities db, RandomData random, int count)
        {
            this.db = db;
            this.random = random;
            this.count = count;
        }

        public ToyStoreEntities Db
        {
            get
            {
                return this.db;
            }
        }

        public RandomData Random
        {
            get
            {
                return this.random;
            }
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public abstract void Generate();
    }
}
