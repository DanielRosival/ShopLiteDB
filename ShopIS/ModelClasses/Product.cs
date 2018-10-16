using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopIS.ModelClasses
{
    public class Product
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }

        public Product()
        { }

        public Product(int id)
        {
            var obj = new DatabaseOperations().GetCollection<Product>("products").FindById(id);
            Id = obj.Id;
            Price = obj.Price;
            Description = obj.Description;
        }

        public override string ToString()
        {            
            return string.Join(" ", new string[] { "Id produktu: ", Id.ToString(), " Cena produktu: ", Price.ToString() });
        }

        public bool CheckIfHasOrders()
        {
            return new DatabaseOperations().GetCollection<Order>("orders").FindAll().Where(x => x.Products.Select(y => y.Id).Contains(Id)).Any();            
        }
    }
}
