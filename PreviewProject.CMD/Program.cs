using ReviewProject.BL.Controller;
using ReviewProject.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreviewProject.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует приложение ReviewProject");

            Console.WriteLine("Введите имя пользователя.");
            var name = Console.ReadLine();

            var userController = new UserController(name);
            userController.Save();

            if (userController.IsNewUser)
            {
                Console.WriteLine("Введите пол: ");
                var gender = Console.ReadLine();

                DateTime birthDate = ParseDateTime();
                int buys = ParseInt("Количество покупок: ");
                double sumOfBuys = ParseDouble("Сумму покупок: ");

                userController.SetNewUserData(name, birthDate, buys, sumOfBuys);
            }
            Console.WriteLine(userController.CurrentUser);
            Console.ReadLine(); 

        }

        private static DateTime ParseDateTime()
        {
            DateTime birthDate;
            while (true)
            {
                Console.WriteLine("Введите дату рождения:");
                if (DateTime.TryParse(Console.ReadLine(), out var bDate))
                {
                    birthDate = bDate;
                    break;
                }
                else
                {
                    Console.WriteLine("Введён некорректный формат данных.");
                }
            }

            return birthDate;
        }
        private static int ParseInt(string name)
        {
            while (true)
            {
                Console.WriteLine("Введите: " + name);
                if (int.TryParse(Console.ReadLine(), out int value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("Введён некорректный формат данных.");
                }
            }
        }
        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.WriteLine("Введите " + name);
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("Введён некорректный формат данных.");
                }
            }
        }
    }
}
