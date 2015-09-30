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
        public BsonDocument Mapper(Client destino)
        {
            return new BsonDocument {
                { "address" , "prueba" }
            };
        }

        public Client Mapper(BsonDocument origen)
        {
            return new Client(88, "Jose");
        }


    }
}
