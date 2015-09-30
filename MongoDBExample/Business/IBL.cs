using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBExample.Business
{
    public interface IBL<TOne, TTwo, TThree, TFour>
    {
        TOne GetById(TTwo id);
        TFour GetFiltered(TThree query);
        bool Create(TOne recurse);
    }
}
