using System;
using System.IO;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "";
            Console.Write("Введите имя файла: ");
            path = Console.ReadLine();
            Console.WriteLine("Вводите числа. Для окончания введите '.'");
            string str;
            try
            {
                // создаем объект BinaryWriter                
                using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
                {
                    while (true)
                    {
                        str = Console.ReadLine();
                        if (str.Trim() == ".")
                            break;
                        try {
                            byte digit = Convert.ToByte(str);
                        }
                        catch(Exception) 
                        {
                            Console.WriteLine("Неверное число");
                            continue;
                        }                        
                        writer.Write(str);
                    }
                }            
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
