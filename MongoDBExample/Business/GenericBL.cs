using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBExample.Factories;
using MongoDBExample.Mappers;
using MongoDBExample.Models;
using MongoDBExample.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBExample.Business
{
    public class GenericBL<T> : IBL<T, string, IList<QueryInfo>>
    {
        private MongoRepository<T> repository;
        private IMapper<T, BsonDocument> mapper;

        public GenericBL(IMongoDatabase mongoDatabase, string document)
        {
            this.repository = MongoRepositoryFactory<T>.Create(mongoDatabase, document);
            this.mapper = MongoMapperFactory<T>.Create();
        }

        public bool Create(T entity)
        {
            try
            {
                return this.repository.Create(entity);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception Message: " + ex.Message);
                return false;
            } 
        }

        public T GetById(string id)
        {
            var result = this.repository.GetById(id);
            var clientBsonDocument = result.Result.ToList<BsonDocument>().First();
            return this.mapper.Mapper(clientBsonDocument);
        }

        public IEnumerable<T> GetFiltered(IList<QueryInfo> query)
        {
            var result = this.repository.GetFiltered(query);
            IEnumerable<BsonDocument> resultInList = result.Result.ToList();
            IList<T> entityList = new List<T>();
            foreach (var item in resultInList)
            {
                entityList.Add(this.mapper.Mapper(item));
            }

            return entityList;
        }
    }
}
