using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBExample.Models
{
    public class Client
    {
        public Client(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public int Id;
        public string Name;
    }
}
