using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;

namespace ReviewProject.BL.Model
{
    /// <summary>
    /// Приём пищи.
    /// </summary>
    public class Eating
    {
        /// <summary>
        /// Время приёма пищи.
        /// </summary>
        public DateTime TimeOfEat { get; }
        /// <summary>
        /// Список еды.
        /// </summary>
        public Dictionary<Food, double> Foods { get; }
        /// <summary>
        /// Пользователь.
        /// </summary>
        public User User { get; }
        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException("Пользователь не может быть пустым", nameof(user));
            TimeOfEat = DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();
        }
        public void Add(Food food, double weight)
        {
            var product = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));

            if(product == null)
            {
                Foods.Add(food, weight);
            }
            else
            {
                Foods[product] += weight;
            }

        }

    }
}
