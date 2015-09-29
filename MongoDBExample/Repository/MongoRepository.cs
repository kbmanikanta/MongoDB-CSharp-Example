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
    public class MongoRepository : IRepository<Task<IEnumerable<BsonDocument>>, string, string, string>
    {
        private IMongoDatabase mongoDatabase;

        public MongoRepository(IMongoDatabase mongoDatabase)
        {
            this.mongoDatabase = mongoDatabase;
        }

        public Task<IEnumerable<BsonDocument>> GetById(string id)
        {
            var mongoQuery = this.MongoQuery(this.mongoDatabase);
            Task.WaitAll(mongoQuery);
            return mongoQuery;
        }

        //public IEnumerable<BsonDocument> GetFiltered(IQuery<string, string> query)
        //{
        //    throw new NotImplementedException();
        //}


        private async Task<IEnumerable<BsonDocument>> MongoQuery(IMongoDatabase mongoDatabase)
        {
            IEnumerable<BsonDocument> batch = new List<BsonDocument>();

            var collection = mongoDatabase.GetCollection<BsonDocument>("poker");
            var filter = Builders<BsonDocument>.Filter.Eq("_id", "1");

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
