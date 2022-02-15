using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Changing
{
    class Program
    {
        public class Node
        {
            private Node left, right;
            public double Number;
            public Node Root;
            public bool valid;
            string sign;

            double x;
            public string Sign
            {
                get
                {
                    return sign;
                }
                set
                {
                    sign = value;
                    if (double.TryParse(sign, out x))//если число, то запоминается значение
                    {
                        valid = true;
                        Number = x;
                    }

                }
            }

            public Node Left
            {
                get
                {
                    return left;
                }
                set
                {
                    value.Root = this;
                    left = value;
                }
            }

            public Node Right
            {
                get
                {
                    return right;
                }
                set
                {
                    value.Root = this;
                    right = value;
                }
            }
        }

        public class Tree
        {
            string[] symbols = { "+", "-", "/", "*" };

            public Node Root;

            public Tree()
            {
                string text = File.ReadAllText("Выражение.txt", Encoding.GetEncoding(1251));
                string[] array = text.Split(' ').ToArray();
                Root = new Node();
                Node current = Root;
                try
                {
                    //если прочитанный символ - цифра, то строится терминальный узел, иначе предполагается, что прочитана скобка (рекурсивно строится левое поддерево, корень, правое поддерево)
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (array[i] == "(")
                        {
                            current.Left = new Node();
                            current = current.Left;
                        }
                        else
                        {
                            if (array[i] == ")")
                            {
                                if (current.Root == null)
                                {
                                    current.Root = new Node();
                                    Root = current.Root;
                                    Root.Left = current;
                                }
                                current = current.Root;
                            }
                            else
                            {
                                if (symbols.Contains(array[i]))
                                {
                                    current.Sign = array[i];
                                    current.Right = new Node();
                                    current = current.Right;
                                }
                                else
                                {
                                    current.Sign = array[i];
                                    if (current.Root == null)
                                    {
                                        current.Root = new Node();
                                        Root = current.Root;
                                        Root.Right = current;
                                    }
                                    current = current.Root;
                                }
                            }
                        }
                    }
                }
                catch { };

            }
            public void Print()
            {
                Print(Root, 0);
            }

            void Print(Node node, int l)
            {
                if (node != null)
                {
                    Print(node.Right, l + 1);
                    for (int i = 1; i <= l; i++)
                    {
                        Console.Write("  ");
                    }
                    Console.WriteLine(node.Sign);
                    Print(node.Left, l + 1);
                }
            }

            void Change(Node node, Node nods)
            {
                //вставка +, построение левого поддерева с *, затем правого с *
                node.Sign = nods.Sign;
                Node left = new Node
                {
                    Left = node.Right,
                    Right = node.Left.Right
                };

                Node right = new Node
                {
                    Sign = left.Sign = "*",
                    Left = node.Right,
                    Right = node.Left.Left
                };

                node.Left = left;
                node.Right = right;
            }

            public void Choosing(Node node)
            {
                //выбор типа выражения (слева -, справа буква; слева +, справа буква; слева буква, справа -; слева буква, справа +)
                if (node != null)
                {
                    if (node.Sign == "*")
                    {
                        if (node.Left != null && node.Right != null)
                        {
                            if ((node.Left.Sign == "+" && !symbols.Contains(node.Right.Sign)))
                            {
                                Change(node, node.Left);
                            }
                            if ((node.Left.Sign == "-" && !symbols.Contains(node.Right.Sign)))
                            {
                                Change(node, node.Left);
                            }
                            if ((node.Right.Sign == "+" && !symbols.Contains(node.Left.Sign)))
                            {
                                Change(node, node.Right);
                            }
                            if ((node.Right.Sign == "-" && !symbols.Contains(node.Left.Sign)))
                            {
                                Change(node, node.Right);
                            }
                        }
                    }
                    Choosing(node.Left);
                    Choosing(node.Right);
                }
            }            
        }

        static void Main(string[] args)
        {
            Tree tree = new Tree();
            Console.WriteLine("Дерево первоначально: ");
            tree.Print();
            tree.Choosing(tree.Root);
            Console.WriteLine("Дерево после преобразования: ");
            tree.Print();
            Console.ReadLine();
        }
    }
}
