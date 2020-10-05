﻿using System;
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
        public Gender Gender { get; set; }
        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// Рост.
        /// </summary>
        public double Height { get; set; }
        /// <summary>
        /// Вес.
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Возраст пользователя.
        /// </summary>
        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }    

        #endregion
        /// <summary>
        /// Создать нового пользователя.
        /// </summary>
        /// <param name="name"> Имя. </param>
        /// <param name="gender"> Пол. </param>
        /// <param name="birthDate"> Дата рождения. </param>
        /// <param name="reviews"> Количество отзывов. </param>
        /// <param name="buys"> Количество покупок. </param>
        public User(string name, Gender gender, DateTime birthDate, double height, double weight)
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
            if(height <= 0)
            {
                throw new ArgumentNullException("Рост не может быть меньше или равным 0", nameof(height));
            }
            if(weight <= 0)
            {
                throw new ArgumentNullException("Вес не может быть меньше или равным 0", nameof(weight));
            }
            #endregion
            Name = name;
            BirthDate = birthDate;
            Height = height;
            Weight = weight;
        }

        public User (string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Имя пользователя не может быть пустым ", nameof(name));
            }
            Name = name;
        }

        public override string ToString()
        {
            return Name + " Возраст: " + Age + " лет.";
        }
    }
}
