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

            Console.WriteLine("Введите пол");
            var gender = Console.ReadLine();

            Console.WriteLine("Введите дату рождения");
            var birthDate = DateTime.Parse(Console.ReadLine()); // TODO: Сделать TryParse.

            var userController = new UserController(name, gender, birthDate);
            userController.Save();
        }
    }
}
