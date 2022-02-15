using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _2
{
    class Program
    {
        //быстрая сортировка - рекурсивный
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

        //комбинированный - увеличивает скорость при использовании небольшого кол-ва элементов
        public static void QuickSortComb(int[] mas, int left, int right)
        {
            const int M = 10;
            QuickSort(mas, left, right);
            if (right - left <= M)
            {
                return;
            }
            Random rnd = new Random();
            int x1 = rnd.Next(left, right);
            int first = mas[left];
            mas[left] = mas[x1];
            mas[x1] = first;
            double t = mas[left];
            int i = left;
            int j = right + 1;
            do
            {
                i++;
            } while (i <= right && mas[i] < t);

            do
            {
                j--;
            } while (mas[j] > t);

            first = mas[i];
            mas[i] = mas[j];
            mas[j] = first;
            QuickSortComb(mas, left, j - 1);
            QuickSortComb(mas, j + 1, right);
        }

        public static void QuickSortWithoutRec(int[] mass, int first, int last)
        {
            var stack = new Stack<int>();

            int pivot;
            int pivotIndex = 0;
            int leftIndex = pivotIndex + 1;
            int rightIndex = mass.Length - 1;

            stack.Push(pivotIndex);
            stack.Push(rightIndex);

            int leftIndexOfSubSet;
            int rightIndexOfSubSet;
            while (stack.Count > 0)
            {
                rightIndexOfSubSet = stack.Pop();
                leftIndexOfSubSet = stack.Pop();

                leftIndex = leftIndexOfSubSet + 1;
                pivotIndex = leftIndexOfSubSet;
                rightIndex = rightIndexOfSubSet;

                pivot = mass[pivotIndex];

                if (leftIndex > rightIndex) continue;//осуществляет принудительный переход к следующему шагу цикла, пропуская любой код, оставшийся невыполненным
                while (leftIndex < rightIndex)
                {
                    while ((leftIndex <= rightIndex) && (mass[leftIndex] <= pivot))
                        leftIndex++;
                    while ((leftIndex <= rightIndex) && (mass[rightIndex] >= pivot))
                        rightIndex--;
                    if (rightIndex >= leftIndex)
                    {
                        int tmp = mass[leftIndex];
                        mass[leftIndex] = mass[rightIndex];
                        mass[rightIndex] = tmp;
                    }
                }
                if (pivotIndex <= rightIndex)
                    if (mass[pivotIndex] > mass[rightIndex])
                    {
                        int tmp = mass[pivotIndex];
                        mass[pivotIndex] = mass[rightIndex];
                        mass[rightIndex] = tmp;
                    }
                if (leftIndexOfSubSet < rightIndex)
                {
                    stack.Push(leftIndexOfSubSet);
                    stack.Push(rightIndex - 1);
                }
                if (rightIndexOfSubSet > rightIndex)
                {
                    stack.Push(rightIndex + 1);
                    stack.Push(rightIndexOfSubSet);
                }
            }
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
            try
            {
                Call();
            }
            catch
            {
                Console.Clear();
                Call();
            }
        }

        static void Call()
        {
            Stopwatch sw = new Stopwatch();
            Random rnd = new Random();
            int[] a = new int[1000];
            int[] b = new int[1000];
            int[] c = new int[1000];

            a = Creation(a);
            b = Creation(b);
            c = Creation(c);

            Console.Write("Рекурсивная реализация потребовала: ");
            sw.Start();
            QuickSort(a, 0, a.Count() - 1);
            sw.Stop();
            Console.Write(sw.ElapsedTicks + " ticks");
            sw.Reset();
            Console.WriteLine();
            Console.Write("Нерекурсивная реализация потребовала: ");
            sw.Start();
            QuickSortWithoutRec(b, 0, b.Count());
            sw.Stop();
            Console.Write(sw.ElapsedTicks + " ticks");
            sw.Reset();
            Console.WriteLine();
            Console.Write("Комбинированная реализация потребовала: ");
            sw.Start();
            QuickSortComb(c, 0, c.Count() - 1);
            sw.Stop();
            Console.Write(sw.ElapsedTicks + " ticks");
            sw.Reset();
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
