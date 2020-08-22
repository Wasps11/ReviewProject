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
        /// Пользователь.
        /// </summary>
        public User User { get; }
        /// <summary>
        /// Создать контроллер пользователя.
        /// </summary>
        /// <param name="user"> Пользователь. </param>
        public UserController(string userName, string genderName, DateTime birthDate)
        {
            #region Проверка данных
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentException("Имя пользователя не может быть пустым ", nameof(userName));
            }

            if (string.IsNullOrWhiteSpace(genderName))
            {
                throw new ArgumentException("Имя пола не может быть пустым ", nameof(genderName));
            }
            if(birthDate < DateTime.Parse("01.01.1910") || birthDate >= DateTime.Now)
            {
                throw new ArgumentException("Дата рождения некорректна", nameof(birthDate));
            }
            #endregion
            var gender = new Gender(genderName);
            User = new User(userName, gender, birthDate);
        }
        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        public void Save()
        {   
            var binFormatter = new BinaryFormatter();
            using(var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                binFormatter.Serialize(fs, User);
            }
        }
        /// <summary>
        /// Получить данные пользователя.
        /// </summary>
        /// <returns></returns>
        public UserController()
        {
            var binFormatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if(binFormatter.Deserialize(fs) is User user)
                {
                    User = user;
                }
                // TODO: Если пользователя не удалось прочитать.
            }
        }
    }
}
