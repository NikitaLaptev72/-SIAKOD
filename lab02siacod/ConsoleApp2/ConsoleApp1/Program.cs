using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApp1
{
    class Program
    {
        static int[] FMas = new int[36];
        
        //Бине
        static double Bine(int n)
        {
            var number = (1 + Math.Sqrt(5)) / 2;
            return Math.Round(Math.Pow(number, n) / Math.Sqrt(5));
        }

        //Разделяй и властвуй
        static int F(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            if (n == 1)
            {
                return 1;
            }
            return F(n - 1) + F(n - 2);
        }

        //восходящее динамическое программирование 
        static int  RisingDyn(int n)
        {
            int[] mas = new int[n + 1];

            mas[1] = 1;
            mas[2] = 1;
            if (n <= 2) return 1;
            for (int i = 3; i <= n; i++)
            {
                mas[i] = mas[i - 1] + mas[i - 2];
            }
            return mas[n];
        }

        //нисходящее динамическое программирование 
        public static int DownDyn(int n)
        {
            if (FMas[n] == 0)
            {
                if (n == 0)
                {
                    FMas[n] = 0;
                }
                else
                {
                    if (n == 1)
                    {
                        FMas[n] = 1;
                    }
                    else
                    {
                        FMas[n] = DownDyn(n - 1) + DownDyn(n - 2);
                    }
                }
            }
            return FMas[n];
        }

        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine("Формула Бине: {0}", Bine(35));
            stopwatch.Stop();
            Console.WriteLine("Расчет по Бине занял: {0} тактов.\n", stopwatch.ElapsedTicks);

            stopwatch.Reset();
            stopwatch.Start();
            Console.WriteLine("Разделяй и влавствуй: {0}", F(35));
            stopwatch.Stop();
            Console.WriteLine("Расчет по разделяй и властуй занял: {0} тактов.\n", stopwatch.ElapsedTicks);

            stopwatch.Reset();
            stopwatch.Start();
            Console.WriteLine("Восходящее динамическое: {0}", RisingDyn(35));
            stopwatch.Stop();
            Console.WriteLine("Расчет по восходящему динамическому: {0} тактов.\n", stopwatch.ElapsedTicks);

            stopwatch.Reset();
            stopwatch.Start();
            Console.WriteLine("Нисходящее динамическое: {0}", DownDyn(35));
            stopwatch.Stop();
            Console.WriteLine("Расчет по нисходящему динамическому: {0} тактов.\n", stopwatch.ElapsedTicks);
        }
    }
}
