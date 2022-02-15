using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _3
{    
    class Program
    {
        public class Node
        {
            public int Data;
            public int Key;
            public Node next;
        }

        public static int Function(int param)
        {
            return param % 7;
        }

        public static Node[] Chain(int[] arr)
        {
            Node[] address = new Node[7];

            for (int i = 0; i < 7; i++)
            {
                int hash = Function(arr[i]);
                if (address[hash] == null)
                {
                    address[hash] = new Node
                    {
                        Data = arr[i],
                        Key = i
                    };
                }
                //else
                //{
                //    Node p = new Node
                //    {
                //        Data = arr[i],
                //        Key = i
                //    };
                //    Node node = address[hash];
                //    while (node.next != null)
                //    {
                //        node = node.next;
                //    }
                //    node.next = p;
                //}

            }
            return address;
        }

        static void Main(string[] args)
        {
            int[] array = new int[] { 1, 8, 27, 64, 125, 216, 343 };
            Node[] result1 = new Node[7];
            result1 = Chain(array);
            Console.WriteLine("Хеширование с цепочками:");
            Node node = null;
            foreach (var elem in result1)
            {
                if (elem != null)
                {
                    Console.Write("Ключ: " + elem.Key + " данные по ключу: ");
                    Console.Write(elem.Data + " ");
                    if (elem.next != null) node = elem.next;
                    while (node != null)
                    {
                        Console.Write(" -> " + node.Data + " ");
                        node = node.next;

                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
        }
    }
}
