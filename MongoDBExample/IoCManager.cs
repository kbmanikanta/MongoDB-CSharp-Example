using Autofac;
using MongoDB.Driver;
using MongoDBExample.DBConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBExample
{
    public class IoCManager : IConfigIoC
    {
        private readonly ContainerBuilder container;

        public IoCManager(ContainerBuilder container)
        {
            this.container = container;
        }

        public void Configure()
        {
            this.container.RegisterType(typeof(MongoConnection))
                .As(typeof(IDBConnection<IMongoDatabase>));
        }
    }
}
