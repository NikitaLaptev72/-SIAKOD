using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Поиски_на_массиве
{
    class Program
    {
        public static int[] myarray;

        public static int[] CreationArray(int count)
        {
            myarray = new int[count];
            for (int i = 0; i < myarray.Count(); i++) 
            {
                myarray[i] = i;
            }
            return myarray;
        }

        //Последовательный поиск
        public static void SequentialSearch(int count, int pass, int request)
        {
            Stopwatch timer = new Stopwatch();
            myarray = CreationArray(count);
            int find = request;
            timer.Start();
            for (int i = 1; i < pass; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    if ((myarray[j] == find) || (j == count))
                    {
                        break;
                    }
                }
            }
            timer.Stop();
            string time = timer.ElapsedTicks.ToString();
            myarray = null;
            timer.Reset();
            Console.WriteLine("\t{0}\t\t\t П\t\t\t {1}\t\t\t {2}", pass, count, time);
            Console.WriteLine();
        }

        //Последовательный поиск с барьером
        public static void SequentialSearchWithBarrier(int count, int pass, int request)
        {
            Stopwatch timer = new Stopwatch();
            myarray = CreationArray(count+1);
            int find = request;
            myarray[count] = find;
            timer.Start();
            for (int i = 1; i < pass; i++)
            {
                int j = 0;
                while (myarray[j] != find)
                {
                    j++;
                }
            }
            timer.Stop();
            string time = timer.ElapsedTicks.ToString();
            myarray = null;
            timer.Reset();
            Console.WriteLine("\t{0}\t\t\t ПБ\t\t\t {1}\t\t\t {2}", pass, count, time);
            Console.WriteLine();
        }

        //Бинарный поиск
        public static int BinarySearch(int[] array, int value, int first, int last)
        {
            int mid = (first + last) / 2;

            if (first >= last)
            {
                return mid;
            }

            if (value <= array[mid])
            {
                return BinarySearch(array, value, first, mid);
            }
            else
            {
                return BinarySearch(array, value, mid + 1, last);
            }
        }

        public static void SearchWithBinary(int count, int pass, int request)
        {
            Stopwatch timer = new Stopwatch();
            myarray = CreationArray(count);
            int find = request;
            timer.Start();
            for (int i = 0; i < pass; i++)
            {
                BinarySearch(myarray, find, 0, count - 1);
            }
            timer.Stop();
            string time = timer.ElapsedTicks.ToString();
            myarray = null;
            timer.Reset();
            Console.WriteLine("\t{0}\t\t\t Б\t\t\t {1}\t\t\t {2}", count, pass,  time);
            Console.WriteLine();
        }

        //Интерполяционный поиск
        public static int InterpolSearch(int[] array, int request, int first, int last)
        {
            last = array.Length - 1;
            while (array[first] < request && array[last] > request)
            {
                int mid = first + (request - array[first]) * (last - first) / (array[last] - array[first]);
                if (array[mid] < request)
                {
                    first = mid + 1;
                }
                else
                {
                    if (array[mid] > request)
                    {
                        last = mid - 1;
                    }
                    else
                    {
                        return mid;
                    }
                }
            }
            if (array[first] == request)
            {
                return first;
            }
            else
            {
                if (array[last] == request)
                {
                    return last;
                }
                else
                {
                    return -1;
                }
            }
        }

        public static void SearchInterpol(int count, int pass, int request)
        {
            Stopwatch timer = new Stopwatch();
            myarray = CreationArray(count);
            int find = request;
            timer.Start();
            for (int i = 0; i < pass; i++)
            {
                InterpolSearch(myarray, find, 0, count );
            }
            timer.Stop();
            string time = timer.ElapsedTicks.ToString();
            myarray = null;
            timer.Reset();
            Console.WriteLine("\t{0}\t\t\t И\t\t\t {1}\t\t\t {2}", count, pass,  time);
            Console.WriteLine();
        }

        public static void CallSearchA()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Условные обозначения:\nП - последовательный поиск\nПБ - последовательный поиск с барьером");
            Console.WriteLine("Количество поисков\t\t Поиск\t\t Количество элементов\t\t Время(ticks)");
            Console.WriteLine();
            Random rnd = new Random();
            int request = rnd.Next(1, 1000);
            SequentialSearch(1000, 5000, request);
            SequentialSearchWithBarrier(1000, 5000, request);
            SequentialSearch(1000, 10000, request);
            SequentialSearchWithBarrier(1000, 10000, request);
            SequentialSearch(1000, 20000, request);
            SequentialSearchWithBarrier(1000, 20000, request);
            request = rnd.Next(1, 2000);
            SequentialSearch(2000, 5000, request);
            SequentialSearchWithBarrier(2000, 5000, request);
            SequentialSearch(2000, 10000, request);
            SequentialSearchWithBarrier(2000, 10000, request);
            SequentialSearch(2000, 20000, request);
            SequentialSearchWithBarrier(2000, 20000, request);
            request = rnd.Next(1, 4000);
            SequentialSearch(4000, 5000, request);
            SequentialSearchWithBarrier(4000, 5000, request);
            SequentialSearch(4000, 10000, request);
            SequentialSearchWithBarrier(4000, 10000, request);
            SequentialSearch(4000, 20000, request);
            SequentialSearchWithBarrier(4000, 20000, request);
            request = rnd.Next(1, 8000);
            SequentialSearch(8000, 5000, request);
            SequentialSearchWithBarrier(8000, 5000, request);
            SequentialSearch(8000, 10000, request);
            SequentialSearchWithBarrier(8000, 10000, request);
            SequentialSearch(8000, 20000, request);
            SequentialSearchWithBarrier(8000, 20000, request);
            request = rnd.Next(1, 16000);
            SequentialSearch(16000, 5000, request);
            SequentialSearchWithBarrier(16000, 5000, request);
            SequentialSearch(16000, 10000, request);
            SequentialSearchWithBarrier(16000, 10000, request);
            SequentialSearch(16000, 20000, request);
            SequentialSearchWithBarrier(16000, 20000, request);
            Console.ResetColor();
        }

        public static void CallSearchB()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Условные обозначения:\nБ - бинарный поиск\nИ - интерполяционный поиск");
            Console.WriteLine("Количество поисков\t\t Поиск\t\t Количество элементов\t\t Время(ticks)");
            Console.WriteLine(); Random rnd = new Random();
            int request = rnd.Next(1, 5000);
            SearchWithBinary(5000, 1000, request);
            SearchInterpol(5000, 1000, request);
            SearchWithBinary(5000, 2000, request);
            SearchInterpol(5000, 2000, request);
            SearchWithBinary(5000, 4000, request);
            SearchInterpol(5000, 4000, request);
            SearchWithBinary(5000, 8000, request);
            SearchInterpol(5000, 8000, request);
            SearchWithBinary(5000, 10000, request);
            SearchInterpol(5000, 10000, request);
            request = rnd.Next(1, 10000);
            SearchWithBinary(10000, 1000, request);
            SearchInterpol(10000, 1000, request);
            SearchWithBinary(10000, 2000, request);
            SearchInterpol(10000, 2000, request);
            SearchWithBinary(10000, 4000, request);
            SearchInterpol(10000, 4000, request);
            SearchWithBinary(10000, 8000, request);
            SearchInterpol(10000, 8000, request);
            SearchWithBinary(10000, 10000, request);
            SearchInterpol(10000, 10000, request);
            request = rnd.Next(1, 20000);
            SearchWithBinary(20000, 1000, request);
            SearchInterpol(20000, 1000, request);
            SearchWithBinary(20000, 2000, request);
            SearchInterpol(20000, 2000, request);
            SearchWithBinary(20000, 4000, request);
            SearchInterpol(20000, 4000, request);
            SearchWithBinary(20000, 8000, request);
            SearchInterpol(20000, 8000, request);
            SearchWithBinary(20000, 10000, request);
            SearchInterpol(20000, 10000, request);
            Console.ResetColor();
        }

        static void Main(string[] args)
        {
            Console.WindowWidth = 150;
            Console.WindowHeight = 50;
            int menu = 1;
            while (menu != 0)
            {
                Console.WriteLine("Выберите вариант задания:\n 1)А 2)Б");
                menu = Convert.ToInt32(Console.ReadLine());
                switch(menu)
                {
                    case (1):
                        {
                            Console.WriteLine();
                            CallSearchA();
                            Console.WriteLine();

                        }
                        break;
                    case (2):
                        {
                            Console.WriteLine();
                            CallSearchB();
                            Console.WriteLine();
                        }
                        break;
                    default: Console.WriteLine("Проверьте введенные данные!"); break;
                }
            }
        }
    }
}
