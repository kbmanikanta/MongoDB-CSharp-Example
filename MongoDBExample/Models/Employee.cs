using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBExample.Models
{
    public class Employee
    {
        public Employee()
        {
        }
        public Employee(string id, string name, string workstation)
        {
            this.Id = id;
            this.Name = name;
            this.WorkStation = workstation;
        }

        [Custom(DBColumnName = "_id")]
        public string Id { get; set; }

        [Custom(DBColumnName = "name")]
        public string Name { get; set; }

        [Custom(DBColumnName = "workstation")]
        public string WorkStation { get; set; }
    }
}
