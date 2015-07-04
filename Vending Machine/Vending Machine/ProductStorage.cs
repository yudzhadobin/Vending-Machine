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
                throw new NotEnoughProductException();
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
            int index = 1;
            foreach(KeyValuePair<Product,int> pair in storage)
            {
                res += index+":\t"+ pair.Key.ToString() + "\t" + "кол-во:" + pair.Value + "\n";
                index++;
            }
            return res;
        }

        public void AddProduct(Product product, int quantity)
        {
            if(this.storage.ContainsKey(product)) {
                this.storage[product] += quantity;
            }
            else
            {
                this.storage.Add(product, quantity);
            }
        }
    }


}

class NotEnoughProductException: Exception
{
    public override string ToString()
    {
        return "Данного товара нет в наличии. \n";
    }
}
