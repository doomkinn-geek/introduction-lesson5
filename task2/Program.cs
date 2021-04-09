using System;
using System.IO;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                File.AppendAllText("startup.txt", DateTime.Now.ToString("hh:mm:ss") + '\n');
            }
            catch(Exception e)
            {
                Console.WriteLine($"Ошибка доступа к файлу startup.txt: {e.Message}");
            }
        }
    }
}
