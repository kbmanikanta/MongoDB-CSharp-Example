using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBExample.Business;
using MongoDBExample.DBConnection;
using MongoDBExample.Models;
using MongoDBExample.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBExample.Factories
{
    public static class GenericBLFactory<TOne, TTwo, TThree>
    {
        public static IBL<TOne, TTwo, TThree> Create(IDBConnection<IMongoDatabase> dbConnection, string databaseName, string clientDocument)
        {
            return new GenericBL<TOne, IMongoDatabase, IEnumerable<BsonDocument>, TTwo, TThree>(dbConnection, databaseName, clientDocument);
        }
    }
}
