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
            BsonDocument filterQuery = new BsonDocument();

            foreach (var item in filterParams)
            {
                BsonDocument newFilter = new BsonDocument(item.Key, new BsonDocument(item.QueryOperator, item.Value));
                filterQuery.AddRange(newFilter);
            }

            return filterQuery;
        }
    }
}
