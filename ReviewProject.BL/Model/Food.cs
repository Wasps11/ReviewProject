using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ReviewProject.BL.Model
{
    public class Food
    {
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Белки.
        /// </summary>
        public double Proteins { get; set; }
        /// <summary>
        /// Жиры.
        /// </summary>
        public double Fats { get;  }
        /// <summary>
        /// Углеводы.
        /// </summary>
        public double Carbohydrates { get; }
        /// <summary>
        /// Калории (на 100 грамм продукта).
        /// </summary>
        public double Calories { get;  }

        public Food(string name) : this (name, 0 , 0, 0, 0)
        {
            Name = name;
        }
        public Food(string name, double proteins, double fats, double carbohydrates, double calories)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Название продукта не может быть null", nameof(name));
            }
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
            Calories = calories / 100.0;        
        }
        public override string ToString()
        {
            return Name + "Белки: " + Proteins * 100.0 + ", жиры: " + Fats * 100.0 + ", углеводы: "+ Carbohydrates * 100.0 + ", калории: "+ Calories * 100.0;
        }
    }
}
