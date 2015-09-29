using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBExample.Queries
{
    public interface IQuery<TOne, TTwo>
    {
        TTwo CreateFilterQuery(TOne queryInput);
    }
}
