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
            storage.Add(new Product("Кекс", 50), 4);
            storage.Add(new Product("Печенье", 10), 3);
            storage.Add(new Product("Вафли", 30), 10);
        }

        public int Give(Product product)
        {
            if(storage[product] > 0)
            {
                storage[product]--;
                return product.Price ;
            }
            else
            {
                throw new Exception();
            }
        }

        public int Give(string name)
        {
            return Give(FindProduct(name));
            
        }


        public Product FindProduct(string name)
        {
            Product[] products = storage.Keys.ToArray();
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i].Name.Equals(name))
                {
                    return products[i];
                }
            }
            throw new ArgumentException(); 
        }
        public override string ToString()
        {
            string res = "";
            foreach(KeyValuePair<Product,int> pair in storage)
            {
                res += pair.Key.ToString() + "\t" + "кол-во:" + pair.Value + "\n";
            }
            return res;
        }
    }
}
