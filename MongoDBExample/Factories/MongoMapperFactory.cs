using MongoDB.Bson;
using MongoDBExample.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBExample.Factories
{
    public static class MongoMapperFactory<T>
    {
        public static IMapper<T, BsonDocument> Create()
        {
            string mapperName = "MongoDBExample.Mappers." + typeof(T).Name.ToString() + "Mapper";
            Type typeOfMapper = Type.GetType(mapperName);
            IMapper<T, BsonDocument> mapper = (IMapper<T, BsonDocument>)Activator.CreateInstance(typeOfMapper); 
            return mapper;
        }
    }
}
