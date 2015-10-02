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
    public static class MongoRepositoryFactory<TEntity, TDatabase, TDBFormat>
    {
        public static MongoRepository Create(TDatabase mongoDatabase, string document)
        {
            IMapper<TEntity, TDBFormat> mapper = MongoMapperFactory<TEntity, TDBFormat>.Create();
            return new MongoRepository((IMongoDatabase)mongoDatabase, document);
        }
    }
}
