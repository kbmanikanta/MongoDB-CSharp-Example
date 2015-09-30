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
using MongoDBExample.Models;

namespace MongoDBExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string databaseName = "test";
            string document = "poker";

            //Connection
            var dbConnection = new MongoConnection();
            dbConnection.OpenConnection();
            IMongoDatabase mongoDatabase = dbConnection.GetDatabase(databaseName);

            //Get Repository
            var mongoRepository = new MongoRepository(mongoDatabase, document);


            //Queries

            //First query: GetById
            var resultGetById = mongoRepository.GetById("1");
            Console.WriteLine(resultGetById.Result.ToList<BsonDocument>().ToJson());
            Console.ReadLine();

            //Second query: GetFiltered
            IList<QueryInfo> queryGetFiltered = new List<QueryInfo>();
            queryGetFiltered.Add(new QueryInfo("_id", "1", "$eq"));
            queryGetFiltered.Add(new QueryInfo("name", "Prueba test", "$eq"));

            var resultGetFiltered = mongoRepository.GetFiltered(queryGetFiltered);
            Console.WriteLine(resultGetFiltered.Result.ToList<BsonDocument>().ToJson());

            Console.ReadLine();
        }

        
    }
}
