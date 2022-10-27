using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V1
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

            string line1 = Console.ReadLine();
            int res1 = 0;
            //если line удаётся приобразовать в число res1 и res1 > 0
            if (int.TryParse(line1, out res1) && res1 > 0)
            {
                MassHelper helper = new MassHelper(res1);
                Console.WriteLine(helper);
                Console.WriteLine(helper.GetMassMin());
                Console.WriteLine(helper.GetMassMax());
                Console.WriteLine(helper.GetMassSumm());
                Console.WriteLine(helper.GetMassAvg());
                Console.WriteLine(helper.GetMassDisp());
            }
            else
                Console.WriteLine("Вводить нужно целое число больше 0!");
			
			//Console.ReadKey();
        }
    }

    /// <summary>
    /// Класс для работы с массивом случайных чисел
    /// </summary>
    class MassHelper
    {
        /// <summary>
        /// Массив чисел
        /// </summary>
        int[] mass;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="count"></param>
        public MassHelper(int count)
        {
            RandMass(count);
        }

        /// <summary>
        /// Перегрузка вывода объекта (вывод массива)
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            //соединить все элементы массива через запятую
            return string.Join(", ", mass);
        }

        /// <summary>
        /// Генерация случайных чисел в массиве
        /// </summary>
        /// <param name="count"></param>
        public void RandMass(int count)
        {
            Random _rand = new Random();

            mass = new int[count];
            for (int i = 0; i < mass.Length; i++)
                //случайное от 1 до 20
                mass[i] = _rand.Next(1, 20);
        }

        /// <summary>
        /// Вычисление суммы элементов
        /// </summary>
        /// <returns></returns>
        public int GetMassSumm()
        {
            int summ = 0;

            for (int i = 0; i < mass.Length; i++)
                summ += mass[i];

            return summ;
        }

        /// <summary>
        /// Вычисление максимального элемента
        /// </summary>
        /// <returns></returns>
        public int GetMassMax()
        {
            int max = int.MinValue;

            for (int i = 0; i < mass.Length; i++)
            {
                if (max < mass[i])
                    max = mass[i];
            }
            return max;
        }

        /// <summary>
        /// Вычисление минимального элемента
        /// </summary>
        /// <returns></returns>
        public int GetMassMin()
        {
            int min = int.MaxValue;

            for (int i = 0; i < mass.Length; i++)
            {
                if (min > mass[i])
                    min = mass[i];
            }
            return min;
        }

        /// <summary>
        /// Вычисление среднего арифметического
        /// </summary>
        /// <returns></returns>
        public decimal GetMassAvg()
        {
            return (decimal)GetMassSumm() / (decimal)mass.Length;
        }

        /// <summary>
        /// Вычисление дисперсии
        /// </summary>
        /// <returns></returns>
        public decimal GetMassDisp()
        {
            decimal summD = 0;
            decimal avg = GetMassAvg();

            for (int i = 0; i < mass.Length; i++)
                summD = summD + ((mass[i] - avg) * (mass[i] - avg));

            return (decimal)summD / (decimal)(mass.Length - 1);
        }



    }

}
