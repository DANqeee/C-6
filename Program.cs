using System.Diagnostics;
using System;
using System.Threading;

namespace Program
{

    class Program
    {

        static void Main()
        {
            int balance = 20000;
            List<String> inventory = new List<String>();
            string[] stickersNames = new string[]{
                "Я слишком стар",
                "Сепаратистские пиксели",
                "Классика",
                "Пиксельный мститель",
                "Код «Дружба"
            };
            Dictionary<string, int> stickersPrice = new Dictionary<string, int>{
                {"Я слишком стар", 100},
                {"Сепаратистские пиксели", 200},
                {"Классика", 300},
                {"Пиксельный мститель",400},
                {"Код «Дружба", 500},
                {"Кроха Цербер", 100},
                {"Проклятая подпись", 200},
                {"Проблема зелёного", 300},
                {"СЅ на ходу",400},
                {"Кроха Дракон", 500}
            };
            string[] stickersNames2 = new string[]{
                "Кроха Цербер",
                "Проклятая подпись",
                "Проблема зелёного",
                "СЅ на ходу",
                "Кроха Дракон"
                        };
            bool isProgramRunning = true;
            Console.WriteLine("Добро пожаловать в игру");
            Thread.Sleep(2500);
            while (isProgramRunning)
            {
                var rnd = new Random();
                Console.Clear();
                Console.WriteLine(" 1-капсулы \n 2-инвентарь \n 3-баланс \n 4-выход");
                Int32.TryParse(Console.ReadLine(), out int choice);
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("открыть капсулу\n| 1-капсула с наклейками cs20| \n| 2-Капсула наклеек десятилетнего юбилея| ");
                        Int32.TryParse(Console.ReadLine(), out int choice_stickers);
                        switch (choice_stickers)
                        {
                            case 1:
                                if (balance >= 200 && inventory.Count < 10)
                                {
                                    var randomNumber = rnd.Next(0, 5);
                                    balance -= 200;
                                    inventory.Add(stickersNames[randomNumber]);
                                    Console.Clear();
                                    Console.WriteLine($"Вы выбили {stickersNames[randomNumber]}");
                                    Console.ReadLine();
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("у вас недостаточно средств  или инвентарь переполнен");
                                    Console.ReadLine();
                                }
                                break;
                            case 2:
                                if (balance >= 400 && inventory.Count <= 10)
                                {
                                    var randomNumber = rnd.Next(0, 5);
                                    balance -= 400;
                                    inventory.Add(stickersNames2[randomNumber]);
                                    Console.Clear();
                                    Console.WriteLine($"Вы выбили {stickersNames2[randomNumber]}");
                                    Console.ReadLine();
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("у вас недостаточно средств  или инвентарь переполнен");
                                    Console.ReadLine();
                                }
                                break;
                            default:
                                Console.Clear();
                                Console.WriteLine("вы ввели не верное значение");
                                Console.ReadLine();
                                break;
                        }
                        break;
                    case 2:
                        if (inventory.Count > 0)
                        {
                            Console.Clear();
                            Console.WriteLine(" 1-инвентарь \n 2-продать");
                            Int32.TryParse(Console.ReadLine(), out int inventory_manager);
                            switch (inventory_manager)
                            {
                                case 1:
                                    Console.Clear();
                                    foreach (string item in inventory)
                                    {
                                        Console.WriteLine(item);
                                    }
                                    Console.ReadLine();
                                    break;
                                case 2:
                                    Console.Clear();
                                    for (int i = 0; i < inventory.Count; i++)
                                    {
                                        Console.WriteLine(i + 1 + "-" + inventory[i]);
                                    }
                                    Console.WriteLine("введите наклейку которую хотите продать");
                                    Int32.TryParse(Console.ReadLine(), out int price_manager);
                                    try
                                    {
                                        string chosenSticker = inventory[price_manager - 1];
                                        Console.Clear();
                                        balance += stickersPrice[chosenSticker];
                                        Console.WriteLine($"вы продали {chosenSticker} за {stickersPrice[chosenSticker]}");
                                        inventory.RemoveAt(price_manager - 1);
                                        Console.ReadLine();
                                    }
                                    catch (IndexOutOfRangeException)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("вы ввели неверное значение");
                                        Console.ReadLine();
                                    }
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("вы ввели неверное значение");
                                    Console.ReadLine();
                                    break;
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("инвентарь пуст");
                            Console.ReadLine();
                        }
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine(balance);
                        Console.ReadLine();
                        break;
                    case 4:
                        isProgramRunning = false;
                        break;
                }
            }
        }
    }
}
