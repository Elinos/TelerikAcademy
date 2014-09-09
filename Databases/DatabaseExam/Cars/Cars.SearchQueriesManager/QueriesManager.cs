using System;
using System.Linq;
using System.Xml.Linq;
using Cars.Data;
using Cars.Models;
using System.Globalization;

namespace Cars.SearchQueriesManager
{
    public class QueriesManager
    {
        private const string OutputDirPath = @"..\..\..\xmlQueries\Output\";
        private string XmlFilePath;
        private CarsContext db;
        public QueriesManager(CarsContext db, string xmlFilePath)
        {
            this.XmlFilePath = xmlFilePath;
            this.db = db;
        }

        public void GenerateQueryResults()
        {
            Console.WriteLine("Generating output XML files");
            XElement xmlFile = XElement.Load(XmlFilePath);
            var queriesAsXML = xmlFile.Elements();
            foreach (var xmlQuery in queriesAsXML)
            {
                var outputFileName = xmlQuery.Attribute("OutputFileName").Value;
                XElement resultFile = CreateInitialXElement();
                var queryInCars = db.Cars.AsQueryable();
                queryInCars = ParseOrderByType(xmlQuery, queryInCars);
                queryInCars = ParseWhereClauses(xmlQuery, queryInCars);
                var resultCars = queryInCars.Select(c => new
                {
                    Manufacturer = c.Manufacturer.Name,
                    Model = c.Model,
                    Year = c.Year,
                    Price = c.Price,
                    TransmissionType = c.TransmissionType,
                    Dealer = new
                    {
                        Name = c.Dealer.Name,
                        Cities = c.Dealer.Cities.Select(t => t.Name)
                    }
                }).ToList();

                foreach (var car in resultCars)
                {
                    var carXML = new XElement("Car");
                    var manNameAttribute = new XAttribute("Manufacturer", car.Manufacturer);
                    carXML.Add(manNameAttribute);
                    var modelAttribute = new XAttribute("Model", car.Model);
                    carXML.Add(modelAttribute);
                    var yearAttribute = new XAttribute("Year", car.Year);
                    carXML.Add(yearAttribute);
                    var priceAttribute = new XAttribute("Price", car.Price);
                    carXML.Add(priceAttribute);
                    carXML.Add(new XElement("TransmissionType", car.TransmissionType.ToString().ToLower()));
                    var dealerXML = new XElement("Dealer");
                    var dealerNameAttribute = new XAttribute("Name", car.Dealer.Name);
                    dealerXML.Add(dealerNameAttribute);
                    foreach (var city in car.Dealer.Cities)
                    {
                        var cityXML = new XElement("City", city);
                        dealerXML.Add(cityXML);
                    }
                    carXML.Add(dealerXML);
                    resultFile.Add(carXML);
                }

                resultFile.Save(OutputDirPath + outputFileName);
                Console.WriteLine("Output file {0} generated!", outputFileName);
            }
        }

        private IQueryable<Car> ParseWhereClauses(XElement xmlQuery, IQueryable<Car> queryInCars)
        {
            var currentQuerryInCars = queryInCars;
            var whereClauses = xmlQuery.Element("WhereClauses").Elements("WhereClause");
            foreach (var whereClause in whereClauses)
            {
                var propertyName = whereClause.Attribute("PropertyName").Value;
                var typeName = whereClause.Attribute("Type").Value;
                var value = whereClause.Value;
                currentQuerryInCars = ParseWhereClause(propertyName, typeName, value, currentQuerryInCars);
            }
            return currentQuerryInCars;
        }

