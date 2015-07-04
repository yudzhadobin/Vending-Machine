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
            ShowMenu(user, vendingMachine);

        }



        static void ShowMenu(User user, Machine vendingMachine)
        {
            bool flag = true;
            do
            {
                int choise;
                do
                {
                    Console.Clear();
                    Console.WriteLine("Ваш текущий баланс:" + vendingMachine.CurrentBalance);
                    Console.WriteLine("Для ввода монет, введите '1'\nДля выбора товара, введите '2'\nДля возврата сдачи, введите '3'\nДля возврата сдачи, и завершения обслуживания, введите '4'");
                    Console.WriteLine("У вас осталось наличных денег:" + user.Money);
                   
                } while (!(int.TryParse(Console.ReadLine(), out choise) && choise <= 4 && choise > 0));
                
                    switch (choise)
                    {
                        case 1:
                            ShowInsertMoneyMenu(user, vendingMachine);

                            break;
                        case 2:
                            ShowChoiseMenu(user, vendingMachine);

                            break;
                        case 3:
                            user.GetChange(vendingMachine);

                            break;
                        case 4:
                            user.GetChange(vendingMachine);
                            flag = false;
                            break;
                    }
                } while (flag);

            }
            
    

        static void ShowInsertMoneyMenu(User user, Machine vendingMachine)
        {
            Console.Clear();
            Console.WriteLine("Введите сумму, которую хотите ввести:");
            int amount;
            if ((!int.TryParse(Console.ReadLine(), out amount)))
            {
                Console.WriteLine("Введены некоректные данные.\nДля повторения ввода нажмите любую клавишу.\n");
                Console.ReadKey();
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
                Console.WriteLine("Введены некоректные данные.\nДля повторения выбора нажмите любую клавишу.\n");
                Console.ReadKey();
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
                    return;
                    
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
            
        }
    }

}
