using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBExample.DBConnection
{
    public interface IDBConnection<T>
    {
        bool OpenConnection();
        bool CloseConnection();
        T GetDatabase(string databaseName);
    }
}
