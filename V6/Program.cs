using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V6
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
            //Вводим число (если указано не число или число меньше 0 или 0, то ещё раз спрашиваем)
            string line1;
            int index;
            do
            {
                Console.WriteLine("Введите номер числа: ");
                line1 = Console.ReadLine();
            }
            while (!int.TryParse(line1, out index) || index <= 0);

            //запуск двух видов вычисления числа
            Console.WriteLine(FibHelper.GetNumberByIter(index));
            Console.WriteLine(FibHelper.GetNumberByRecurs(index));
			
			//Console.ReadKey();
        }
    }

    /// <summary>
    /// Помощник для вычисления числа Фибонначи по номеру index
    /// </summary>
    public static class FibHelper
    {
        /// <summary>
        /// Итерационный подход к вычислению числа
        /// </summary>
        /// <param name="index">номер числа</param>
        /// <returns></returns>
        public static int GetNumberByIter(int index)
        {
            if (index == 0)
                return 0;
            int fib_n_2 = 0, fib_n_1 = 1;
            for (int i = 1; i < index; i++)
            {
                var temp = fib_n_1;
                fib_n_1 += fib_n_2;
                fib_n_2 = temp;
            }
            return fib_n_1;
        }

        /// <summary>
        /// рекурсивный подход к вычислению числа
        /// </summary>
        /// <param name="index">номер числа</param>
        /// <returns></returns>
        public static int GetNumberByRecurs(int index)
        {
            if (index == 0)
                return 0;
            else if (index == 1 || index == 2) 
                return 1;
            else 
                return GetNumberByRecurs(index - 1) + GetNumberByRecurs(index - 2);
        }
    } 

}
