using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBExample.DBConnection;
using MongoDBExample.Mappers;
using MongoDBExample.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBExample.Factories 
{
    public static class RepositoryFactory<TListDBFormat, TFieldId, TListTFilterQuery, TEntity, TDatabase>
    {
        public static IRepository<TListDBFormat, TFieldId, TListTFilterQuery, TEntity> Create(IDBConnection<TDatabase> dbConnection, string databaseName, string document)
        {
            IMapper<TEntity, BsonDocument> mapper = MongoMapperFactory<TEntity>.Create();
            IRepository<TListDBFormat, TFieldId, TListTFilterQuery, TEntity> repo = (IRepository < TListDBFormat, TFieldId, TListTFilterQuery, TEntity>)new MongoRepository<TEntity, TDatabase>(dbConnection.GetDatabase(databaseName), document);
            return repo;
        }
    }
}
