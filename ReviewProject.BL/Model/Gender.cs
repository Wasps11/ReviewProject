﻿using System;

namespace ReviewProject.BL.Model
{
    /// <summary>
    /// Пол.
    /// </summary>
    public class Gender
    {
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Создать новый пол.
        /// </summary>
        /// <param name="name"> Название пола. </param>
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пола не может быть пустым", nameof(name));
            }
        }
    }
}