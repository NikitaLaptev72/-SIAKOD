using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace _3
{
    class Program
    {
        //быстрая сортировка- неучтойчивая
        public static int[] Fast(int[] a, int L, int R)
        {
            int i = L, j = R, w, x;
            x = a[(L + R) / 2];
            do
            {
                while (a[i] < x)
                {
                    i++;
                }
                while (a[j] > x)
                {
                    j--;
                }
                if (i <= j)
                {
                    w = a[i];
                    a[i] = a[j];
                    a[j] = w;
                    i++;
                    j--;
                }
            } while (i < j);

            if (L < j)
            {
                Fast(a, L, j);
            }
            if (i < R)
            {
                Fast(a, i, R);
            }
            return a;
        }

        ////пирамидальная сортировка хорошо работает с большими массивами, 
        ////на примерах, где N<20, выгода от ее применения может быть не слишком очевидна. Неустойчивая

        static int Pyramid(int[] arr, int i, int N)
        {
            int k;
            int per;
            if ((2 * i + 2) < N)
            {
                if (arr[2 * i + 1] < arr[2 * i + 2])
                {
                    k = 2 * i + 2;
                }
                else
                {
                    k = 2 * i + 1;
                }
            }
            else
            {
                k = 2 * i + 1;
            }
            if (k >= N)
            {
                return i;
            }
            if (arr[i] < arr[k])
            {
                per = arr[i];
                arr[i] = arr[k];
                arr[k] = per;
                if (k < N / 2) i = k;
            }
            return i;
        }

        static void Pyramid_Sort(int[] arr, int lenght)
        {
            //построение
            for (int i = lenght / 2 - 1; i >= 0; i--)
            {
                long i1 = i;
                i = Pyramid(arr, i, lenght);
                if (i1 != i)
                {
                    i++;
                }
            }

            //сортировка
            int mer;
            for (int j = lenght - 1; j > 0; j--)
            {
                mer = arr[0];
                arr[0] = arr[j];
                arr[j] = mer;
                int i = 0, i1 = -1;
                while (i != i1)
                {
                    i1 = i;
                    i = Pyramid(arr, i, j);
                }
            }
        }


        //поразрядная- перед началом сортировки необходимо знать: length - максимальное количество разрядов в 
        //сортируемых величинах - 2 в двузначных,
        //range - количество возможных значений одного разряда - 10 в числе
        public static int[] ExchangeBitwise(int[] arr, int range, int length)
        {
            List<List<int>> lists = new List<List<int>>();
            for (int i = 0; i < range; ++i)
            {
                lists.Add(new List<int>());
            }

            for (int del = 0; del < length; del++)
            {
                //распределение по спискам
                for (int i = 0; i < arr.Length; i++)
                {
                    int razr = (arr[i] % (int)Math.Pow(range, del + 1)) / (int)Math.Pow(range, del);
                    lists[razr].Add(arr[i]);
                }


                int k = 0;
                for (int i = 0; i < range; ++i)
                {
                    for (int j = 0; j < lists[i].Count; j++)
                    {
                        arr[k++] = lists[i][j];
                    }
                }
                for (int i = 0; i < range; ++i)
                {
                    lists[i].Clear();
                }
            }
            return arr;
        }


        static int[] Creation(int[] mass)
        {
            Random rnd = new Random();
            for (int i = 0; i < mass.Count(); i++)
            {
                mass[i] = rnd.Next(1, int.MaxValue);
            }
            return mass;
        }

        static void Main(string[] args)
        {
            //быстрая
            int[] a1 = new int[50000];
            int[] a2 = new int[100000];
            int[] a3 = new int[200000];
            int[] b1 = new int[50000];
            int[] b2 = new int[100000];
            int[] b3 = new int[200000];
            int[] c1 = new int[50000];
            int[] c2 = new int[100000];
            int[] c3 = new int[200000];
            a1 = Creation(a1);
            a2 = Creation(a2);
            a3 = Creation(a3);
            b1 = a1;
            b2 = a2;
            b3 = a3;
            c1 = a1;
            c2 = a2;
            c3 = a3;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            a1 = Fast(a1, 0, a1.Count() - 1);
            sw.Stop();
            string time1 = sw.ElapsedTicks.ToString();
            sw.Reset();

            sw.Start();
            a2 = Fast(a2, 0, a2.Count() - 1);
            sw.Stop();
            string time2 = sw.ElapsedTicks.ToString();
            sw.Reset();

            sw.Start();
            a3 = Fast(a3, 0, a3.Count() - 1);
            sw.Stop();
            string time3 = sw.ElapsedTicks.ToString();
            sw.Reset();

            Console.WriteLine("\tБыстрая сортировка:");
            Console.WriteLine();
            Console.Write(a1.Count() + "\t\t" + a2.Count() + "\t\t" + a3.Count());
            Console.WriteLine("\n");
            Console.Write(time1 + "\t\t" + time2 + "\t\t" + time3);
            Console.WriteLine();

            //поразрядная
            sw.Start();
            c1 = ExchangeBitwise(c1, 10, 4);
            sw.Stop();
            string time7 = sw.ElapsedTicks.ToString();
            sw.Reset();

            sw.Start();
            c2 = ExchangeBitwise(c2, 10, 4);
            sw.Stop();
            string time8 = sw.ElapsedTicks.ToString();
            sw.Reset();

            sw.Start();
            c3 = ExchangeBitwise(c3, 10, 4);
            sw.Stop();
            string time9 = sw.ElapsedTicks.ToString();
            sw.Reset();

            Console.WriteLine();
            Console.WriteLine("\tПоразрядная сортировка:");
            Console.WriteLine();
            Console.Write(b1.Count() + "\t\t" + b2.Count() + "\t\t" + b3.Count());
            Console.WriteLine("\n");
            Console.Write(time7 + "\t\t" + time8 + "\t\t" + time9);
            Console.WriteLine();

            //пирамид
            sw.Start();
            Pyramid_Sort(b1, b1.Count());
            sw.Stop();
            string time4 = sw.ElapsedTicks.ToString();
            sw.Reset();

            sw.Start();
            Pyramid_Sort(b2, b2.Count());
            sw.Stop();
            string time5 = sw.ElapsedTicks.ToString();
            sw.Reset();

            sw.Start();
            Pyramid_Sort(b3, b3.Count());
            sw.Stop();
            string time6 = sw.ElapsedTicks.ToString();
            sw.Reset();

            Console.WriteLine();
            Console.WriteLine("\tПирамидальная сортировка:");
            Console.WriteLine();
            Console.Write(b1.Count() + "\t\t" + b2.Count() + "\t\t" + b3.Count());
            Console.WriteLine("\n");
            Console.Write(time4 + "\t" + time5 + "\t" + time6);
            Console.WriteLine();
        }
    }
}
