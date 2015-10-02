using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBExample.Business;
using MongoDBExample.DBConnection;
using MongoDBExample.Mappers;
using MongoDBExample.Models;
using MongoDBExample.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBExample.Factories
{
    public static class GenericBLFactory<TEntity, TFieldId, TListFilterQuery, TDBFormat, TDatabase>
    {
        public static IBL<TEntity, TFieldId, TListFilterQuery> Create(IDBConnection<TDatabase> dbConnection, string databaseName, string clientDocument, IMapper<TEntity, TDBFormat> mapper)
        {
            return new GenericBL<TEntity, TDatabase, IEnumerable<TDBFormat>, TFieldId, TListFilterQuery, TDBFormat>(dbConnection, databaseName, clientDocument, mapper);
        }
    }
}
