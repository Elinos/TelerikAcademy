using System;
using System.Linq;
using Cars.Data;
using Cars.JSONParser;
using Cars.SearchQueriesManager;

namespace Cars.Client
{
    public class Program
    {
        static void Main()
        {
            var jsonFilesDirPath = @"..\..\..\jsonFiles\";
            var db = new CarsContext();
            var jsonParser = new JsonParser(db, jsonFilesDirPath);
            jsonParser.ParseAllFiles();

            string xmlQueriesPath = @"..\..\..\xmlQueries\Queries.xml";
            var queriesManager = new QueriesManager(db, xmlQueriesPath);
            queriesManager.GenerateQueryResults();
        }
    }
}
