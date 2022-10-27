using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GaussProgram
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        public Form1()
        {
            //В этом методе реализация всей формы (график, список, кнопки и другие элементы управления)
            InitializeComponent();
        }

        //Таблица сгенерированных точек (точки X и их количество Y)
        Hashtable points;

        /// <summary>
        /// Метод, который срабатывает по нажатию на кнопку "Сгенерировать точки"
        /// </summary>
        /// <param name="sender">Какой элемент вызвал метод</param>
        /// <param name="e">Дополнительные параметры</param>
        private void button1_Click(object sender, EventArgs e)
        {
            //очистка списка от точек
            listBox1.Items.Clear();
            //очистка графика от точек
            chart1.Series[0].Points.Clear();

            //вызываем генерацию чисел методом Гаусса (количество чисел, параметр "му", параметр "сигма")
            //получаем все точки в массив mass
            int[] mass = GausseMethod(Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown2.Value), Convert.ToInt32(numericUpDown3.Value));

            //формируем таблицу X и Y из массива mass
            points = RandomFrequency(mass);
            //добавляем X и Y в список через пробел и на график
            foreach (DictionaryEntry item in points)
            {
                chart1.Series[0].Points.AddXY(item.Key, item.Value);
                listBox1.Items.Add(item.Key.ToString()+ "  "+ item.Value.ToString());
            }
        }


        /// <summary>
        /// Получение массива случайных целых чисел с помощью метода Гаусса
        /// </summary>
        /// <param name="num">Количество необходимых элементов</param>
        /// <param name="mu">μ (Му) параметр</param>
        /// <param name="sigma">σ(Сигма) параметр</param>
        /// <returns>Полученный массив целых чисел</returns>
        public int[] GausseMethod(int num, double mu, double sigma)
        {
            //массив целых чисел (сейчас все числа = 0)
            int[] res = new int[num];

            //Генератор
            Random rand = new Random();
            for (int i = 0; i < num; i++)
            {
                //Сюда будет накапливать сумму
                double summ = 0;
                //Выполняем 13 интераций накапливания суммы со случайных чисел
                for (int j = 0; j < 13; j++)
                {
                    //получение случайного вещественного числа
                    double number = rand.NextDouble();
                    //накапливаем сумму
                    summ = summ + number;
                }
                //вычисляем итоговой число по формуле (оставляем три знака после запятой)
                double dRandValue = Math.Round(mu + sigma * (summ - 6), 3);
                //записываем результат в массив в виде целого числа
                res[i] = (int) Math.Round(dRandValue);
            }

            //возвращаем массив
            return res;

        }

        /// <summary>
        /// Функция для формирования X и Y из массива randomNums
        /// </summary>
        /// <param name="randomNums">Массив случайных целых чисел</param>
        /// <returns></returns>
        private Hashtable RandomFrequency(int[] randomNums)
        {
            Hashtable HT = new Hashtable();
            int N = randomNums.Length;

            for (int i = 0; i <= N - 1; i++)
            {
                if (HT.ContainsKey(randomNums[i]))
                    HT[randomNums[i]] = (int)HT[randomNums[i]] + 1;
                else
                    HT[randomNums[i]] = 1;
            }

            return HT;
        }

        /// <summary>
        /// Метод проверки криетрия Пирсона
        /// </summary>
        /// <param name="HT">X и Y</param>
        public void Pirson(Hashtable HT)
        {
            //будем записывать отдельно X и Y
            double[] X = new double[HT.Count];
            double[] Y = new double[HT.Count];
            int j = 0;
            //получение X и Y отдельно из HT
            foreach (DictionaryEntry item in HT)
            {
                X[j] = (int)item.Key;
                Y[j] = (double) ((Convert.ToDouble(item.Value)) / ((double) HT.Count));
                j++;
            }

            //вычисление среднего арифметического X
            double XAvg = X.Average();
            //вычисление среднего арифметического Y
            double YAvg = Y.Average();

            //вычисление чисел dx по формуле
            double[] dX = new double[HT.Count];
            for (int i = 0; i < X.Length; i++)
                dX[i] = X[i] - XAvg;

            //вычисление чисел dy по формуле
            double[] dY = new double[HT.Count];
            for (int i = 0; i < Y.Length; i++)
                dY[i] = Y[i] - YAvg;

            //вычисление чисел dx в квадрате
            double[] dX2 = new double[HT.Count];
            for (int i=0;i<X.Length; i++)
                dX2[i] = Math.Pow(dX[i], 2);

            //вычисление чисел dy в квадрате
            double[] dY2 = new double[HT.Count];
            for (int i = 0; i < Y.Length; i++)
                dY2[i] = Math.Pow(dY[i], 2);

            //вычисление чисел dx * dy
            double[] dXMultdY = new double[HT.Count];
            for (int i = 0; i < X.Length; i++)
                dXMultdY[i] = dX[i] * dY[i];

            //получение суммы всех чисел dx в квадрате
            double dX2Sum = dX2.Sum();
            //получение суммы всех чисел dy в квадрате
            double dY2Sum = dY2.Sum();
            //получение суммы всех чисел dx * dy
            double dXMultdYSum = dXMultdY.Sum();

            //количество степеней свободы = количество X - 2
            int f = HT.Count - 2;

            //расчёт коэффициента корреляции rXY
            double rXY = dXMultdYSum / (Math.Sqrt(dX2Sum * dY2Sum));
            //расчёт t-критерия
            double t = rXY * Math.Sqrt(f) / (Math.Sqrt(1 - Math.Pow(rXY, 2)));

            //вывод полученных данных на экран
            MessageBox.Show("Количество степеней свободы (f): " + f + Environment.NewLine+"t-критерий (расчитанный): "+t + Environment.NewLine + "Значение коэффициента корреляции (rXY): " + rXY);
        }

        /// <summary>
        /// Метод, который срабатывает по нажатию на кнопку "ПРоверить по критерию Пирсона"
        /// </summary>
        /// <param name="sender">Какой элемент вызвал метод</param>
        /// <param name="e">Дополнительные параметры</param>
        private void button2_Click(object sender, EventArgs e)
        {
            Pirson(points);
        }
    }
}
