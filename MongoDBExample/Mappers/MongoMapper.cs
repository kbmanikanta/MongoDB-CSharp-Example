using MongoDB.Bson;
using MongoDBExample.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBExample.Mappers
{

    public class MongoMapper<TEntity, TDBFormat> : IMapper<TEntity, TDBFormat>
    {
        public TEntity MapToEntity(TDBFormat TDBFormatbsonDoc)
        {
            var ObjbsonDoc = (object)TDBFormatbsonDoc;
            var bsonDoc = (BsonDocument)ObjbsonDoc;

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

        public TDBFormat MapToDbFormat(TEntity entity)
        {
            var bsonDoc = new BsonDocument();
            var piArr = entity.GetType().GetProperties();
            foreach (var prop in piArr)
            {
                var value = prop.GetValue(entity);
                var customatt = prop.GetCustomAttributes(false);
                bsonDoc.Add(((CustomAttribute)customatt[0]).DBColumnName, value.ToString());
            }
            object bsonDocObj = bsonDoc;
            return (TDBFormat)bsonDocObj;
        }
    }
}
