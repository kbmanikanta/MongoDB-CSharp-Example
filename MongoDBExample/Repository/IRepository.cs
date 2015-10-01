using MongoDBExample.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBExample.Repository
{
    public interface IRepository<TListBdd, TFieldId, TFilterQuery, TEntity>
    {
        TListBdd GetById(TFieldId id);
        TListBdd GetFiltered(TFilterQuery query);
        bool Create(TEntity recurse);
    }
}
