using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using MongoRepository;
using MongoDB.Bson.Serialization.Attributes;

namespace ngEdu.Data.Mongo
{
    class Products:Entity
    {
        public string ProductName { get; set; }

        public string ProductCode { get; set; }
        public string Units { get; set; }
        public string Price { get; set; }

        public int MyProperty { get; set; }
    }
}
