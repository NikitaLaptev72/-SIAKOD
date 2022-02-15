using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections;

namespace _6
{

    public class Queue
    {
        public class Node
        {
            public Node Next;
            public int Data;
            public int Priority;
        }

        Node Head;
        public int count;

        public void Add(int value, int priority)
        {
            Node NewNode = new Node();
            if (count == 0)
            {
                NewNode.Data = value;
                NewNode.Priority = priority;
                Head = NewNode;
            }
            else
            {
                if (Head.Priority < priority)
                {
                    NewNode.Data = value;
                    NewNode.Priority = priority;
                    NewNode.Next = Head;
                    Head = NewNode;
                }
                else
                {
                    Node Second = Head;
                    while (Second.Next != null && Second.Next.Priority > priority)
                    {
                        Second = Second.Next;
                    }
                    NewNode.Data = value;
                    NewNode.Priority = priority;
                    NewNode.Next = Second.Next;
                    Second.Next = NewNode;
                }
            }
            count++;
        }

        public int Count
        {
            get
            {
                return count;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return count == 0;
            }
        }

        public void Print()
        {
            var first = true;
            for (var node = Head; node != null; node = node.Next)
            {
                if (!first)
                {
                    Console.Write(" ");
                }
                first = false;
                Console.Write("Номер клиента: " + node.Data + " приоритет :" + node.Priority);
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public int DeleteFirst()
        {
            int dat = Head.Data;
            Head = Head.Next;
            count--;
            return dat;
        }        
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество очередей: ");
            int M = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите максимальное количество клиентов: ");
            int N = Convert.ToInt32(Console.ReadLine());
            Queue[] queueonpriority = new Queue[M];
            for (int i = 0; i < M; i++)
            {
                queueonpriority[i] = new Queue();
            }

            Random rnd = new Random();
            int priority = 0;
            int numberqueue = 0;
            for (int i = 1; i < N + 1; i++)
            {
                priority = rnd.Next(1, 100);
                Queue first = queueonpriority[0];
                for (int j = 0; j < M; j++)
                {
                    if (queueonpriority[j].count <= first.count)
                    {
                        first = queueonpriority[j];
                        numberqueue = j + 1;
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Добавлен клиент с номером: " + i + " и приоритетом: " + priority + " в очередь: " + numberqueue);
                first.Add(i, priority);
                int order = rnd.Next(1, 2);
                if (order == 1)
                {
                    if (first.count > 0)
                    {
                        Console.WriteLine("Из очереди с номером: " + numberqueue + " выбыл клиент с номером :" + first.DeleteFirst());
                        Console.WriteLine();
                    }
                }

                for (int j = 0; j < M; j++)
                {
                    Console.WriteLine("Очередь № " + (j + 1));
                    queueonpriority[j].Print();
                }
                Thread.Sleep(1000);
            }
        }
    }
}
