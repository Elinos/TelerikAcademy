using System;
using System.Collections.Generic;
using System.Linq;

namespace Task4
{
    class Program
    {
        static List<Town> towns = new List<Town>(); 

        static void Main(string[] args)
        {
            var numberOfTowns = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfTowns; i++)
            {
                var line = Console.ReadLine().Split(' ');
                var currentTown = new Town(line[1], long.Parse(line[0]));
                foreach (var town in towns)
                {
                    town.Connections.Add(currentTown);
                }
                towns.Add(currentTown);
            }
            Console.WriteLine(numberOfTowns - 1);
        }
    }

    class Town
    {
        public string Name { get; set; }
        public long Population { get; set; }
        public List<Town> Connections { get; set; }
        public Town(string name, long population)
        {
            this.Name = name;
            this.Population = population;
            this.Connections = new List<Town>();
        }
    }
}
