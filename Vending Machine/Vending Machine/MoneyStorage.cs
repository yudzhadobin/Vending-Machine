using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    class MoneyStorage
    {
        Dictionary<Coin, int> storage = new Dictionary<Coin, int>();

        public MoneyStorage()
        {
            storage.Add(new Coin(1), 0);
            storage.Add(new Coin(2), 0);
            storage.Add(new Coin(5), 0);
            storage.Add(new Coin(10), 0);
        }

        public void AddCoin(Coin coin)
        {
            this.AddCoin(coin, 1);
        }

        public void AddCoin(Coin coin, int quantity)
        {
            this.storage[coin] += quantity;
        }

        public override string ToString()
        {
            string res = "";
            foreach (KeyValuePair<Coin, int> pair in storage)
            {
                res += pair.Key.ToString() + "\t" + "quantity:" + pair.Value + "\n";
            }
            return res;
        } 

        public MoneyStorage Pay(int value)
        {
            MoneyStorage result = new MoneyStorage();
            for(int i = result.storage.Count-1; i >= 0; i--)
            {
                KeyValuePair<Coin, int> pair = storage.ElementAt(i);
                int quantity = value / pair.Key.Value;
                quantity = quantity <= pair.Value ? quantity : pair.Value;
                result.AddCoin(pair.Key, quantity);
                value -= pair.Key.Value * quantity;
            }
            if( value!= 0)
            {
                throw new NotEnoughMoney();
            }
            return result;
        }

        public void SumMoneyStorages(MoneyStorage another)
        {
            foreach(KeyValuePair<Coin, int> pair in another.storage)
            {
                this.storage[pair.Key] += pair.Value;
            }
        }
    }

    class NotEnoughMoney:Exception
    {

    }
}
