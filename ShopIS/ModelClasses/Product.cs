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

        public override string ToString()
        {            
            return string.Join(" ", new string[] { "Id produktu: ", Id.ToString(), " Cena produktu: ", Price.ToString() });
        }
    }
}
