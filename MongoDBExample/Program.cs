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
using MongoDBExample.Factories;

namespace MongoDBExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string databaseName = "test";
            string document = "poker";

            var dbConnection = new MongoConnection();
            dbConnection.OpenConnection();
            IMongoDatabase mongoDatabase = dbConnection.GetDatabase(databaseName);

            var mongoRepository = MongoRepositoryFactory.Create(mongoDatabase, document);
            var result = mongoRepository.GetById("1").Result;

            Console.WriteLine(result.ToList<BsonDocument>().ToJson());
            Console.ReadLine();
        }

        
    }
}
