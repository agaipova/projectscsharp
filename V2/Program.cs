using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V2
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
            //блок, где может произойти ошибка (основной код)
            try
            {
                //Вводим размер массивов (если указано не число или число меньше 0 или 0, то ещё раз спрашиваем)
                string line1 = "";
                int count = 0;
                do
                {
                    Console.WriteLine("Введите размер: ");
                    line1 = Console.ReadLine();
                }
                while (!int.TryParse(line1, out count) || count <= 0);

                //Вводим элементы массива x (если элемент не число, то ещё раз спрашиваем)
                double[] x = new double [count];
                for (int i = 0; i < count; i++)
                {
                    double elem = 0;
                    do
                    {
                        Console.WriteLine("Введите элемент x[" + i + "]: ");
                        line1 = Console.ReadLine();
                    }
                    while (!double.TryParse(line1, NumberStyles.Any, CultureInfo.InvariantCulture, out elem));
                    x[i] = elem;
                }

                //Вводим элементы массива y (если элемент не число, то ещё раз спрашиваем)
                double[] y = new double[count];
                for (int i = 0; i < count; i++)
                {
                    double elem = 0;
                    do
                    {
                        Console.WriteLine("Введите элемент y[" + i + "]: ");
                        line1 = Console.ReadLine();
                    }
                    while (!double.TryParse(line1, NumberStyles.Any, CultureInfo.InvariantCulture, out elem));
                    y[i] = elem;
                }

                //Выполняем вывод в табличном виде
                new TabulateHelper(x, y);
				
            }
            //обработка, если возникла ошибка
            catch(Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
			
			//Console.ReadKey();

        }

        

    }

    /// <summary>
    /// Помощник для создания таблицы
    /// </summary>
    public class TabulateHelper
    {
        /// <summary>
        /// Делегат функции
        /// </summary>
        /// <param name="x">Массив x</param>
        /// <param name="y">Массив y</param>
        private delegate void Func(double [] x, double [] y);

        /// <summary>
        /// Создание объекта делегата
        /// </summary>
        private Func func;

        /// <summary>
        /// Открытый конструктор для вывода массивов x и y в виде таблицы 
        /// </summary>
        /// <param name="x">Массив x</param>
        /// <param name="y">Массив y</param>
        public TabulateHelper(double[] x, double[] y)
        {
            //назначаем функцию для объекта делегата
            Func func = PrintTabTable;
            //выполняем объект делегата
            func.Invoke(x, y);
        }

        /// <summary>
        /// Закрытый вывод таблицы на экран
        /// </summary>
        /// <param name="x">Массив x</param>
        /// <param name="y">Массив y</param>
        private void PrintTabTable(double [] x, double [] y)
        {
            //если размеры массивов не равны или равны 0, то генерируем ошибку
            if (x.Length != y.Length || x.Length == 0)
                throw new Exception("Данные указаны неверно! Размер X и Y должен совпадать и не быть 0!");

            char vertSep = '|';
            char horSep = '=';

            string res = "";

            res += vertSep + "X\t" + vertSep + "Y" + "\t" + vertSep  + "\n";

            for (int i = 0; i < x.Length; i++)
            {
                for (int j=0;j<6;j++)
                    res += horSep;
            }  
            res += "\n";

            //CultureInfo - чтобы в одном формате всегда были вещественные числа на выводе
            for (int i = 0; i < x.Length; i++)
                res += vertSep + Math.Round(x[i],4).ToString(CultureInfo.InvariantCulture) + "\t" + vertSep + Math.Round(y[i],4).ToString(CultureInfo.InvariantCulture) + "\t" + vertSep + "\n";

            Console.WriteLine(res);
        }
    }

}
