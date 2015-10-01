using MongoDB.Bson;
using MongoDBExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBExample.Mappers
{
    public class Mapper<T>
    {
        private IConverter<T> converter;

        public Mapper(IConverter<T> converter)
        {
            this.converter = converter;
        }

        public BsonDocument ToBsonDocument(T client)
        {
            this.converter.ConvertToBsonDocument(client);
            return new BsonDocument();
        }
    }
}
