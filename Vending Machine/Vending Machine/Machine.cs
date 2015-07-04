using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    class Machine
    {
        MoneyStorage bank;

        int currentBalane;

        ProductStorage storage;

        public MoneyStorage Bank
        {
            get
            {
                return bank;
            }
        }

        public ProductStorage Storage
        {
            get
            {
                return storage;
            }
        }

        public Machine ()
        {
            bank = new MoneyStorage();
            currentBalane = 0;
            storage = new ProductStorage();
        }

        public int CurrentBalance
        {
            get
            {
                return currentBalane;
            }
        }
        
        public void InsertCoins(int amount)
        {
            currentBalane += amount;
            bank.InsertMoney(amount);
        }

        public void Buy(string name)
        {
            Product product = storage.FindProduct(name);
            if (product.Price <= currentBalane)
            {
                currentBalane -= product.Price;
                storage.Give(product);
            }
            else
            {
                throw new NotEnoughMoneyException();
            }
        }

        public int ReturnOddMoney()
        {
            int res = currentBalane;
            this.Bank.GiveOddMoney(this.currentBalane);
            currentBalane = 0;
            return res;
        }

        public void AddProduct(Product product,int quantity)
        {
            this.storage.AddProduct(product,quantity);
        }
    }
}
