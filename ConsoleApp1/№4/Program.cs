using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    public class StackOnArray<T>
    {
        private T[] items;
        private int count;

        public StackOnArray(int length)
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
                throw new InvalidOperationException("Переполнение стека");
            }
            items[count++] = item;
        }
        
        public T Delete()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Стек пуст");
            }
            T item = items[--count];
            items[count] = default(T);//определит значение T(0 или null)
            return item;
        }

        public void Print()
        {
            int c = count;
            if (IsEmpty)
            {
                throw new InvalidOperationException("Стек пуст");
            }
            for (int i =0; i < count; i ++)
            {
                Console.Write(items[--c] + " ");
            }
        }
    }

    class StackOnList<T>
    {
        public class Node
        {
            public T Value;
            public Node Next;
        }

        public Node First;

        public void AddFirst(T value)
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
                throw new InvalidOperationException("Стек пуст");
            }
            Console.Write(First.Value + " ");
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
    }

    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int number = 0;
            Console.Write("Введите количество элементов стека: ");
            int count = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("******Реализация стека на массиве******");
            StackOnArray<int> stack1 = new StackOnArray<int>(count);
            Console.WriteLine("Помещение в стек на массиве элементов:");
            for (int i = 0; i < count; i++)
            {
                number = rnd.Next(1, 25);
                Console.Write(number + " ");
                stack1.Add(number);
            }
            Console.WriteLine();
            Console.WriteLine("Элементы стека на массиве: ");
            stack1.Print();
            Console.WriteLine();
            Console.WriteLine("Извлечение элементов из стека на массиве:");
            while (!stack1.IsEmpty)
            {
                Console.Write(stack1.Delete() + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("******Реализация стека на списке******");
            StackOnList<int> stack2 = new StackOnList<int>();
            Console.WriteLine("Помещение в стек на списке элементов:");
            for (int i = 0; i < count; i++)
            {
                number = rnd.Next(1, 25);
                Console.Write(number + " ");
                stack2.AddFirst(number);
            }
            Console.WriteLine();
            Console.WriteLine("Элементы стека на списке: ");
            stack2.Print();
            Console.WriteLine("Извлечение элементов из стека на списке");
            int n = count;
            while(n != 0)
            {
                stack2.DeleteFirst();
                n--;
            }
            stack2.Print();
            Console.ReadKey();
        }
    }
}
