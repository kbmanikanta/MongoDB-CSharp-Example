using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDBExample.Queries;
using MongoDB.Driver;
using MongoDBExample.Models;
using MongoDBExample.Mappers;

namespace MongoDBExample.Repository
{
    public class MongoRepository<TEntity, TDatabase> : IRepository<IEnumerable<BsonDocument>, string, IList<TFilterQuery>, TEntity>
    {
        private IMongoDatabase mongoDatabase;
        private string document;
        private IMapper<TEntity, BsonDocument> mapper;

        public MongoRepository(TDatabase mongoDatabase, string document, IMapper<TEntity, BsonDocument> mapper)
        {
            this.mongoDatabase = (IMongoDatabase)mongoDatabase;
            this.document = document;
            this.mapper = mapper;
        }

        public IEnumerable<BsonDocument> GetById(string id)
        {
            var filterParam = new TFilterQuery("_id", id, "$eq");
            IList<TFilterQuery> filterParams = new List<TFilterQuery>() { filterParam };

            var filterQuery = new MongoQuery().CreateFilterQuery(filterParams);
            var mongoQuery = this.MongoQuery(filterQuery);
            Task.WaitAll(mongoQuery);
            return mongoQuery.Result;
        }

        public IEnumerable<BsonDocument> GetFiltered(IList<TFilterQuery> filterParams)
        {
            var filterQuery = new MongoQuery().CreateFilterQuery(filterParams);
            var mongoQuery = this.MongoQuery(filterQuery);
            Task.WaitAll(mongoQuery);
            return mongoQuery.Result;
        }

        public bool Create(TEntity recurse)
        {
            BsonDocument bsonRecurse = this.mapper.Mapper(recurse);
            var mongoInsertVal = this.MongoInsert(bsonRecurse);
            Task.WaitAll(mongoInsertVal);
            return false;
        }

        private async Task<IEnumerable<BsonDocument>> MongoQuery(BsonDocument filter)
        {
            IEnumerable<BsonDocument> batch = new List<BsonDocument>();
            var collection = this.mongoDatabase.GetCollection<BsonDocument>(this.document);

            using (var cursor = await collection.FindAsync(filter))
            {
                while (await cursor.MoveNextAsync())
                {
                    batch = cursor.Current;
                    return batch;
                }
            }

            return batch;
        }

        private async Task<bool> MongoInsert(BsonDocument currentDocument)
        {
            var collection = this.mongoDatabase.GetCollection<BsonDocument>(this.document);
            await collection.InsertOneAsync(currentDocument);

            return true;
        }


    }
}
