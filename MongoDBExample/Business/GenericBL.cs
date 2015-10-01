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
    public class GenericBL<TEntity, TDatabase, TListDBFormat, TFieldId, TListFilterQuery> : IBL<TEntity, TFieldId, TListFilterQuery>
    {
        private IRepository<TListDBFormat, TFieldId, TListFilterQuery, TEntity> repository;
        private IMapper<TEntity, BsonDocument> mapper;

        public GenericBL(IDBConnection<TDatabase> dbConnection, string databaseName, string document)
        {
            this.repository = RepositoryFactory<TListDBFormat, TFieldId, TListFilterQuery, TEntity, TDatabase>.Create(dbConnection, databaseName, document);
            this.mapper = MongoMapperFactory<TEntity>.Create();
        }

        public bool Create(TEntity entity)
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

        public TEntity GetById(TFieldId id)
        {
            IEnumerable<BsonDocument> result = (IEnumerable<BsonDocument>)this.repository.GetById(id);
            var bsonDocument = result.ToList<BsonDocument>().First();
            return this.mapper.Mapper(bsonDocument);
        }

        public IEnumerable<TEntity> GetFiltered(TListFilterQuery query)
        {
            var result = (IEnumerable<BsonDocument>)this.repository.GetFiltered(query);
            IEnumerable<BsonDocument> resultInList = result.ToList();
            IList<TEntity> entityList = new List<TEntity>();
            foreach (var item in resultInList)
            {
                entityList.Add(this.mapper.Mapper(item));
            }

            return entityList;
        }
    }
}
