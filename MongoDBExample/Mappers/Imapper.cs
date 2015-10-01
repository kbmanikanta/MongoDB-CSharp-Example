using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBExample.Mappers
{
    public interface IMapper<TEntity, TDBFormat>
    {
        TDBFormat Mapper(TEntity entity);
        TEntity Mapper(TDBFormat dbFormat);
    }
}
