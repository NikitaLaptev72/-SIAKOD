using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _4
{
    class Program
    {
        public class Node
        {
            public int Data;
            public int Key;
            public Node next;
        }
        
        public static Node[] Hashing_With_Chains(int[] keys, int M)
        {
            Node[] Hash_Addresses = new Node[M];
            for (int i = 0; i < M; i++)
            {
                int hash = Function(keys[i], M);
                if (Hash_Addresses[hash] == null)
                {
                    Hash_Addresses[hash] = new Node
                    {
                        Data = keys[i],
                        Key = hash
                    };
                }
                else
                {
                    Node newnode = new Node
                    {
                        Data = keys[i],
                        Key = hash
                    };
                    Node node = Hash_Addresses[hash];

                    while (node.next != null)
                    {
                        node = node.next;
                    }
                    node.next = newnode;
                }
            }
            return Hash_Addresses;
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
            return param = param % (M / 100);
        }

        static void Main(string[] args)
        {
            int count = 5000;
            int[] first = new int[count];
            first = CreationArray(first, count);
            Node[] ResultHash = new Node[count];
            int M = first.Count() ;
            ResultHash = Hashing_With_Chains(first, M);
            Find(ResultHash, count);
            Console.WriteLine();
            count = 10000;
            first = new int[count];
            first = CreationArray(first, count);
            ResultHash = new Node[count];
            M = first.Count();
            ResultHash = Hashing_With_Chains(first, M);
            Find(ResultHash, count);
            Console.WriteLine();
            count = 20000;
            first = new int[count];
            first = CreationArray(first, count);
            ResultHash = new Node[count];
            M = first.Count();
            ResultHash = Hashing_With_Chains(first, M);
            Find(ResultHash, count);
            Console.WriteLine();
        }

        static void Find(Node[] ResultHash, int count)
        {
            List<int> mylist = new List<int>();
            int count1 = 0;
            Node node = null;
            foreach (var element in ResultHash)
            {
                if (element != null)
                {
                    if (element.next != null)
                    {
                        node = element.next;
                    }
                    count1 = 0;
                    while (node != null)
                    {
                        count1++;
                        node = node.next;
                    }
                    mylist.Add(count1);
                    count1 = 0;
                }
            }
            Console.WriteLine("Максимальная длина списка для N = " + count + " = " + mylist.Max() + "\nМинимальная длина списка для N = " + count + " = " + mylist.Min());
        }
    }
}
