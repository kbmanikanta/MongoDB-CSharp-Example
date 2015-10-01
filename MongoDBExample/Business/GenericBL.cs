using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBExample.DBConnection;
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
    public class GenericBL<T, U, TOne, TTwo, TThree> : IBL<T, TTwo, TThree>
    {
        private IRepository<TOne, TTwo, TThree, T> repository;
        private IMapper<T, BsonDocument> mapper;

        public GenericBL(IDBConnection<U> dbConnection, string databaseName, string document)
        {
            this.repository = RepositoryFactory<TOne, TTwo, TThree, T, U>.Create(dbConnection, databaseName, document);
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

        public T GetById(TTwo id)
        {
            IEnumerable<BsonDocument> result = (IEnumerable<BsonDocument>)this.repository.GetById(id);
            var clientBsonDocument = result.ToList<BsonDocument>().First();
            return this.mapper.Mapper(clientBsonDocument);
        }

        public IEnumerable<T> GetFiltered(TThree query)
        {
            var result = (IEnumerable<BsonDocument>)this.repository.GetFiltered(query);
            IEnumerable<BsonDocument> resultInList = result.ToList();
            IList<T> entityList = new List<T>();
            foreach (var item in resultInList)
            {
                entityList.Add(this.mapper.Mapper(item));
            }

            return entityList;
        }
    }
}
