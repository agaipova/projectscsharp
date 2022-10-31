using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V19
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
            //Создание массива
            MassHelper helper = new MassHelper();
            //Вывод созданного массива
            Console.WriteLine(helper);
            //Вывод чётных и нечётных чисел
            Console.WriteLine(helper.GetEvenOddMass());

         //   Console.ReadKey();
        }
    }
    /// <summary>
    /// Будет использовано для возврата двух массивов
    /// </summary>
    public class Ret2Mass
    {
        /// <summary>
        /// Закрытые массивы чётных и нечётных чисел
        /// </summary>
        private int[] EvenNumberMass;
        private int[] OddNumberMass;

        /// <summary>
        /// Конструктор для создание объекта
        /// </summary>
        /// <param name="EvenNumberMass"></param>
        /// <param name="OddNumberMass"></param>
        public Ret2Mass(int[] EvenNumberMass, int[] OddNumberMass)
        {
            this.EvenNumberMass = EvenNumberMass;
            this.OddNumberMass = OddNumberMass;
        }

        /// <summary>
        /// Переопределённый вывод массива
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Чётные: " + string.Join(", ", EvenNumberMass) + Environment.NewLine + "Нечётные: " + string.Join(", ", OddNumberMass);
        }
    }

    /// <summary>
    /// Класс для работы с массивом
    /// </summary>
    public class MassHelper
    {
        /// <summary>
        /// Скрытый массив элементов
        /// </summary>
        private int[] mass;

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
            mass = new int[n];
            for (int i = 0; i < n; i++)
            {
                    int elem = 0;
                    do
                    {
                        Console.WriteLine("Введите элемент matrix[" + i + "]: ");
                        line1 = Console.ReadLine();
                    }
                    while (!int.TryParse(line1, NumberStyles.Any, CultureInfo.InvariantCulture, out elem));
                    mass[i] = elem;
            }
        }

        /// <summary>
        /// Получение дву массивов: чётных и нечётных чисел в виде объекта Ret2Mass (чтобы не использовать Tuple)
        /// </summary>
        /// <returns>Объект Ret2Mass</returns>
        public Ret2Mass GetEvenOddMass()
        {
            List<int> evenList = new List<int>();
            List<int> oddList = new List<int>();

            for(int i=0;i<mass.Length;i++)
            {
                if (mass[i] % 2 == 0)
                    evenList.Add(mass[i]);
                else
                    oddList.Add(mass[i]);
            }

            return new Ret2Mass(evenList.ToArray(), oddList.ToArray());
        }

        /// <summary>
        /// Переопределённый вывод массива
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Массив: " + string.Join(", ", mass);
        }

    }
}
