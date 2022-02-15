using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace num2
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
            Node[] Hash_Addresses = new Node[M];
            for (int i = 0; i < m; i++)
            {
                int hash = Function(keys[i], M);

                Hash_Addresses[hash] = new Node
                {
                    Data = keys[i],
                    Key = hash
                };
            }
            return Hash_Addresses;
        }

        static int Function(int param, int M)
        {
            return param = Math.Abs(Convert.ToInt32((M + 2) * (param * 0.618 - Convert.ToInt32(param * 0.618))));
        }

        static void Main(string[] args)
        {
            string[] keys = { "Иван", "Пётр", "Варвара", "Александр", "Анна", "Алла" };
            int[] keys1 = new int[keys.Count()];
            Console.WriteLine("Данные преобразованы в следующем виде:");
            for (int i = 0; i < keys.Count(); i++)
            {
                Console.Write(keys[i] + " - ");
                for (int j = 0; j < keys[i].Count(); j++)
                {
                    keys1[i] += Convert.ToInt32(keys[i][j]);
                }
                Console.Write(keys1[i]);
                Console.WriteLine();
            }
            Console.WriteLine();
            int M = keys1.Count();
            Node[] ResultHash = new Node[M];
            ResultHash = Hashing(keys1, M);

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
