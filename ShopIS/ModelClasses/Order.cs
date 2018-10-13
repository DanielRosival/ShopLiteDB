using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopIS.ModelClasses
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        [BsonRef("customers")]
        public Customer Customer { get; set; }
        [BsonRef("products")]
        public List<Product> Products { get; set; }                
    }
}
