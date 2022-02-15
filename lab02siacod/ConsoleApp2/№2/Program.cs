using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
    class Program
    {
        static int Max(int[] mas, int Initial, int Last)
        {
            if (Initial == Last)
            {
                return mas[Initial];
            }
            int Half = (Initial + Last) / 2;
            int PreHalf = Max(mas, Initial, Half);
            int AfterHalf = Max(mas, Half + 1, Last);
            if (PreHalf > AfterHalf)
            {
                return PreHalf;
            }
            else
            {
                return AfterHalf;
            }
        }

        static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите размер массива: ");
                int n = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                int[] mas = new int[n];
                Random rnd = new Random();
                Console.WriteLine("Массив: ");
                for (int i = 0; i < n; i++)
                {
                    mas[i] = rnd.Next(1, 50);
                    Console.Write(mas[i] + " ");
                }
                Console.WriteLine();
                Console.WriteLine("Максимальный элемент: {0}", Max(mas, 0, n - 1));
                Console.ReadKey();
            }
            catch
            {
                Console.WriteLine("Проверьте входные даннеые!");
            }
        }
    }
}
