using MongoDB.Bson;
using MongoDBExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBExample.Mappers
{
    public class EmployeeMapper : IMapper<Employee, BsonDocument>
    {
        public BsonDocument Mapper(Employee origen)
        {
            return new BsonDocument {
                { "_id" , origen.Id },
                { "name" , origen.Name },
                { "workstation" , origen.WorkStation }
            };
        }

        public Employee Mapper(BsonDocument origen)
        {
            return new Employee(origen["_id"].AsString, origen["name"].AsString, origen["workstation"].AsString);
        }


    }
}
