using MongoDBExample.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBExample.Repository
{
    public interface IRepository<TListDBFormat, TFieldId, TListTFilterQuery, TEntity>
    {
        TListDBFormat GetById(TFieldId id);
        TListDBFormat GetFiltered(TListTFilterQuery query);
        bool Create(TEntity recurse);
    }
}
