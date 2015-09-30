using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBExample.Queries
{
    public class MongoQuery : IQuery<IList<QueryInfo>, BsonDocument>
    {
        public BsonDocument CreateFilterQuery(IList<QueryInfo> filterParams)
        {
            var filter = new BsonDocument();

            foreach (var item in filterParams)
            {
                var newFilter = new BsonDocument(item.Key, new BsonDocument(item.QueryOperator, item.Value));
                filter.AddRange(newFilter);
            }

            return filter;
        }
    }
}
