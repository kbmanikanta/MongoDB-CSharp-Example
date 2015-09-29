using MongoDB.Driver;
using MongoDBExample.DBConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using FluentAssertions;
using MongoDBExample.Repository;

namespace MongoDBExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string databaseName = "test";

            var dbConnection = new MongoConnection();
            dbConnection.OpenConnection();
            IMongoDatabase mongoDatabase = dbConnection.GetDatabase(databaseName);

            var mongoQuery = new MongoRepository(mongoDatabase).GetById("1");

            Console.WriteLine(mongoQuery.Result.ToList<BsonDocument>());
            Console.ReadLine();
        }

        
    }
}
