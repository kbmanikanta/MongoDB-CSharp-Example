using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDBExample.Queries;
using MongoDB.Driver;

namespace MongoDBExample.Repository
{
    public class MongoRepository : IRepository<Task<IEnumerable<BsonDocument>>, string, Dictionary<string, string>>
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
            Dictionary<string, string> filterParams = new Dictionary<string, string>();
            filterParams.Add("_id", id);
            var filterQuery = new MongoQuery().CreateFilterQuery(filterParams);
            var mongoQuery = this.MongoQuery(filterQuery);
            Task.WaitAll(mongoQuery);
            return mongoQuery;
        }

        public Task<IEnumerable<BsonDocument>> GetFiltered(Dictionary<string, string> filterParams)
        {
            var filterQuery = new MongoQuery().CreateFilterQuery(filterParams);
            var mongoQuery = this.MongoQuery(filterQuery);
            Task.WaitAll(mongoQuery);
            return mongoQuery;
        }

        private async Task<IEnumerable<BsonDocument>> MongoQuery(FilterDefinition<BsonDocument> filter)
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
    }
}
