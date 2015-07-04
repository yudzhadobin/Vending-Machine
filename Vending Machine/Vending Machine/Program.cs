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
            User user = new User(150);
            ShowMenu(user,vendingMachine);
                    
        }


        
        static void ShowMenu(User user, Machine vendingMachine)
        {
            Console.Clear();
            Console.WriteLine("Ваш текущий баланс:" + vendingMachine.CurrentBalance);
            Console.WriteLine("Для ввода монет, введите '1'\nДля выбора товара, введите '2'\nДля возврата сдачи, введите '3'\nДля возврата сдачи, и завершения обслуживания, введите '4'");
            int choise;
            if ((!int.TryParse(Console.ReadLine(), out choise)) || choise > 4)
            {
                ShowMenu(user,vendingMachine);
            }
            switch (choise)
            {
                case 1:
                    ShowInsertMoneyMenu(user, vendingMachine);
                    ShowMenu(user, vendingMachine);
                    break;
                case 2:
                    ShowChoiseMenu(user, vendingMachine);
                    ShowMenu(user, vendingMachine);
                    break;
                case 3:
                    user.GetChange(vendingMachine);
                    ShowMenu(user, vendingMachine);
                    break;
                case 4:
                    user.GetChange(vendingMachine);
                    break;
            }
        }

        static void ShowInsertMoneyMenu(User user, Machine vendingMachine)
        {
            Console.Clear();
            Console.WriteLine("Введите сумму, которую хотите ввести:");
            int amount;
            if ((!int.TryParse(Console.ReadLine(), out amount)))
            {
                ShowInsertMoneyMenu(user, vendingMachine);
            }
            try {
                user.InsertMoney(vendingMachine, amount);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Для перехода в главное меню, нажмите любую клавишу");
                Console.ReadKey();
            }
        }

        static void ShowChoiseMenu(User user, Machine vendingMachine)
        {
            Console.Clear();
            Console.WriteLine("Меню:");
            Console.WriteLine(vendingMachine.Storage.ToString());
            Console.WriteLine("Введите номер товара для его покупки, для перехода в предыдущее меню введите '4':");
            int choise;
            if ((!int.TryParse(Console.ReadLine(), out choise)) || choise > 4)
            {
                ShowChoiseMenu(user,vendingMachine);
            }
            string res= null;
            switch (choise)
            {
                case 1:
                    res = "Кекс";
                    break;
                case 2:
                    res = "Печенье";
                    break;
                case 3:
                    res = "Вафли";
                    break;
                case 4:
                    ShowMenu(user,vendingMachine);
                    break;
            }
            try
            {
                user.Buy(vendingMachine, res);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.WriteLine("Для перехода в главное меню, нажмите любую клавишу");
                Console.ReadKey();
            }
            ShowMenu(user, vendingMachine);
        }
    }

}
