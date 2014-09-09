using System;
using System.Data.Entity;
using System.Linq;
using Cars.Data.Migrations;
using Cars.Models;

namespace Cars.Data
{
    public class CarsContext : DbContext
    {
        public CarsContext()
            : base("CarsDatabase")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CarsContext, Configuration>());
        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Dealer> Dealers { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
    }
}
