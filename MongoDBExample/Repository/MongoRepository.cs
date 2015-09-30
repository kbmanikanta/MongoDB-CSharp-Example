using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDBExample.Queries;
using MongoDB.Driver;
using MongoDBExample.Models;

namespace MongoDBExample.Repository
{
    public class MongoRepository<T> : IRepository<Task<IEnumerable<BsonDocument>>, string, IList<QueryInfo>, T>
    {
        private IMongoDatabase mongoDatabase;
        private string document;

        public MongoRepository(IMongoDatabase mongoDatabase, string document)
        {
            this.mongoDatabase = mongoDatabase;
            this.document = document;
        }

        public Task<IEnumerable<BsonDocument>> GetById(string id)
        {

            var filterParam = new QueryInfo("_id", id, "$eq");
            IList<QueryInfo> filterParams = new List<QueryInfo>() { filterParam };

            var filterQuery = new MongoQuery().CreateFilterQuery(filterParams);
            var mongoQuery = this.MongoQuery(filterQuery);
            Task.WaitAll(mongoQuery);
            return mongoQuery;
        }

        public Task<IEnumerable<BsonDocument>> GetFiltered(IList<QueryInfo> filterParams)
        {
            var filterQuery = new MongoQuery().CreateFilterQuery(filterParams);
            var mongoQuery = this.MongoQuery(filterQuery);
            Task.WaitAll(mongoQuery);
            return mongoQuery;
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

        public bool Create(T recurse)
        {
            return false;
        }
    }
}
