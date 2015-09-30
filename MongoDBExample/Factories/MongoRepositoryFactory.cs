using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBExample.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBExample.Factories
{
    public static class MongoRepositoryFactory
    {
        public static MongoRepository Create(IMongoDatabase mongoDatabase, string document)
        {
            return new MongoRepository(mongoDatabase, document);
        }
    }
}
