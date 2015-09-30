using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBExample.Queries
{
    public class MongoQuery : IQuery<Dictionary<string, string>, BsonDocument>
    {
        public BsonDocument CreateFilterQuery(Dictionary<string, string> filterParams)
        {

            var filterr = new BsonDocument("_id", new BsonDocument("$eq", "1"));
            var filter2 = new BsonDocument("name", new BsonDocument("$eq", "Prueba test"));

            filterr.AddRange(filter2);

            return filterr;
        }
    }
}
