using MongoDB.Bson;
using MongoDBExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBExample.Mappers
{
    public class MongoMapper<TEntity> : IMapper<TEntity, BsonDocument>
    {
        public TEntity Mapper(BsonDocument bsonDoc)
        {
            {
                var entity = Activator.CreateInstance(typeof(TEntity));

                var piArr = typeof(TEntity).GetProperties();
                foreach (var prop in piArr)
                {
                    var customatt = prop.GetCustomAttributes(false);
                    var attValue = ((CustomAttribute)customatt[0]).DBColumnName;
                    prop.SetValue(entity, bsonDoc[attValue].AsString);
                }
                return (TEntity)entity;
            }
        }

        public BsonDocument Mapper(TEntity entity)
            {
                var bsonDoc = new BsonDocument();
                var piArr = entity.GetType().GetProperties();
                foreach (var prop in piArr)
                {
                    var value = prop.GetValue(entity);
                    var customatt = prop.GetCustomAttributes(false);
                    bsonDoc.Add(((CustomAttribute)customatt[0]).DBColumnName, value.ToString());
                }
                return bsonDoc;
            }
    }
}
