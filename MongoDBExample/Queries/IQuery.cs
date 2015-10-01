using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBExample.Queries
{
    public interface IQuery<TListTFilterQuery, TDBFormat>
    {
        TDBFormat CreateFilterQuery(TListTFilterQuery queryInput);
    }
}
