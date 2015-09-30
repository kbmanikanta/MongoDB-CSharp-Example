using MongoDB.Bson;
using MongoDBExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBExample.Mappers
{
    public class ClientMapper : IMapper<Client, BsonDocument>
    {
        public BsonDocument Mapper(Client origen)
        {
            return new BsonDocument {
                { "_id" , origen.Id },
                { "name" , origen.Name }
            };
        }

        public Client Mapper(BsonDocument origen)
        {
            return new Client(origen["_id"].AsString, origen["name"].AsString);
        }


    }
}
