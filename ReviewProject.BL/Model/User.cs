using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewProject.BL.Model
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    [Serializable]
    public class User
    {
        #region Свойства
        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Пол.
        /// </summary>
        public Gender Gender { get; }
        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime BirthDate { get; }
        /// <summary>
        /// Количество отзывов.
        /// </summary>
        public int Reviews { get; set; }
        /// <summary>
        /// Количество покупок.
        /// </summary>
        public int Buys { get; set; }
        /// <summary>
        /// Сумма всех покупок.
        /// </summary>
        public double SumOfBuys { get; set; }
        #endregion
        /// <summary>
        /// Создать нового пользователя.
        /// </summary>
        /// <param name="name"> Имя. </param>
        /// <param name="gender"> Пол. </param>
        /// <param name="birthDate"> Дата рождения. </param>
        /// <param name="reviews"> Количество отзывов. </param>
        /// <param name="buys"> Количество покупок. </param>
        public User(string name, Gender gender, DateTime birthDate)
        {
            #region Проверка данных
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Имя пользователя не может быть пустым ", nameof(name));
            }

            if (gender == null)
            {
                throw new ArgumentNullException("Пол не может быть null ", nameof(gender));
            }
            if(birthDate < DateTime.Parse("01.01.1910") || birthDate >= DateTime.Now)
            {
                throw new ArgumentException("Некорректная дата рождения ", nameof(birthDate));
            }
            #endregion
            Name = name;
            BirthDate = birthDate;
            Reviews = 0;
            Buys = 0;
            SumOfBuys = 0.00;
        }
    }
}
