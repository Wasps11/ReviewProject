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
        #endregion
        /// <summary>
        /// Создать нового пользователя.
        /// </summary>
        /// <param name="name"> Имя. </param>
        /// <param name="gender"> Пол. </param>
        /// <param name="birthDate"> Дата рождения. </param>
        /// <param name="reviews"> Количество отзывов. </param>
        /// <param name="buys"> Количество покупок. </param>
        public User(string name, Gender gender, DateTime birthDate, int reviews = 0, int buys = 0)
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
            if(reviews < 0)
            {
                throw new ArgumentException("Некорректное количество отзывов ", nameof(reviews));
            }
            if(buys < 0)
            {
                throw new ArgumentException("Некорректное количество покупок ", nameof(buys));
            }
            #endregion
            Name = name;
            BirthDate = birthDate;
            Reviews = reviews;
            Buys = buys;
        }
    }
}