        private IQueryable<Car> ParseWhereClause(string propertyName, string typeName, string value, IQueryable<Car> currentQuerryInCars)
        {
            var newCurrentQuery = currentQuerryInCars;

            if (propertyName == "Id")
            {
                int id = int.Parse(value);
                switch (typeName)
                {
                    case "Equals":
                        newCurrentQuery = newCurrentQuery.Where(c => c.Id == id);
                        break;
                    case "GreaterThan":
                        newCurrentQuery = newCurrentQuery.Where(c => c.Id > id);
                        break;
                    case "LessThan":
                        newCurrentQuery = newCurrentQuery.Where(c => c.Id < id);
                        break;
                    default:
                        break;
                }
            }
            else if (propertyName == "Year")
            {
                int year = int.Parse(value);
                switch (typeName)
                {
                    case "Equals":
                        newCurrentQuery = newCurrentQuery.Where(c => c.Year == year);
                        break;
                    case "GreaterThan":
                        newCurrentQuery = newCurrentQuery.Where(c => c.Year > year);
                        break;
                    case "LessThan":
                        newCurrentQuery = newCurrentQuery.Where(c => c.Year < year);
                        break;
                    default:
                        break;
                }
            }
            else if (propertyName == "Price")
            {
                decimal price = decimal.Parse(value, CultureInfo.InvariantCulture);
                switch (typeName)
                {
                    case "Equals":
                        newCurrentQuery = newCurrentQuery.Where(c => c.Price == price);
                        break;
                    case "GreaterThan":
                        newCurrentQuery = newCurrentQuery.Where(c => c.Price > price);
                        break;
                    case "LessThan":
                        newCurrentQuery = newCurrentQuery.Where(c => c.Price < price);
                        break;
                    default:
                        break;
                }
            }
            else if (propertyName == "Model")
            {
                string model = value;
                switch (typeName)
                {
                    case "Equals":
                        newCurrentQuery = newCurrentQuery.Where(c => c.Model== model);
                        break;
                    case "Contains":
                        newCurrentQuery = newCurrentQuery.Where(c => c.Model.Contains(model));
                        break;
                    default:
                        break;
                }
            }
            else if (propertyName == "Manufacturer")
            {
                string manufacturerName = value;
                switch (typeName)
                {
                    case "Equals":
                        newCurrentQuery = newCurrentQuery.Where(c => c.Manufacturer.Name == manufacturerName);
                        break;
                    case "Contains":
                        newCurrentQuery = newCurrentQuery.Where(c => c.Manufacturer.Name.Contains(manufacturerName));
                        break;
                    default:
                        break;
                }
            }
            else if (propertyName == "Dealer")
            {
                string dealerName = value;
                switch (typeName)
                {
                    case "Equals":
                        newCurrentQuery = newCurrentQuery.Where(c => c.Dealer.Name == dealerName);
                        break;
                    case "Contains":
                        newCurrentQuery = newCurrentQuery.Where(c => c.Dealer.Name.Contains(dealerName));
                        break;
                    default:
                        break;
                }
            }
            else if (propertyName == "City")
            {
                string cityName = value;
                switch (typeName)
                {
                    case "Equals":
                        newCurrentQuery = newCurrentQuery
                            .Where(c => c.Dealer.Cities.Select(t => t.Name).Contains(cityName));
                        break;
                    default:
                        break;
                }
            }
            return newCurrentQuery;
        }



        private IQueryable<Car> ParseOrderByType(XElement xmlQuery, IQueryable<Car> queryInCars)
        {
            var newQuery = queryInCars;
            var orderByType = xmlQuery.Element("OrderBy").Value;
            switch (orderByType)
            {
                case "Id":
                    queryInCars = queryInCars.OrderBy(c => c.Id);
                    break;
                case "Year":
                    queryInCars = queryInCars.OrderBy(c => c.Year);
                    break;
                case "Model":
                    queryInCars = queryInCars.OrderBy(c => c.Model);
                    break;
                case "Price":
                    queryInCars = queryInCars.OrderBy(c => c.Price);
                    break;
                case "Manufacturer":
                    queryInCars = queryInCars.OrderBy(c => c.Manufacturer.Name);
                    break;
                case "Dealer":
                    queryInCars = queryInCars.OrderBy(c => c.Dealer.Name);
                    break;
                default:
                    break;
            }

            return newQuery;
        }

        private XElement CreateInitialXElement()
        {
            XNamespace xsi = "http://www.w3.org/2001/XMLSchema-instance";
            XNamespace xsd = "http://www.w3.org/2001/XMLSchema";

            XElement resultFile = new XElement("Cars",
                new XAttribute(XNamespace.Xmlns + "xsi", xsi),
                new XAttribute(XNamespace.Xmlns + "xsd", xsd));
            return resultFile;
        }
    }
}
