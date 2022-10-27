using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V7
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

            //Вводим число number1 (если указано не число, если указано не число или указано меньше 0, то ещё раз вводим)
            string line1 = "";
            int number1 = 0;
            do
            {
                Console.WriteLine("Введите первое число: ");
                line1 = Console.ReadLine();
            }
            while (!int.TryParse(line1, out number1) || number1 <= 0);

            //Вводим число number2 (если указано не число или указано меньше 0, то ещё раз вводим)
            line1 = "";
            int number2 = 0;
            do
            {
                Console.WriteLine("Введите второе число: ");
                line1 = Console.ReadLine();
            }
            while (!int.TryParse(line1, out number2) || number2 <= 0);

            Console.WriteLine(EvklidHelper.Evklid1(number1, number2));
            Console.WriteLine(EvklidHelper.Evklid2(number1, number2));

            //Console.ReadKey();

        }
    }
    
    /// <summary>
    /// Помощник по нахождению наибольшего общего делителя (НОД)
    /// </summary>
    public static class EvklidHelper
    {

        /// <summary>
        /// Алгоритм Евклида (метод вычитания)
        /// </summary>
        /// <param name="number1">Первое число</param>
        /// <param name="number2">Второе число</param>
        /// <returns>НОД</returns>
        public static int Evklid1(int number1, int number2)
        {
            while (number1 != number2)
            {
                if (number1 > number2)
                    number1 = number1 - number2;
                else
                    number2 = number2 - number1;
            }
            return number2;
        }

        /// <summary>
        /// Алгоритм Евклида (метод деления)
        /// </summary>
        /// <param name="number1">Первое число</param>
        /// <param name="number2">Второе число</param>
        /// <returns>НОД</returns>
        public static int Evklid2(int number1, int number2)
        {
            while (number1 != 0 && number2 != 0)
            {
                if (number1 > number2)
                    number1 = number1 % number2;
                else
                    number2 = number2 % number1;
            }
            return number1 + number2;
        }

    }


}
