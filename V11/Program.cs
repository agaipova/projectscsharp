using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V11
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
            //блок контроля ошибок
            try
            {

                //Создание первой матрицы и её вывод
                Matrix matr1 = new Matrix();
                Console.WriteLine(matr1);

                //Создание второй матрицы и доабвление к первой, вывод полученной
                Matrix matr2 = new Matrix(new decimal[,] { { 1, 5 }, { 7, 4 } });
                matr2 = matr2.AddMatrix(matr1);
                Console.WriteLine(matr2);

                //Создание третьей матрицы и умножение на неё же, вывод полученной
                Matrix matr3 = new Matrix(new decimal[,] { { 1, 5 }, { 7, 4 } });
                matr3 = matr3.MultMatrix(matr3);
                Console.WriteLine(matr3);

                //Доабвление к первой матрице 1 и потом уножение на 2 и вывод
                matr1 = matr1.AddNumber(1);
                matr1 = matr1.MultNumber(2);
                Console.WriteLine(matr1);
            }
            //блок обработки ошибок
            catch(Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }

            //Console.ReadKey();

        }
    }

    /// <summary>
    /// Класс матрицы
    /// </summary>
    public class Matrix
    {
        /// <summary>
        /// Скрытая матрица
        /// </summary>
        private decimal[,] matrix;

        /// <summary>
        /// Конструктор матрицы
        /// </summary>
        /// <param name="matrix">матрица</param>
        public Matrix(decimal [,] matrix)
        {
            this.matrix = matrix;
        }

		/// <summary>
        /// Конструктор с вводом данных
        /// </summary>
        public Matrix()
        {
            //Вводим количество строк (если указано не число или число меньше 0 или 0, то ещё раз спрашиваем)
            string line1;
            int n;
            do
            {
                Console.WriteLine("Введите количество строк: ");
                line1 = Console.ReadLine();
            }
            while (!int.TryParse(line1, out n) || n <= 0);

            //Вводим количество столбцов (если указано не число или число меньше 0 или 0, то ещё раз спрашиваем)
            int m;
            do
            {
                Console.WriteLine("Введите количество стобцов: ");
                line1 = Console.ReadLine();
            }
            while (!int.TryParse(line1, out m) || m <= 0);

            //Вводим элементы матрицы (если элемент не число, то ещё раз спрашиваем)
            this.matrix = new decimal[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    decimal elem = 0;
                    do
                    {
                        Console.WriteLine("Введите элемент matrix[" + i + ", " + j + "]: ");
                        line1 = Console.ReadLine();
                    }
                    while (!decimal.TryParse(line1, NumberStyles.Any, CultureInfo.InvariantCulture, out elem));
                    this.matrix[i,j] = elem;
                }
            }

        }

        /// <summary>
        /// Переопределение функции вывода в строку
        /// </summary>
        /// <returns>строка</returns>
        public override string ToString()
        {
            string res = "";
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                    res += matrix[i,j] + " ";
                res += Environment.NewLine;
            }

            return res;

        }

        /// <summary>
        /// Добавить число к матрице
        /// </summary>
        /// <param name="number">Число</param>
        /// <returns>Новая матрица</returns>
        public Matrix AddNumber(decimal number)
        {
            decimal[,] res = new decimal [matrix.GetLength(0),matrix.GetLength(1)];
            for (int i=0;i<matrix.GetLength(0);i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                    res[i,j] = matrix[i,j] + number;
            }

            return new Matrix(res);
        }

        /// <summary>
        /// Умножение (произведение) матрицы на число
        /// </summary>
        /// <param name="number">Число</param>
        /// <returns>Новая матрица</returns>
        public Matrix MultNumber(decimal number)
        {
            decimal[,] res = new decimal[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                    res[i, j] = matrix[i, j] * number;
            }

            return new Matrix(res);
        }

        /// <summary>
        /// Добавление двух матриц
        /// </summary>
        /// <param name="obj">Матрица</param>
        /// <returns>Новая матрица</returns>
        public Matrix AddMatrix(Matrix obj)
        {
            //Если разные размерности, то ошибка
            if (matrix.GetLength(0) != obj.matrix.GetLength(0) || matrix.GetLength(1) != obj.matrix.GetLength(1))
                throw new Exception("Матрицы разные по размерности!");

            decimal[,] res = new decimal[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                    res[i, j] = matrix[i, j] + obj.matrix[i, j];
            }

            return new Matrix(res);
        }

        /// <summary>
        /// Умножение (произведение) двух матриц
        /// </summary>
        /// <param name="obj">Матрица</param>
        /// <returns>Новая матрица</returns>
        public Matrix MultMatrix(Matrix obj)
        {
            //если размерности не подходят, то ошибка
            if (matrix.GetLength(1) != obj.matrix.GetLength(0))
                throw new Exception("Матрицы нельзя умножить!");

            decimal[,] res = new decimal[matrix.GetLength(0), obj.matrix.GetLength(1)];
            for (int i = 0; i < res.GetLength(0); i++)
            {
                for (int j = 0; j < res.GetLength(1); j++)
                {
                    res[i, j] = 0;
                    for (int k = 0; k < matrix.GetLength(1); k ++)
                        res[i, j] += matrix[i, k] * obj.matrix[k, j];
                }
            }

            return new Matrix(res);
        }


    }

}
