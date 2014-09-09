using System;
using System.Linq;
using Company.Data;
using RandomDataGenerator;

namespace Company.SimpleDataGenerator
{
    public abstract class DataGenerator : IDataGenerator
    {
        private CompanyEntities db;
        private RandomData random;
        private int count;

        public DataGenerator(CompanyEntities db, RandomData random, int count)
        {
            this.db = db;
            this.random = random;
            this.count = count;
        }

        public CompanyEntities Db
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
