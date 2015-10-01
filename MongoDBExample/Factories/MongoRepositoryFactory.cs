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
    public static class MongoRepositoryFactory<T>
    {
        public static MongoRepository<T> Create(IMongoDatabase mongoDatabase, string document)
        {
            IMapper<T, BsonDocument> mapper = MongoMapperFactory<T>.Create();
            return new MongoRepository<T>(mongoDatabase, document, mapper);
        }
    }
}
