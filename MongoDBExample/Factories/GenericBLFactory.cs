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
    public static class GenericBLFactory<TEntity, TFieldId, TListFilterQuery, TDBFormat>
    {
        public static IBL<TEntity, TFieldId, TListFilterQuery> Create(IDBConnection<IMongoDatabase> dbConnection, string databaseName, string clientDocument)
        {
            return new GenericBL<TEntity, IMongoDatabase, IEnumerable<TDBFormat>, TFieldId, TListFilterQuery, TDBFormat>(dbConnection, databaseName, clientDocument);
        }
    }
}
