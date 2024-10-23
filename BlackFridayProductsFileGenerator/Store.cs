using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFridayProductsFileGenerator
{
    public class Store
    {
        public Store(string name, List<Product> products)
        {
            Name = name;
            Products = products;
        }

        public string Name { get; set; }

        public List<Product> Products { get; set; }
        
    }
}
