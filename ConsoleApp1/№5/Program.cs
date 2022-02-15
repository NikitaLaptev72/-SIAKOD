using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5
{
    class QueueOnArray<T>
    {
        T[] items;
        int count;
        const int n = 10;
        
        int head; 

        int tail;

        public QueueOnArray(int length)
        {
            items = new T[length];
        }

        public bool IsEmpty
        {
            get
            {
                return count == 0;
            }
        }

        public int Count
        {
            get
            {
                return count;
            }
        }

        public void Add(T item)
        {
            if (count == items.Length)
            {
                var capacity = items.Length * 2;
                SetCapacity(capacity);
            }
            items[tail] = item;
            tail++;
            count++;
        }

        void SetCapacity(int capacity)
        {
            //Новый массив заданного объёма
            T[] destinationArray = new T[capacity];
            if (Count > 0)
            {
                //Копирование старого массива в новый
                if (head < tail)
                {
                    Array.Copy(items, head, destinationArray, 0, Count);
                }
                else
                {
                    Array.Copy(items, head, destinationArray, 0, items.Length - head);
                    Array.Copy(items, 0, destinationArray, items.Length - head, tail);
                }
            }
            items = destinationArray;
            head = 0;
            if (Count == capacity)
            {
                tail = 0;
            }
            else
            {
                tail = Count;
            }
        }

        public T Delete()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Очередь пуста");
            }
            T local = items[head];
            items[head] = default(T);
            head++;
            count--;
            Console.Write("Удален: " + local + " ");
            return local;
        }

        public void Print()
        {
            int c = count;
            if (IsEmpty)
            {
                throw new InvalidOperationException("Очередь пуста");
            }
            for (int i = 0; i < count; i++)
            {
                Console.Write(items[head++] + " ");
            }
            head = 0;
            Console.WriteLine();
        }
    }

    class QueueOnList<T>
    {
        public class Node
        {
            public Node(T data)
            {
                Data = data;
            }

            public T Data;
            public Node Next;
        }

        public Node Head;
        public Node Tail;
        int count = 0;

        public void Add(T data)
        {
            Node node = new Node(data);
            Node tempNode = Tail;
            Tail = node;
            if (count == 0)
            {
                Head = Tail;
            }
            else
            {
                tempNode.Next = Tail;
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
                Console.Write(node.Data);
            }
            Console.WriteLine();
        }

        public T Dequeue()
        {
            if (count == 0)
            {
                throw new InvalidOperationException();
            }
            T output = Head.Data;
            Head = Head.Next;
            count--;
            return output;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int number = 0;
            Console.Write("Введите количество элементов очереди: ");
            int count = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("******Реализация очереди на массиве******");
            QueueOnArray<int> queue1 = new QueueOnArray<int>(count);
            Console.WriteLine("Помещение в очередь на массиве элементов:");
            for (int i = 0; i < count; i++)
            {
                number = rnd.Next(1, 25);
                Console.Write(number + " ");
                queue1.Add(number);
            }
            Console.WriteLine();
            Console.WriteLine("Элементы очереди на массиве: ");
            queue1.Print();
            Console.WriteLine("Извлечение элементов из очереди на массиве: ");
            while (!queue1.IsEmpty)
            {
                queue1.Delete();
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("******Реализация очереди на списке******");
            QueueOnList<int> queue2 = new QueueOnList<int>();
            Console.WriteLine("Помещение в очередь на списке элементов:");
            for (int i = 0; i < count; i++)
            {
                number = rnd.Next(1, 25);
                Console.Write(number + " ");
                queue2.Add(number);
            }
            Console.WriteLine();
            Console.WriteLine("Элементы очереди на списке: ");
            queue2.Print();
            Console.WriteLine("Извлечение элементов из очереди на списке: ");
            while (!queue2.IsEmpty)
            {
                int Item = queue2.Dequeue();
                Console.Write("Удален: " + Item + " ");
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
