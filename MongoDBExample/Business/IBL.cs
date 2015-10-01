using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBExample.Business
{
    public interface IBL<TEntity, TFieldId, TListFilterQuery>
    {
        TEntity GetById(TFieldId id);
        IEnumerable<TEntity> GetFiltered(TListFilterQuery query); 
        bool Create(TEntity recurse);
    }
}
