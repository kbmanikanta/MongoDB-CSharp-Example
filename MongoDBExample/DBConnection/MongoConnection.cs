using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDBExample.DBConnection
{
    public class MongoConnection : IDBConnection<IMongoDatabase>
    {
        private IMongoClient _client;

        public bool CloseConnection()
        {
            throw new NotImplementedException();
        }

        public IMongoDatabase GetDatabase(string databaseName)
        {
            return _client.GetDatabase(databaseName); 
        }

        public bool OpenConnection()
        {
            _client = new MongoClient();
            return true;
        }
    }
}
