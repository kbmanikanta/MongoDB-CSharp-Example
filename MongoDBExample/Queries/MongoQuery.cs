using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBExample.Queries
{
    public class MongoQuery : IQuery<Dictionary<string, string>, FilterDefinition<BsonDocument>>
    {
        public FilterDefinition<BsonDocument> CreateFilterQuery(Dictionary<string, string> filterParams)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", "1");
            return filter;
        }
    }
}
