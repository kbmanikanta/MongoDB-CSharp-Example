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
using MongoDBExample.Factories;
using MongoDBExample.Mappers;
using MongoDBExample.Business;

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

            //ClientBL
            var clientBLInstance = new ClientBL(mongoDatabase, document);

            //Creation
            var client = new Client("52", "test");

            //Insert
            clientBLInstance.Create(client);

            //GetById
            var obtainedClient = clientBLInstance.GetById(client.Id);
            Console.WriteLine("Cliente insertado correctamente. Id: {0}, Name: {1}", obtainedClient.Id, obtainedClient.Name);
            Console.ReadLine();



            //Second query: GetFiltered
            //IList<QueryInfo> queryGetFiltered = new List<QueryInfo>();
            //queryGetFiltered.Add(new QueryInfo("_id", "85", "$eq"));
            //queryGetFiltered.Add(new QueryInfo("name", "Prueba test", "$eq"));

            //var resultGetFiltered = clientsRepository.GetFiltered(queryGetFiltered);
            //Console.WriteLine(resultGetFiltered.Result.ToList<BsonDocument>().ToJson());



            Console.ReadLine();
        }

        
    }
}
