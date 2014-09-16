using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Task3
{
    class Program
    {
        private static Products products = new Products();

        static void Main(string[] args)
        {
            while (true)
            {
                var command = Console.ReadLine();
                if (command == "end")
                {
                    break;
                }
                var result = ParseCommand(command);
                Console.WriteLine(result);
            }
        }

        private static string ParseCommand(string command)
        {
            if (command.StartsWith("add"))
            {
                return ParseAddCommand(command);
            }
            else if (command.StartsWith("filter by type"))
            {
                return ParseFilterByTypeCommand(command);
            }
            else if (command.StartsWith("filter by price from"))
            {
                var commandParts = command.Split(' ');
                if (commandParts.Length > 5)
                {
                    return ParseMinMaxPrice(command);
                }
                else
                {
                    return ParseMinPrice(command);
                }
            }
            else if (command.StartsWith("filter by price to"))
            {
                return ParseMaxPrice(command);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        private static string ParseMaxPrice(string command)
        {
            var commandParts = command.Split(' ');
            var max = double.Parse(commandParts[4], CultureInfo.InvariantCulture);
            var listOfProducts = products.All
                                         .Where(p => p.Price <= max)
                                         .OrderBy(p => p.Price)
                                         .ThenBy(p => p.Name)
                                         .Take(10);
            return String.Format("Ok: {0}", String.Join(", ", listOfProducts));
        }

        private static string ParseMinPrice(string command)
        {
            var commandParts = command.Split(' ');
            var min = double.Parse(commandParts[4], CultureInfo.InvariantCulture);
            var listOfProducts = products.All
                                         .Where(p => p.Price >= min)
                                         .OrderBy(p => p.Price)
                                         .ThenBy(p => p.Name)
                                         .Take(10);
            return String.Format("Ok: {0}", String.Join(", ", listOfProducts));
        }

        private static string ParseMinMaxPrice(string command)
        {
            var commandParts = command.Split(' ');
            var min = double.Parse(commandParts[4], CultureInfo.InvariantCulture);
            var max = double.Parse(commandParts[6], CultureInfo.InvariantCulture);
            var listOfProducts = products.All
                                         .Where(p => p.Price >= min && p.Price <= max)
                                         .OrderBy(p => p.Price)
                                         .ThenBy(p => p.Name)
                                         .Take(10);
            return String.Format("Ok: {0}", String.Join(", ", listOfProducts));
        }

        private static string ParseFilterByTypeCommand(string command)
        {
            var commandParts = command.Split(' ');
            var type = commandParts[3];

            if (!products.ProductTypes.ContainsKey(type))
            {
                return String.Format("Error: Type {0} does not exists", type);
            }
            else
            {
                var listOfProducts = products.ProductTypes[type]
                    .OrderBy(p => p.Price)
                    .ThenBy(p => p.Name)
                    .Take(10);
                return String.Format("Ok: {0}", String.Join(", ", listOfProducts));
            }
        }

        private static string ParseAddCommand(string command)
        {
            var commandParts = command.Split(' ');
            var name = commandParts[1];
            var price = double.Parse(commandParts[2], CultureInfo.InvariantCulture);
            var type = commandParts[3];
            var product = new Product(name, price, type);

            if (products.ProductNames.ContainsKey(name))
            {
                return String.Format("Error: Product {0} already exists", name);
            }
            else
            {
                products.ProductNames[name] = product;
                if (products.ProductTypes.ContainsKey(type))
                {
                    products.ProductTypes[type].Add(product);
                }
                else
                {
                    products.ProductTypes[type] = new List<Product>();
                    products.ProductTypes[type].Add(product);
                }
                products.All.Add(product);
                return String.Format("Ok: Product {0} added successfully", name);
            }
        }
    }

    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Type { get; set; }

        public Product(string name, double price, string type)
        {
            this.Name = name;
            this.Price = price;
            this.Type = type;
        }

        public override string ToString()
        {
            return String.Format("{0}({1})", this.Name, this.Price);
        }
    }

    class Products
    {
        public Dictionary<string, Product> ProductNames { get; set; }
        public Dictionary<string, List<Product>> ProductTypes { get; set; }
        public List<Product> All { get; set; }
        public Products()
        {
            this.ProductNames = new Dictionary<string, Product>();
            this.ProductTypes = new Dictionary<string, List<Product>>(); ;
            this.All = new List<Product>();
        }
    }
}
