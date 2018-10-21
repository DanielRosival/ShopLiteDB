using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopIS.ModelClasses
{
    public class Customer
    {
        [BsonId]
        public int Id { get; set; }
        public string Name { get; set; }

        public Customer()
        { }

        public Customer(int id)
        {
            var obj = new DatabaseOperations().GetCollection<Customer>("customers").FindById(id);
            Id = obj.Id;
            Name = obj.Name;
        }

        public bool CheckIfHasOrders()
        {
            return new DatabaseOperations().GetCollection<Order>("orders").Find(x => x.Customer.Id == this.Id).Any();
        }
    }
}
