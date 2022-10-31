using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V24
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

            //создать объект
            MassHelper helper = new MassHelper(n);
            //вывод строкового представления массива
            Console.WriteLine(helper);
            //вывод только тех чисел, которых больше 3
            Console.WriteLine(helper.GetCounterString());

         //   Console.ReadKey();
        }
    }

    /// <summary>
    /// Класс для работы с массивом чисел
    /// </summary>
    public class MassHelper
    {
        //числа
        private decimal[] numbers;

        /// <summary>
        /// Консруктор для генерации чисел по количеству
        /// </summary>
        /// <param name="count"></param>
        public MassHelper(int count)
        {
            Random rand = new Random();
            numbers = new decimal[count];
            for (int i = 0; i < numbers.Length; i++)
                numbers[i] = rand.Next(1, 20);
        }

        /// <summary>
        /// Переопределённый вывод объекта (в данном случае - масси)
        /// </summary>
        /// <returns>Сформированная строка</returns>
        public override string ToString()
        {
            return string.Join(", ", numbers);
        }

        /// <summary>
        /// Вывод только тех чисел, которые больше трёх
        /// </summary>
        /// <returns>Сформированная строка</returns>
        public string GetCounterString()
        {
            string res = "";
            Hashtable counter = new Hashtable();

            //формируем хеш-таблицу
            for (int i = 0; i <= numbers.Length - 1; i++)
            {
                if (counter.ContainsKey(numbers[i]))
                    counter[numbers[i]] = (int)counter[numbers[i]] + 1;
                else
                    counter[numbers[i]] = 1;
            }
          
            //формируем вывод в строчном виде
            foreach (var key in counter.Keys)
            {
                if (Convert.ToDecimal(counter[key].ToString()) > 3)
                    res += "Число " + key + ": " + counter[key] + " повторений" + Environment.NewLine;
            }

            return res;
        }
    }
}
