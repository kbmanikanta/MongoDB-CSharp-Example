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
    public class GenericBL<TEntity, TDatabase, TListDBFormat, TFieldId, TListFilterQuery, TDBFormat> : IBL<TEntity, TFieldId, TListFilterQuery>
    {
        private IRepository<TListDBFormat, TFieldId, TListFilterQuery, TDBFormat> repository;
        private IMapper<TEntity, TDBFormat> mapper;

        public GenericBL(IDBConnection<TDatabase> dbConnection, string databaseName, string document)
        {
            this.repository = RepositoryFactory<TListDBFormat, TFieldId, TListFilterQuery, TEntity, TDatabase, TDBFormat>.Create(dbConnection, databaseName, document);
            this.mapper = MongoMapperFactory<TEntity, TDBFormat>.Create();
        }

        public bool Create(TEntity entity)
        {
            try
            {
                TDBFormat tDbFormat = this.mapper.MapToDbFormat(entity);
                return this.repository.Create(tDbFormat);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception Message: " + ex.Message);
                return false;
            }
        }

        public TEntity GetById(TFieldId id)
        {
            IEnumerable<TDBFormat> result = (IEnumerable<TDBFormat>)this.repository.GetById(id);
            var bsonDocument = result.ToList<TDBFormat>().First();
            return this.mapper.MapToEntity(bsonDocument);
        }

        public IEnumerable<TEntity> GetFiltered(TListFilterQuery query)
        {
            var result = (IEnumerable<TDBFormat>)this.repository.GetFiltered(query);
            IEnumerable<TDBFormat> resultInList = result.ToList();
            IList<TEntity> entityList = new List<TEntity>();
            foreach (var item in resultInList)
            {
                var tdbFormatItem = item;
                entityList.Add(this.mapper.MapToEntity(item));
            }

            return entityList;
        }
    }
}
