using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBExample.Mappers;
using MongoDBExample.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBExample.Factories
{
    public static class MongoRepositoryFactory<TEntity, TDatabase>
    {
        public static MongoRepository<TEntity, TDatabase> Create(TDatabase mongoDatabase, string document)
        {
            IMapper<TEntity, BsonDocument> mapper = MongoMapperFactory<TEntity>.Create();
            return new MongoRepository<TEntity, TDatabase>(mongoDatabase, document, mapper);
        }
    }
}
