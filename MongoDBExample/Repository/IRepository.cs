﻿using MongoDBExample.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBExample.Repository
{
    public interface IRepository<TOne, TTwo, TThree>
    {
        TOne GetById(TTwo id);
        TOne GetFiltered(TThree query);
    }
}