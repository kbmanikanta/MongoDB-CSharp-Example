using MongoDB.Bson;
using MongoDBExample.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBExample.Factories
{
    public static class MongoMapperFactory<TEntity, TDBFormat>
    {
        public static IMapper<TEntity, TDBFormat> Create()
        {
            IMapper<TEntity, TDBFormat> mapper = new MongoMapper<TEntity, TDBFormat>();
            
            //string mapperName = "MongoDBExample.Mappers." + typeof(T).Name.ToString() + "Mapper";
            //Type typeOfMapper = Type.GetType(mapperName);
            //IMapper<T, BsonDocument> mapper = (IMapper<T, BsonDocument>)Activator.CreateInstance(typeOfMapper); 
            return mapper;
        }
    }
}
