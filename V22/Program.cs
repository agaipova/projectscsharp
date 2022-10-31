using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V22
{
    /// <summary>
    /// Главный класс
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Точка входа
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            //Чтение строки
            string line = Console.ReadLine();
            //Вывод true или false (палиндром или нет)
            Console.WriteLine("Палиндром: " + StringHelper.IsPalindrome(line));
          //  Console.ReadKey();
        }
    }

    /// <summary>
    /// Помощник по работе со строками
    /// </summary>
    public static class StringHelper
    {
        /// <summary>
        /// Проверка на палиндром
        /// </summary>
        /// <param name="text">Строка</param>
        /// <returns>Результат</returns>
        public static bool IsPalindrome(string text)
        {
            //получение первой части строки - до середины
            string first = text.Substring(0, text.Length / 2);

            //преобразование в массив символов весь текст
            char[] arr = text.ToCharArray();
            //разворачиваем массив символов
            Array.Reverse(arr);
            //записываем в новую переменную-стркоу массив перевёрнутый
            string temp = new string(arr);
            //получение второй части строки - до середины перевёрнутого массива
            string second = temp.Substring(0, temp.Length / 2);

            //сравниваем две части строки
            return first.Equals(second);
        }
    }
}
