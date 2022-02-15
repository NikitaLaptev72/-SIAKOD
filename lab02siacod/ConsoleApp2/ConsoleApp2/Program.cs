using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApp2
{
    class Program
    {
        static void HanoiTowers(int number, int first, int second, int third)
        {
            if (number != 0)
            {
                HanoiTowers(number - 1, first, third, second);
                Console.WriteLine("Снимаем " + number + "-й диск с " + first + "-го стержня и кладем его на " + second + "-й стержень");
                HanoiTowers(number - 1, third, second, first);
            }
        }
        static void Main(string[] args)
        {
            var time = new Stopwatch();
            Console.WriteLine("Введите количество дисков: ");
            try
            {
                int number = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("Процесс:");
                time.Start();
                HanoiTowers(number, 1, 3, 2);
                time.Stop();
                Console.WriteLine("Завершено!");
                Console.WriteLine("Процесс занял: {0} миллисек.", time.ElapsedMilliseconds);
            }
            catch
            {
                Console.WriteLine("Проверьте введенные данные!");
            }
        }
    }
}
