using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    class Product
    {
        string name;

        int price;
        public string Name
        {
            get
            {
                return name;
            }
        }
        
        public int Price
        {
            get
            {
                return price;
            }
        }

        public Product(string name,int price)
        {
            this.name = name;
            this.price = price;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Product))
            {
                return false;
            }
            else
            {
                Product another = (Product)obj;
                return this.name.Equals(another.name);
            }
        }

        public override int GetHashCode()
        {
            return this.name.GetHashCode() ;
        }

        public override string ToString()
        {
            return name + "\t" + "цена:" + price;
        }
    }
}
