using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBExample.Models
{
    public class QueryInfo
    {
        public QueryInfo(string key, string value, string queryOperator)
        {
            this.Key = key;
            this.Value = value;
            this.QueryOperator = queryOperator;
        }

        public string Key;
        public string Value;
        public string QueryOperator;
    }
}
