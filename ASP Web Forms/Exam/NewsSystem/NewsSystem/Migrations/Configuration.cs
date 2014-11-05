namespace NewsSystem.Migrations
{
    using NewsSystem.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NewsSystem.Models.NewsSystemDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(NewsSystem.Models.NewsSystemDbContext context)
        {
            var seedData = new SeedData();
            var dbContex = new NewsSystemDbContext();
            
            if (context.Articles.Any())
            {
                return;
            }
            
            dbContex.Categories.AddOrUpdate(seedData.Categories.ToArray());
            dbContex.SaveChanges();

            dbContex.Articles.AddOrUpdate(seedData.Articles.ToArray());
            dbContex.SaveChanges();
        }
    }
}