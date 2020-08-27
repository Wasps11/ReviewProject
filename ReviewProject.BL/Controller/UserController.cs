using ReviewProject.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ReviewProject.BL.Controller
{
    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Пользователи.
        /// </summary>
        public List<User> Users { get;  }
        /// <summary>
        /// Создать контроллер пользователя.
        /// </summary>
        /// <param name="user"> Пользователь. </param>
        public User CurrentUser { get; }

        public bool IsNewUser { get; } = false;
        public UserController(string userName)
        {
            #region Проверка данных
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentException("Имя пользователя не может быть пустым ", nameof(userName));
            }
            #endregion

            Users = GetUsersData();
            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if(CurrentUser == null)
            {
                CurrentUser = new User(userName);
                IsNewUser = true;
                Users.Add(CurrentUser);
                Save();
            }
        }
        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        public void Save()
        {   
            var binFormatter = new BinaryFormatter();
            using(var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                binFormatter.Serialize(fs, Users);
            }
        }
        /// <summary>
        /// Установить значения свойств для нового пользователя.
        /// </summary>
        /// <param name="genderName"> Пол. </param>
        /// <param name="birthDate"> Дата рождения. </param>
        /// <param name="buys"> Количество покупок. </param>
        /// <param name="sumOfBuys"> Сумма всех покупок. </param>
        public void SetNewUserData(string genderName, DateTime birthDate, int buys = 0, double sumOfBuys = 0.00)
        {
            // Проверка.
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Buys = buys;
            CurrentUser.SumOfBuys = sumOfBuys;
            Save();
        }
        /// <summary>
        /// Получить сохранённый список пользователей.
        /// </summary>
        /// <returns></returns>
        private List<User> GetUsersData()
        {
            var binFormatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if(binFormatter.Deserialize(fs) is List<User> users)
                {
                    return users;
                }
                else
                {
                    return new List<User>();
                }
            }
        }

    }
}
