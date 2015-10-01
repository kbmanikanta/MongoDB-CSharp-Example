using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBExample.DBConnection
{
    public interface IDBConnection<TDatabase> 
    {
        bool OpenConnection();
        bool CloseConnection();
        TDatabase GetDatabase(string databaseName);
    }
}
