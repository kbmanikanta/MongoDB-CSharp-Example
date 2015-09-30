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
            var clientsRepository = MongoRepositoryFactory<Client>.Create(mongoDatabase, document);

            var employeeRepository = MongoRepositoryFactory<Employee>.Create(mongoDatabase, document);

            //Queries
            //Third query: Insert
            var client = new Client("11", "Cliente 11");
            clientsRepository.Create(client);

            //Third query: Insert
            var employee = new Employee("18", "Empleado 18", "jardinero");
            employeeRepository.Create(employee);


            //First query: GetById
            var resultClientGetById = clientsRepository.GetById("11");
            Console.WriteLine(resultClientGetById.Result.ToList<BsonDocument>().ToJson());
            var clientBsonDocument = resultClientGetById.Result.ToList<BsonDocument>().First();
            var obtainedClient = new ClientMapper().Mapper(clientBsonDocument);
            Console.WriteLine("Cliente insertado correctamente. Id: {0}, Name: {1}", obtainedClient.Id, obtainedClient.Name);
            Console.ReadLine();

            var resultEmployeeGetById = employeeRepository.GetById("18");
            Console.WriteLine(resultEmployeeGetById.Result.ToList<BsonDocument>().ToJson());
            var employeeBsonDocument = resultEmployeeGetById.Result.ToList<BsonDocument>().First();
            var obtainedEmployee = new EmployeeMapper().Mapper(employeeBsonDocument);
            Console.WriteLine("Employee insertado correctamente. Id: {0}, Name: {1}, WorkStation: {2}", obtainedEmployee.Id, obtainedEmployee.Name, obtainedEmployee.WorkStation);
            Console.ReadLine();


            //Second query: GetFiltered
            IList<QueryInfo> queryGetFiltered = new List<QueryInfo>();
            queryGetFiltered.Add(new QueryInfo("_id", "11", "$eq"));
            queryGetFiltered.Add(new QueryInfo("name", "Cliente 11", "$eq"));
           
            var resultGetFiltered = clientsRepository.GetFiltered(queryGetFiltered);
            Console.WriteLine(resultGetFiltered.Result.ToList<BsonDocument>().ToJson());

            IList<QueryInfo> queryGetFiltered2 = new List<QueryInfo>();
            queryGetFiltered2.Add(new QueryInfo("name", "Empleado 18", "$eq"));
            var resultGetFiltered2 = employeeRepository.GetFiltered(queryGetFiltered2);
            Console.WriteLine(resultGetFiltered2.Result.ToList<BsonDocument>().ToJson());

            Console.ReadLine();
        }

        
    }
}
