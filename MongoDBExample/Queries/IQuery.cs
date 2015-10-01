using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBExample.Queries
{
    public interface IQuery<TListFilterQuery, TDBFormat>
    {
        TDBFormat CreateFilterQuery(TListFilterQuery queryInput);
    }
}
