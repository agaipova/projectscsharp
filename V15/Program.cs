using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V15
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
            adapter.QuickSort();
            Console.WriteLine(adapter);

         //   Console.ReadKey();
        }

    }

    /// <summary>
    /// Класс для работы с массивом чисел
    /// </summary>
    public class NumberAdapter
    {
        //числа
        private decimal[] numbers;

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
        /// БЫстрая сортирвока методом Хоара
        /// </summary>
        public void QuickSort()
        {
            QuickSortMain(0, numbers.Length - 1);
        }

        /// <summary>
        /// Дополнительный метод для работы сортировки Хоара (обмен)
        /// </summary>
        /// <param name="start">С какого элемента</param>
        /// <param name="end">До какого элемента</param>
        /// <returns>Индекс</returns>
        private int QuickSortPart(int start, int end)
        {
            int index = start;
            for (int i = start; i <= end; i++)
            {
                if (numbers[i] <= numbers[end])
                {
                    //обмен
                    decimal temp = numbers[index]; 
                    numbers[index] = numbers[i];
                    numbers[i] = temp;
                    index += 1;
                }
            }
            return index - 1;
        }


        /// <summary>
        /// Дополнительный метод для работы сортировки Хоара (деление сортировки)
        /// </summary>
        /// <param name="start">С какого элемента</param>
        /// <param name="end">До какого элемента</param>
        private void QuickSortMain(int start, int end)
        {
            //прерывание
            if (start >= end)
                return;

            int pivot = QuickSortPart(start, end);
            QuickSortMain(start, pivot - 1);
            QuickSortMain(pivot + 1, end);
        }
    }

}
