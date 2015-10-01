using MongoDBExample.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBExample.Repository
{
    public interface IRepository<TListDBFormat, TFieldId, TListFilterQuery, TEntity>
    {
        TListDBFormat GetById(TFieldId id);
        TListDBFormat GetFiltered(TListFilterQuery query);
        bool Create(TEntity recurse);
    }
}
