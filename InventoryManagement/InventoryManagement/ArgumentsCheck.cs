using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement
{
    internal static class ArgumentsCheck  // static - для использования методов класса, без создания его экземпляра
    {
        public static void GreaterThanZeroCheck(int value, string field) 
        {
            if (value <= 0)
                throw new ArgumentException($"Поле {field} должно быть больше нуля!"); 
        }

        public static void StringIsNotEmptyCheck(string value, string field)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException($"Поле {field} не должно быть пустым!");
        }
    }
}
