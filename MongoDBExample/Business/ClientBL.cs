using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBExample.Factories;
using MongoDBExample.Mappers;
using MongoDBExample.Models;
using MongoDBExample.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBExample.Business
{
    public class ClientBL : IBL<Client, string, IList<QueryInfo>, Client[]>
    {
        MongoRepository<Client> repository;
        IMapper<Client, BsonDocument> mapper;

        public ClientBL(IMongoDatabase mongoDatabase, string document)
        {
            this.repository = MongoRepositoryFactory<Client>.Create(mongoDatabase, document);
            this.mapper = new ClientMapper();
        }

        public bool Create(Client client)
        {
            try
            {
                return this.repository.Create(client);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public Client GetById(string id)
        {
            var result = this.repository.GetById(id);
            var clientBsonDocument = result.Result.ToList<BsonDocument>().First();
            return this.mapper.Mapper(clientBsonDocument);
        }

        public Client[] GetFiltered(IList<QueryInfo> query)
        {
            //var result = this.repository.GetFiltered(query);
            //result.Result.ToList<BsonDocument>().Where(x => x === x.name)
            var clients = new Client[2];

            return clients;
        }
    }
}
