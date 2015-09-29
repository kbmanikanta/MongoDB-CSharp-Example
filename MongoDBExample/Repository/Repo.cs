using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBExample
{
    public class Repo
    {
        public async Task<IEnumerable<BsonDocument>> MongoQuery(IMongoDatabase mongoDatabase)
        {
            IEnumerable<BsonDocument> batch = new List<BsonDocument>();

            var collection = mongoDatabase.GetCollection<BsonDocument>("poker");
            var filter = new BsonDocument();

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
