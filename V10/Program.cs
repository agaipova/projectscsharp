using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V10
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
                //путь к файлу
                string path = "1.txt";

                //смчитаем количество слов
                Console.Write(FileHelper.GetWordsSumm(path));
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
    /// Помощник при работе с файлами
    /// </summary>
    public static class FileHelper
    {
        /// <summary>
        /// Посчитать сумму слов в файле по пути path
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <returns>Количество слов</returns>
        public static int GetWordsSumm(string path)
        {
            //Если файл не существует, то генерируем ошибку
            if (!File.Exists(path))
                throw new Exception("Файл " + path + " не существует!");

            //Чтение текста из файла в переменную text
            string text = File.ReadAllText(path);

            //Удаляем пробелы до текста и после текста
            text = text.Trim();

            //удаляем все знаки табуляции
            while (text.Contains("\t"))
                text = text.Replace("\t", " ");

            //удаляем все переносы строк
            while (text.Contains("\n"))
                text = text.Replace("\n", " ");

            //Пока есть двойные пробелы, то удаляем их и ставим один пробел вместо двойных
            while (text.Contains("  "))
                text = text.Replace("  ", " ");

            //Делим по пробелам текст и считаем количество получившихся частей (это и есть количество слов)
            return text.Split(' ').Length;

        }
    }

}
