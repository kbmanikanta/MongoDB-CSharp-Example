using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Data.SqlClient;

namespace MongoDBExample.DBConnection
{
    public class SQLServerConnection : IDBConnection<SqlConnection>
    {
        private SqlConnection conn;
        private string connectionString;

        public SQLServerConnection()
        {
            this.connectionString = "Data Source=AJULIA1\\SQL2012;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            this.conn = new SqlConnection(this.connectionString);
        }

        public bool CloseConnection()
        {
            try
            {
                conn.Close();
            }
            catch (Exception)
            {

                throw;
            }

            return true;
            
        }

        public SqlConnection GetDatabase(string databaseName)
        {
            return this.conn;
        }

        public bool OpenConnection()
        {
            try
            {
                conn.Open();
            }
            catch (Exception)
            {

                throw;
            }
            
            return true;
        }
    }
}
