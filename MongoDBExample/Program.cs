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
using Autofac;
using System.Data.SqlClient;
using System.Data;

namespace MongoDBExample
{
    class Program
    {
        static void Main(string[] args)
        {
            IDBConnection<SqlConnection> sqlServerConnection = new SQLServerConnection();
            var sqlServerDatabase = sqlServerConnection.GetDatabase("");
            var sqlServerMapper = new SQLServerMapper<Client, DataSet>();


            var sqlClientBL = GenericBLFactory<Client, Guid, IList<FilterQuery>, DataSet, SqlConnection>.Create(sqlServerConnection, "", "", sqlServerMapper);
            sqlClientBL.GetById(new Guid());
            //var sqlServerRepo = new SQLServerRepository<Client>("", null);
            //sqlServerRepo.GetById("5");

            string databaseName = "test";
            string clientDocument = "client";
            string employeeDocument = "employee";

            // IoC configuration
            var containerBuilder = new ContainerBuilder();
            IConfigIoC manager = new IoCManager(containerBuilder);
            manager.Configure();
            IContainer builder = containerBuilder.Build();

            var dbConnection = builder.Resolve<IDBConnection<IMongoDatabase>>();

            //Connection
            dbConnection.OpenConnection();
            IMongoDatabase mongoDatabase = dbConnection.GetDatabase(databaseName);

            //ClientBL
            var clientMongoMapper = new MongoMapper<Client, BsonDocument>();
            var clientBL = GenericBLFactory<Client, string, IList<FilterQuery>, BsonDocument, IMongoDatabase>.Create(dbConnection, databaseName, clientDocument, clientMongoMapper);
            var employeeMongoMapper = new MongoMapper<Employee, BsonDocument>();
            var employeeBL = GenericBLFactory<Employee, string, IList<FilterQuery>, BsonDocument, IMongoDatabase>.Create(dbConnection, databaseName, employeeDocument, employeeMongoMapper);

            //Creation
            var client = new Client("55554", "Joan");
            var employee = new Employee("12", "Joan", "Wolters Kluwers");

            //Insert
            clientBL.Create(client);
            employeeBL.Create(employee);

            //GetById
            var obtainedClient = clientBL.GetById(client.Id);
            Console.WriteLine("Cliente insertado correctamente. Id: {0}, Name: {1}", obtainedClient.Id, obtainedClient.Name);

            var obtainedEmployee = employeeBL.GetById(employee.Id);
            Console.WriteLine("Employee insertado correctamente. Id: {0}, Name: {1}, WorkStation: {2}", obtainedEmployee.Id, obtainedEmployee.Name, obtainedEmployee.WorkStation);
            Console.ReadLine();

            //GetFiltered
            IList<FilterQuery> queryGetFiltered = new List<FilterQuery>();
            queryGetFiltered.Add(new FilterQuery("_id", "55554", "$eq"));
            queryGetFiltered.Add(new FilterQuery("name", "Joan", "$eq"));
            var resultGetFiltered = clientBL.GetFiltered(queryGetFiltered);
            Console.WriteLine("Clientes encontrados:");
            foreach (var oneClient in resultGetFiltered)
            {
                Console.WriteLine("Cliente encontrado: Id: {0}, Name: {1}", oneClient.Id, oneClient.Name);
            }

            IList<FilterQuery> queryGetFiltered2 = new List<FilterQuery>();
            queryGetFiltered2.Add(new FilterQuery("_id", "12", "$eq"));
            queryGetFiltered2.Add(new FilterQuery("workstation", "Wolters Kluwers", "$eq"));
            var resultGetFiltered2 = employeeBL.GetFiltered(queryGetFiltered2);
            Console.WriteLine("Employees encontrados:");
            foreach (var oneEmployee in resultGetFiltered2)
            {
                Console.WriteLine("Employee encontrado Id: {0}, Name: {1}, WorkStation: {2}", oneEmployee.Id, oneEmployee.Name, oneEmployee.WorkStation);
            }

            Console.ReadLine();
        }


    }
}
