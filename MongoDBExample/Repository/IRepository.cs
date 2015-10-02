using MongoDBExample.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBExample.Repository
{
    public interface IRepository<TListDBFormat, TFieldId, TListFilterQuery, TDBFormat>
    {
        TListDBFormat GetById(TFieldId id);
        TListDBFormat GetFiltered(TListFilterQuery query);
        bool Create(TDBFormat recurse);
    }
}
