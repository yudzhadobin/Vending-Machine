using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    class User
    {
        int money;

        public int Money
        {
            get
            {
                return money;
            }
        }

        public User(int money)
        {
            this.money = money;
        }

        public void InsertMoney(Machine target, int amount)
        {
            if(this.money < amount)
            {
                throw new NotEnoughMoneyException();
            }
            target.InsertCoins(amount);
            this.money -= amount;
        }

        public void ReceiveOddMoney(Machine target)
        {
            this.money += target.ReturnOddMoney();
        }

        public void Buy(Machine target,string name)
        {
            target.Buy(name);
        }
    }
}
