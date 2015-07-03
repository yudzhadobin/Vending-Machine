using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    class ProductStorage
    {
        Dictionary<Product, int> storage = new Dictionary<Product, int>();

        public ProductStorage()
        {
            storage.Add(new Product("Кексы", 50), 4);
            storage.Add(new Product("Печенье", 10), 3);
            storage.Add(new Product("Вафли", 30), 10);
        }

        public int Give(Product product)
        {
            if(storage[product] > 0)
            {
                storage[product]--;
                return product.Price;
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
