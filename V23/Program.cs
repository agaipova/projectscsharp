using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V23
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
            //создание объекта для массива
            MassHelper helper = new MassHelper();
            //вывод элементов массива
            Console.WriteLine(helper);
            //перемешивание элементов массива
            helper.Mix();
            //вывод элементов массива
            Console.WriteLine(helper);

            Console.ReadKey();
        }
    }

    /// <summary>
    /// Помощник по работе с массивами
    /// </summary>
    public class MassHelper
    {
        /// <summary>
        /// Числа
        /// </summary>
        private decimal[] numbers;

        /// <summary>
        /// Конструктор объекта (чтение объекта)
        /// </summary>
        public MassHelper()
        {
            //Вводим количество (если указано не число или число меньше 0 или 0, то ещё раз спрашиваем)
            string line1;
            int n;
            do
            {
                Console.WriteLine("Введите количество: ");
                line1 = Console.ReadLine();
            }
            while (!int.TryParse(line1, out n) || n <= 0);


            //Вводим элементы массива (если элемент не число, то ещё раз спрашиваем)
            numbers = new decimal[n];
            for (int i = 0; i < n; i++)
            {
                decimal elem = 0;
                do
                {
                    Console.WriteLine("Введите элемент numbers[" + i + "]: ");
                    line1 = Console.ReadLine();
                }
                while (!decimal.TryParse(line1, NumberStyles.Any, CultureInfo.InvariantCulture, out elem));
                numbers[i] = elem;
            }
        }

        /// <summary>
        /// Переопределние строкового представления объекта
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Join(", ", numbers);
        }

        /// <summary>
        /// Перемешивание массива случайным образом (перемешивание индексов)
        /// </summary>
        public void Mix()
        {
            Random rand = new Random();
            int index1;
            int index2;
            decimal temp;

            //проход ровно 2 * количество элементо в массиве
            for (int i = 0; i < numbers.Length * 2; ++i)
            {
                //вычисляем первый номер для замены
                index1 = rand.Next(0, numbers.Length - 1);
                //вычисляем второй номер для замены
                index2 = rand.Next(0, numbers.Length - 1);
                //выполняем обмен местами элементов
                temp = numbers[index1];
                numbers[index1] = numbers[index2];
                numbers[index2] = temp;
            }
        }


    }
}
