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
            string clientDocument = "client";
            string employeeDocument = "employee";

            //Connection
            var dbConnection = new MongoConnection();
            dbConnection.OpenConnection();
            IMongoDatabase mongoDatabase = dbConnection.GetDatabase(databaseName);

            //ClientBL
            var clientBL = new GenericBL<Client>(mongoDatabase, clientDocument);
            var employeeBL = new GenericBL<Employee>(mongoDatabase, employeeDocument);

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
            IList<QueryInfo> queryGetFiltered = new List<QueryInfo>();
            queryGetFiltered.Add(new QueryInfo("_id", "55554", "$eq"));
            queryGetFiltered.Add(new QueryInfo("name", "Joan", "$eq"));
            var resultGetFiltered = clientBL.GetFiltered(queryGetFiltered);
            Console.WriteLine("Clientes encontrados:");
            foreach (var oneClient in resultGetFiltered)
            {
                Console.WriteLine("Cliente encontrado: Id: {0}, Name: {1}", oneClient.Id, oneClient.Name);
            }

            IList<QueryInfo> queryGetFiltered2 = new List<QueryInfo>();
            queryGetFiltered2.Add(new QueryInfo("_id", "12", "$eq"));
            queryGetFiltered2.Add(new QueryInfo("workstation", "Wolters Kluwers", "$eq"));
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
