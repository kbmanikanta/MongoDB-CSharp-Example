using MongoDBExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBExample.Mappers
{
    public class ClientMapper : IMapper<string, Client>
    {
        public Client Mapper(string origen)
        {
            return new Client(88, origen);
        }
    }
}
