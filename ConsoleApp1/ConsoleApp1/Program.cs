using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        //быстрая сортировка- неучтойчивая
        public static int[] QuickSort(int[] mass, int Left, int Right)
        {
            int i = Left, j = Right, w, x;
            x = mass[(Left + Right) / 2];
            do
            {
                while (mass[i] < x)
                {
                    i++;
                }
                while (mass[j] > x)
                {
                    j--;
                }
                if (i <= j)
                {
                    w = mass[i];
                    mass[i] = mass[j];
                    mass[j] = w;
                    i++;
                    j--;
                }
            } while (i < j);

            if (Left < j)
            {
                QuickSort(mass, Left, j);
            }
            if (i < Right)
            {
                QuickSort(mass, i, Right);
            }
            return mass;
        }

        ////пирамидальная сортировка хорошо работает с большими массивами, 
        ////на примерах, где N<20, выгода от ее применения может быть не слишком очевидна. Неустойчивая

        static int Pyramid(int[] mass, int i, int N)
        {
            int k;
            int per;
            if ((2 * i + 2) < N)
            {
                if (mass[2 * i + 1] < mass[2 * i + 2])
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
            if (mass[i] < mass[k])
            {
                per = mass[i];
                mass[i] = mass[k];
                mass[k] = per;
                if (k < N / 2) i = k;
            }
            return i;
        }

        static int[] Pyramid_Sort(int[] mass, int lenght)
        {
            //построение
            for (int i = lenght / 2 - 1; i >= 0; i--)
            {
                long i1 = i;
                i = Pyramid(mass, i, lenght);
                if (i1 != i)
                {
                    i++;
                }
            }

            //сортировка
            int mer;
            for (int j = lenght - 1; j > 0; j--)
            {
                mer = mass[0];
                mass[0] = mass[j];
                mass[j] = mer;
                int i = 0, i1 = -1;
                while (i != i1)
                {
                    i1 = i;
                    i = Pyramid(mass, i, j);
                }
            }
            return mass;
        }

        //Сортировка слиянием - требуется большая память
        public static void Merger(int[] mass, int k, int q)
        {
            // k – нижняя граница упорядоченного фрагмента
            // q – верхняя граница фрагмента
            int i, j, t, mid;
            int[] d = new int[20];
            i = k;
            mid = k + (q - k) / 2;
            j = mid + 1;
            t = 1;
            while (i <= mid && j <= q)
            {
                if (mass[i] <= mass[j])
                {
                    d[t] = mass[i]; i++;
                }
                else
                {
                    d[t] = mass[j]; j++;
                }
                t++;
            }
            // Один из фрагментов обработан полностью, осталось перенести в D остаток другого фрагмента
            while (i <= mid)
            {
                d[t] = mass[i]; i++; t++;
            }
            while (j <= q)
            {
                d[t] = mass[j]; j++; t++;
            }

            for (i = 1; i <= t - 1; i++)
            {
                mass[k + i - 1] = d[i];
            }
        }
        // Рекурсивная реализация сортировки слиянием 
        public static int[] Sort_Merger(int[] mass, int i, int j)
        {
            int t;
            if (i < j)
            {
                // Обрабатываемый фрагмент массива состоит более, чем из одного элемента
                if (j - i == 1)
                {
                    if (mass[j] < mass[i])
                    // Обрабатываемый фрагмент массива состоит из двух элементов*)
                    {
                        t = mass[i]; mass[i] = mass[j]; mass[j] = t;
                    };
                }
                else
                {
                    // Разбиваем заданный фрагмент на два
                    Sort_Merger(mass, i, i + (j - i) / 2); // рекурсивные вызовы процедуры Sort_Sl
                    Sort_Merger(mass, i + (j - i) / 2 + 1, j);
                    Merger(mass, i, j);
                }
            }
            return mass;
        }

        //поразрядная- перед началом сортировки необходимо знать: length - максимальное количество разрядов в 
        //сортируемых величинах - 2 в двузначных,
        //range - количество возможных значений одного разряда - 10 в числе
        public static int[] ExchangeBitwise(int[] mass, int range, int length)
        {
            List<List<int>> lists = new List<List<int>>();
            for (int i = 0; i < range; ++i)
            {
                lists.Add(new List<int>());
            }

            for (int del = 0; del < length; del++)
            {
                //распределение по спискам
                for (int i = 0; i < mass.Length; i++)
                {
                    int razr = (mass[i] % (int)Math.Pow(range, del + 1)) / (int)Math.Pow(range, del);
                    lists[razr].Add(mass[i]);
                }


                int k = 0;
                for (int i = 0; i < range; ++i)
                {
                    for (int j = 0; j < lists[i].Count; j++)
                    {
                        mass[k++] = lists[i][j];
                    }
                }
                for (int i = 0; i < range; ++i)
                {
                    lists[i].Clear();
                }
            }
            return mass;
        }

        static int[] Creation(int[] mass)
        {
            Random rnd = new Random();
            for (int i = 0; i < mass.Count(); i++)
            {
                mass[i] = rnd.Next(1, 30);
                Console.Write(mass[i] + " ");
            }
            Console.WriteLine();
            return mass;
        }

        static void Main(string[] args)
        {
            int[] mass = new int[20];
            int menu = -1;
            while (menu != 0)
            {
                Console.WriteLine("************МЕНЮ************");
                Console.WriteLine("1)Быстрая сортировка \n2)Пирамидальная сортировка \n3)Сортировка слиянием \n4)Обменная поразрядная сортировка \n0)Выход");
                Console.WriteLine("****************************");
                Console.Write("Пункт меню: ");
                menu = Convert.ToInt32(Console.ReadLine());
                switch (menu)
                {
                    case (1):
                        {
                            Console.Clear();
                            Console.WriteLine("Исходный массив:");
                            mass = Creation(mass);
                            Console.WriteLine();
                            Console.WriteLine("Отсортированный массив:");
                            mass = QuickSort(mass, 0, mass.Length - 1);
                            for (int i = 0; i < mass.Length; i++)
                            {
                                Console.Write(mass[i] + " ");
                            }
                            Console.WriteLine();
                            Console.WriteLine();
                        }
                        break;
                    case (2):
                        {
                            Console.Clear();
                            Console.WriteLine("Исходный массив:");
                            mass = Creation(mass);
                            Console.WriteLine();
                            Console.WriteLine("Отсортированный массив:");
                            mass = Pyramid_Sort(mass,mass.Length);
                            for (int i = 0; i < mass.Length; i++)
                            {
                                Console.Write(mass[i] + " ");
                            }
                            Console.WriteLine();
                            Console.WriteLine();
                        }
                        break;
                    case (3):
                        {
                            Random rnd = new Random();
                            Console.Clear();
                            Console.WriteLine("Исходный массив:");
                            int[] a = new int[20];
                            int n = 19;
                            for (int i = 0; i < n; i++)
                            {
                                a[i] = rnd.Next(1, 30);
                                Console.Write(a[i] + " ");
                            }
                            Sort_Merger(a, 0, n - 1);
                            Console.WriteLine();
                            Console.WriteLine("Отсортированный массив:");;
                            for (int i = 0; i < n; i++)
                            {
                            //    if (a[i] != 0)
                            //    {
                                    Console.Write(a[i] + " ");
                                //}
                            }
                            Console.WriteLine();
                            Console.WriteLine();
                        }
                        break;
                    case (4):
                        {
                            Console.Clear();
                            Console.WriteLine("Исходный массив:");
                            mass = Creation(mass);
                            Console.WriteLine();
                            Console.WriteLine("Отсортированный массив:");
                            mass = ExchangeBitwise(mass, 2, 10);
                            for (int i = 0; i < mass.Length; i++)
                            {
                                Console.Write(mass[i] + " ");
                            }
                            Console.WriteLine();
                            Console.WriteLine();
                        }
                        break;
                    case (0): break;
                    default:
                        {
                            Console.WriteLine("Проверьте введенные данные!");
                        }
                        break;
                }
            }
        }
    }
}
