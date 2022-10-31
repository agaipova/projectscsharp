using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V14
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
            //Вводим количество (если указано не число или число меньше 0 или 0, то ещё раз спрашиваем)
            string line1;
            int n;
            do
            {
                Console.WriteLine("Введите количество: ");
                line1 = Console.ReadLine();
            }
            while (!int.TryParse(line1, out n) || n <= 0);

            //Генерируем массив, выводим, сортируем и опять выводим
            NumberAdapter adapter = new NumberAdapter(n);
            Console.WriteLine(adapter);
            adapter.BubbleSort();
            Console.WriteLine(adapter);

          //  Console.ReadKey();
        }

    }

    /// <summary>
    /// Класс для работы с массивом чисел
    /// </summary>
    public class NumberAdapter
    {
        //числа
        private decimal [] numbers;

        /// <summary>
        /// Консруктор для генерации чисел по количеству
        /// </summary>
        /// <param name="count"></param>
        public NumberAdapter(int count)
        {
            Random rand = new Random();
            numbers = new decimal[count];
            for (int i = 0; i < numbers.Length; i++)
                numbers[i] = rand.Next(1, 20);
        }

        /// <summary>
        /// Переопределённый вывод массива чисел
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Join(", ", numbers);
        }

        /// <summary>
        /// Сортировка текущего массива методом Пузырька
        /// </summary>
        public void BubbleSort()
        {
            decimal temp;
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[i] > numbers[j])
                    {
                        temp = numbers[i];
                        numbers[i] = numbers[j];
                        numbers[j] = temp;
                    }
                }
            }
        }
    }

}
