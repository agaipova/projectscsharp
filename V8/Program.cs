using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V8
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
            //Вводим максимальное число (если указано не число или число меньше 0 или 0, то ещё раз спрашиваем)
            string line1 = "";
            int number = 0;
            do
            {
                Console.WriteLine("Введите максимальное число: ");
                line1 = Console.ReadLine();
            }
            while (!int.TryParse(line1, out number) || number <= 0);

            //определение и вывод всех простых чисел до number
            Console.WriteLine(SimpleNumberHelper.GetSimpleNumbers(number));
			
			//Console.ReadKey();
        }
    }

    /// <summary>
    /// Помощник по определению простых чисел
    /// </summary>
    public static class SimpleNumberHelper
    {
        /// <summary>
        /// Закрытый метод для определения простое число или нет
        /// </summary>
        /// <param name="number">Число</param>
        /// <returns>Простое или нет</returns>
        private static bool isSimple(int number)
        {
            bool isSimple = true;
            //чтоб убедится простое число или нет достаточно проверить не делиться ли число на числа до его половины
            for (int i = 2; i < (int)(number / 2); i++)
            {
                if (number % i == 0)
                {
                    isSimple = false;
                    break;
                }
                else
                    isSimple = true;
            }

            return isSimple;
        }

        /// <summary>
        /// Получение всех простых чисел в строковом виде до числа latNumber
        /// </summary>
        /// <param name="lastNumber">Число, до которого будет работать алгоритм</param>
        /// <returns>Строка из чисел</returns>
        public static string GetSimpleNumbers(int lastNumber)
        {
            string ret = "";
            for (int i = 2; i <= lastNumber; i++)
            {
                if (isSimple(i))
                    ret += i.ToString() + ", ";
            }
            return ret.Substring(0, ret.Length-2);
        }

    }
}
