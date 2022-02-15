using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5
{
    class Program
    {
        public class Node
        {
            public int Data;
            public int Key;
            public Node next;
        }

        static int[] CreationArray(int[] keys, int count)
        {
            Random rnd = new Random();
            keys = new int[count];
            for (int i = 0; i < keys.Count(); i++)
            {
                keys[i] = rnd.Next(1, int.MaxValue);
            }
            return keys;
        }

        static int Function(int param, int M)
        {
            return param = param % (M / 5);
        }

        static List<int> mylist = new List<int>();

        public static Node[] Linear_Hashing(int[] keys, int M)
        {
            int CountTry = 0;
            Node[] address = new Node[M * 2];

            for (int i = 0; i < M; i++)
            {
                int hash = Function(keys[i], M);
                if (address[hash] == null)
                {
                    address[hash] = new Node
                    {
                        Data = keys[i],
                        Key = hash
                    };
                }
                else
                {
                    while (address[hash % address.Length] != null)
                    {
                        CountTry++;
                        hash++;
                    }
                    mylist.Add(CountTry);
                    CountTry = 0;
                    address[hash] = new Node
                    {
                        Data = keys[i],
                        Key = hash
                    };
                }

            }
            return address;
        }

        static void Average(int count)
        {
            Console.WriteLine("Среднее количество попыток для таблицы размером N = " + count + " = " + (int)mylist.Average());
            mylist.Clear();
        }

        static void Main(string[] args)
        {
            int count = 5000;
            int[] first = new int[count];
            first = CreationArray(first, count);
            Node[] ResultHash = new Node[count];
            int M = first.Count();
            ResultHash = Linear_Hashing(first, M/2);
            Average(count);
            Console.WriteLine();
            count = 10000;
            first = new int[count];
            first = CreationArray(first, count);
            ResultHash = new Node[count];
            M = first.Count();
            ResultHash = Linear_Hashing(first, M / 2);
            Average(count);
            Console.WriteLine();
            count = 20000;
            first = new int[count];
            first = CreationArray(first, count);
            ResultHash = new Node[count];
            M = first.Count();
            ResultHash = Linear_Hashing(first, M / 2);
            Average(count);
            Console.WriteLine();
        }
    }
}
