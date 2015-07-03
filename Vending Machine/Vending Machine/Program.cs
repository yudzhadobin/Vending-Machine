using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            Machine vendingMachine = new Machine();
            vendingMachine.InsertCoins(128);
            Console.WriteLine(vendingMachine.Bank);
            Console.WriteLine(vendingMachine.CurrentBalance);
            Console.WriteLine(vendingMachine.Storage);

            vendingMachine.Buy("Кекс");

            Console.WriteLine(vendingMachine.Bank);
            Console.WriteLine(vendingMachine.CurrentBalance);
            Console.WriteLine(vendingMachine.Storage);

            vendingMachine.ReturnChange();
            Console.WriteLine(vendingMachine.Bank);
            Console.WriteLine(vendingMachine.CurrentBalance);
            Console.WriteLine(vendingMachine.Storage);

        }
    }
}
