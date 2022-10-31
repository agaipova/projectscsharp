using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V16
{
    /// <summary>
    /// Главный класс
    /// </summary>
    public class Program
    {
        //Точка входа
        public static void Main(string[] args)
        {
            //блок контроля ошибок
            try
            {
                //путь к файлу
                string path = "1.txt";

                //считаем количество слов
                Console.Write(FileHelper.GetStringCountWords(FileHelper.GetCounter(path)));
            }
            //блок обработки ошибок
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }

        //    Console.ReadKey();

        }
    }

    /// <summary>
    /// Помощник при работе с файлами
    /// </summary>
    public static class FileHelper
    {

        /// <summary>
        /// Функция для формирование Hashtable из слов и их количества
        /// </summary>
        /// <param name="text">Текст</param>
        /// <returns>Хеш-таблица(Hashtable)</returns>
        public static Hashtable GetCounter(string path)
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

            //перевод слов в нижний регистр
            text = text.ToLower();

            //Делим по пробелам текст и считаем количество получившихся частей (это и есть количество слов)
            string [] words = text.Split(' ');

            Hashtable HT = new Hashtable();

            int N = words.Length;

            for (int i = 0; i <= N - 1; i++)
            {
                if (HT.ContainsKey(words[i]))
                    HT[words[i]] = (int)HT[words[i]] + 1;
                else
                    HT[words[i]] = 1;
            }

            return HT;
        }

        /// <summary>
        /// Получить строкое представление hastable
        /// </summary>
        /// <param name="words">Хеш-таблица с данными</param>
        /// <returns>Строковое представление</returns>
        public static string GetStringCountWords(Hashtable words)
        {
            string res = "";

            foreach(var key in words.Keys)
                res += key + ": " + words[key] + Environment.NewLine;

            return res;
        }
    }
}
