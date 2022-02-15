using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApp2
{
    public class List
    {
        public class Node
        {
            public int Value;
            public Node Next;
        }

        public Node First;

        public void AddFirst(int value)
        {
            Node node = new Node
            {
                Next = First,
                Value = value
            };
            First = node;
        }

        public void DeleteFirst()
        {
            if (First == null)
            {
                throw new Exception("Нельзя удалить элемент из пустого списка");
            }
            First = First.Next;
        }

        public void Print()
        {
            var first = true;
            for (var node = First; node != null; node = node.Next)
            {
                if (!first)
                {
                    Console.Write(" ");
                }
                first = false;
                Console.Write(node.Value);
            }
            Console.WriteLine();
        }  

        public void Task2(int count, int number)
        {
            Node current = First;
            int k = 1;
            while (count != 1)
            {
                k++;
                if (k == number)
                {
                    k = 1;
                    if (current.Next.Next != null)
                    {
                        current.Next = current.Next.Next;
                    }
                    else
                    {
                        current.Next = current.Next.Next;
                        current.Next.Next = First;
                    }
                    count--;
                }

                if (current.Next != null)
                {
                    current = current.Next;
                }
                else
                {
                    current.Next = First;
                    current = current.Next;
                }
            }
            Console.WriteLine("Оставшийся элемент: " + current.Value);
        }
    }

    class Program
    {
        public static int count = 0;
        public static int number = 0;
        public static int[] mas;

        static void Main(string[] args)
        {
            Random rnd = new Random();
            var mylist = new List();
            try
            {
                Console.WriteLine("******Задача на массиве******");
                Console.Write("Введите количество элементов для заполнения массива и списка: ");
                count = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите номер выбывающего: ");
                number = Convert.ToInt32(Console.ReadLine());
                mas = new int[count];
                for (int i = 0; i < count; i++)
                {
                    mas[i] = rnd.Next(1, 50);
                    Console.Write(mas[i] + " ");
                }
                Stopwatch timer1 = new Stopwatch();
                timer1.Start();
                Task1(count, number);
                timer1.Stop();
                Console.WriteLine("Реализация на массиве заняла {0} ticks", timer1.ElapsedTicks);
                Console.WriteLine();
                Console.WriteLine("******Задача на связном списке******");
                for (int i = 0; i < count; i++)
                {
                    mylist.AddFirst(rnd.Next(1, 50));
                }
                mylist.Print();
                Stopwatch timer2 = new Stopwatch();
                timer2.Start();
                mylist.Task2(count, number);
                timer2.Stop();
                Console.WriteLine("Реализация на списке заняла {0} ticks", timer2.ElapsedTicks);
                Console.WriteLine();
                if (timer1.ElapsedTicks > timer2.ElapsedTicks)
                {
                    Console.WriteLine("Реализация на списке быстрее");
                }
                else
                {
                    Console.WriteLine("Реализация на массиве быстрее");
                }
            }
            catch
            {
                Console.WriteLine("Проверьте введенные данные!");
            }
            Console.ReadLine();
        }

        static void Task1(int count, int number)
        {
            int i = -1;
            int leave = 0;
            int count1 = count;
            while (count1 > 1)
            {
                i++;
                if (i > count - 1)
                {
                    i = 0;
                }
                if (mas[i] != 0)
                {
                    leave++;
                }
                if (leave == number)
                {
                    mas[i] = 0;
                    leave = 0;
                    count1--;
                }
            }
            Console.WriteLine();
            for (int j = 0; j < count; j++)
            {
                if (mas[j] != 0)
                {
                    int findingnumber = j + 1;
                    Console.WriteLine("Оставшийся элемент: " + mas[j]);
                }
            }
        }
    }
}
