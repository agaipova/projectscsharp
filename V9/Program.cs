using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V9
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

            //Вводим размер массивов (если указано не число, то ещё раз спрашиваем)
            string line1 = "";
            int number = 0;
            do
            {
                Console.WriteLine("Введите число: ");
                line1 = Console.ReadLine();
            }
            while (!int.TryParse(line1, out number));

            //Считаем и выводим сумму цифр в числе number
            Console.WriteLine(NumbersHelper.GetSummDigitsInNumber(number));

            //Console.ReadKey();

        }



    }

    /// <summary>
    /// Помощник по работе с числами
    /// </summary>
    public static class NumbersHelper
    {
        /// <summary>
        /// Вычисление суммы чисел числа number
        /// </summary>
        /// <param name="number">Число</param>
        /// <returns>Сумма цифр в числе</returns>
        public static int GetSummDigitsInNumber(int number)
        {
            int summ = 0;
            //пока число не равно 0
            while (number != 0)
            {
                //добавляем последнюю цифру в сумму
                summ += (number % 10);
                //уменьшаем число на одну цифру с конца
                number /= 10;
            }
            //врзвращаем сумму
            return Math.Abs(summ);
        }
    }

}
