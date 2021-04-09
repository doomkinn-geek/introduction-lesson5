using System;
using System.IO;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string strToWrite = "", fileName = "";
            Console.Write("Введите текст: ");
            strToWrite = Console.ReadLine();
            Console.Write("Введите имя файла: ");
            fileName = Console.ReadLine();
            try
            {
                File.WriteAllText(fileName, strToWrite, System.Text.Encoding.UTF8);
            }
            catch(Exception e)
            {
                Console.WriteLine($"Невозможно записать текст в файл: {e.Message}");
                return;
            }
            Console.WriteLine($"Файл {fileName} успешно создан");
        }
    }
}
