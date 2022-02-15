using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3
{
    class Program
    {
        static long Power(int a, int n)
        {
            if (n == 1 || a == 1 || a == 0)
            {
                return a;
            }
            if (n % 2 == 0)
            {
                return Power(a, n / 2) * Power(a, n / 2);
            }
            else
            {
                return Power(a, (n - 1) / 2) * Power(a, (n - 1) / 2) * a;
            }
        }

        static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите число a: ");
                int a = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите степень N: ");
                int n = Convert.ToInt32(Console.ReadLine());
                if (n > 0 && a >= 0)
                {
                    Console.WriteLine("Число {0} в степени {1} = {2}", a, n, Power(a, n));
                }
                if (n == 0)
                {
                    Console.WriteLine("Число {0} в степени {1} = {2}", a, n, 1);
                }
            }
            catch
            {
                Console.WriteLine("Проверьте данные!");
            }
        }
    }
}
