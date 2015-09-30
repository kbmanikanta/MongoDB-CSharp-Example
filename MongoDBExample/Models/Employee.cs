using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBExample.Models
{
    public class Employee
    {
        public Employee(string id, string name, string workstation)
        {
            this.Id = id;
            this.Name = name;
            this.WorkStation = workstation;
        }

        public string Id;
        public string Name;
        public string WorkStation;
    }
}
