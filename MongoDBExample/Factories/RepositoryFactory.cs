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
using MongoDBExample.DBConnection;

namespace MongoDBExample.Factories
{
    public static class RepositoryFactory<TOne, TTwo, TThree, TFour, TFive>
    {
        public static IRepository<TOne, TTwo, TThree, TFour> Create(IDBConnection<TFive> dbConnection, string databaseName, string document)
        {
            IMapper<TFour, BsonDocument> mapper = MongoMapperFactory<TFour>.Create();
            IRepository<TOne, TTwo, TThree, TFour> repo = (IRepository < TOne, TTwo, TThree, TFour>)new MongoRepository<TFour, TFive>(dbConnection.GetDatabase(databaseName), document, mapper);
            return repo;
        }
    }
}
