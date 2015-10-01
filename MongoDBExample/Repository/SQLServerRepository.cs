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
    public class SQLServerRepository<TEntity, TDatabase> : IRepository<IEnumerable<BsonDocument>, string, IList<FilterQuery>, TEntity>
    {
        private IMongoDatabase sqlDataBase;
        private string document;
        private IMapper<TEntity, BsonDocument> mapper;

        public SQLServerRepository(TDatabase sqlDataBase, string document, IMapper<TEntity, BsonDocument> mapper)
        {
            this.sqlDataBase = (IMongoDatabase)sqlDataBase;
            this.document = document;
            this.mapper = mapper;
        }

        public IEnumerable<BsonDocument> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BsonDocument> GetFiltered(IList<FilterQuery> query)
        {
            throw new NotImplementedException();
        }

        public bool Create(TEntity recurse)
        {
            throw new NotImplementedException();
        }
    }
}
