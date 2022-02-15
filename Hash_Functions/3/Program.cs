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

        public static Node[] Linear_Hashing(int[] keys, int M)
        {
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
                        hash++;
                    }
                    address[hash] = new Node
                    {
                        Data = keys[i],
                        Key = hash
                    };
                }

            }
            return address;
        }

        public static Node[] Quadratic_Hashing(int[] keys, int M)
        {
            Node[] address = new Node[M * M];
            for (int i = 0; i < M; i++)
            {
                int k = 0;
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
                        k++;
                        hash += k * k;

                    }
                    address[hash] = new Node
                    {
                        Data = keys[i],
                        Key = hash
                    };
                }
            }            
            return address;
        }

        public static Node[] DoubleOpen(int[] keys, int M)
        {
            Node[] address = new Node[M * M];
            for (int i = 0; i < M; i++)
            {
                int k = 0;
                int hash = Function(keys[i], M);
                int hash2 = 1 + keys[i] % (M - 2);
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
                        k++;
                        hash += k * hash2;

                    }
                    address[hash] = new Node
                    {
                        Data = keys[i],
                        Key = hash
                    };
                }
            }
            return address;
        }

        static int Function(int param, int M)
        {
            return param = param % M;
        }

        static int Function2(int param, int M)
        {
            return 1 + param % (M - 2);
        }

        static void Main(string[] args)
        {
            int[] keys = { 1, 8, 27, 64, 125, 216, 343 };
            int M = keys.Count();
            Node node = null;
            int menu = 1;
            while (menu != 0)
            {
                Console.WriteLine("*************МЕНЮ*************");
                Console.WriteLine("1)Хеширование с цепочками \n2)Хеширование с открытой адресацией (линейное) \n3)Хеширование с открытой адресацией (квадратичное) \n4)Двойное хеширование \n0)Выход");
                Console.WriteLine("******************************");
                Console.Write("Выберите пункт: ");
                menu = Convert.ToInt32(Console.ReadLine());
                switch (menu)
                {
                    case (1):
                        {
                            Console.Clear();
                            Node[] ResultHash = new Node[M];
                            ResultHash = Hashing_With_Chains(keys, M);
                            foreach (var element in ResultHash)
                            {
                                if (element != null)
                                {
                                    Console.Write("Ключ: " + element.Key + " данные по ключу: " + element.Data);
                                    if (element.next != null)
                                    {
                                        node = element.next;
                                    }
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
                        break;
                    case (2):
                        {
                            Console.Clear();
                            Node[] ResultHash = new Node[M];
                            ResultHash = Linear_Hashing(keys, M);
                            foreach (var element in ResultHash)
                            {
                                if (element != null)
                                {
                                    Console.Write("Ключ: " + element.Key + " данные по ключу: " + element.Data + "\n");
                                }
                            }
                            Console.WriteLine();
                        }
                        break;
                    case (3):
                        {
                            Console.Clear();
                            foreach (var element in Quadratic_Hashing(keys, M))
                            {
                                if (element != null)
                                {
                                    Console.Write("Ключ: " + element.Key + " данные по ключу: " + element.Data + "\n");
                                }
                            }
                            Console.WriteLine();
                        }
                        break;
                    case (4):
                        {
                            Console.Clear();
                            foreach (var element in DoubleOpen(keys, M))
                            {
                                if (element != null)
                                {
                                    Console.Write("Ключ: " + element.Key + " данные по ключу: " + element.Data + "\n");
                                }
                            }
                            Console.WriteLine();
                        }
                        break;
                    case (0):
                        {
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Неверные данные!");
                        }
                        break;
                }
            }
            
        }
    }
}
