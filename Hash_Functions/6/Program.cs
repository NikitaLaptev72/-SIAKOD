using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6
{
    class Program
    {
        public class Node
        {
            public int Data;
            public int Key;
        }

        public static Node[] Hashing(int[] keys, int m)
        {
            int M = m * 2;
            Node[] Hash_Addresses = new Node[M * 3];
            for (int i = 0; i < m; i++)
            {
                int hash = Function(keys[i]);

                Hash_Addresses[hash] = new Node
                {
                    Data = keys[i],
                    Key = hash
                };
            }
            return Hash_Addresses;
        }

        static int Function(int param)
        {
            int result = 0;
            int newparam = 0;
            while (param > 0)
            {
                newparam = param % 100;
                param = (param - newparam % 100) / 100;
                if (newparam % 10 < newparam / 10)
                {
                    newparam = (newparam % 10) * 10 + newparam / 10;
                }
                result += newparam;
            }
            return result;
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

        static void Main(string[] args)
        {
            int count = 100;
            int[] first = new int[count];
            first = CreationArray(first, count);
            Node[] ResultHash = new Node[count];
            int M = first.Count();
            ResultHash = Hashing(first, M);
            foreach (var element in ResultHash)
            {
                if (element != null)
                {
                    Console.WriteLine("Ключ: " + element.Key + " данные по ключу: " + element.Data);
                }
            }
            Console.WriteLine();
        }
    }
}
