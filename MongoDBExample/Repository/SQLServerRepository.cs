using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDBExample.Queries;
using MongoDB.Driver;
using MongoDBExample.Models;
using MongoDBExample.Mappers;
using System.Data.SqlClient;
using System.Data;
using MongoDBExample.DBConnection;

namespace MongoDBExample.Repository
{
    public class SQLServerRepository : IRepository<IEnumerable<DataSet>, Guid, IList<FilterQuery>, DataSet>
    {
        private string document;

        public SQLServerRepository(string document)
        {
            this.document = document;
        }

        public IEnumerable<DataSet> GetById(Guid id)
        {
            var ds = new DataSet();
            var sqlServerConnection = new SQLServerConnection();
            using (SqlConnection con = sqlServerConnection.GetDatabase(null))
            {
                //
                // Open the SqlConnection.
                //
                sqlServerConnection.OpenConnection();
                //
                // The following code uses an SqlCommand based on the SqlConnection.
                //
                using (SqlCommand command = new SqlCommand("SELECT TOP 1000 [Id],[Value] FROM[ORMTest].[dbo].[ParameterValues]", con))
                {
                    var adapter = new SqlDataAdapter(command);
                    adapter.Fill(ds);
                }
                sqlServerConnection.CloseConnection();
            }
            IEnumerable<DataSet> enumerableDataSet = new List<DataSet>() { ds };
            return enumerableDataSet;
        }

        public IEnumerable<DataSet> GetFiltered(IList<FilterQuery> query)
        {
            throw new NotImplementedException();
        }

        public bool Create(DataSet recurse)
        {
            throw new NotImplementedException();
        }
    }
}
