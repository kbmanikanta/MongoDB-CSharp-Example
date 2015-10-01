using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBExample.Models
{
    public class CustomAttribute: Attribute
    {
        public string DBColumnName { get; set; }
    }
}
