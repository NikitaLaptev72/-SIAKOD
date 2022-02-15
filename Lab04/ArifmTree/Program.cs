using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace ArifmTree
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
        string[] character_set = { "+", "-", "/", "*" };

        public Node Root;

        public Tree()
        {
            Console.WriteLine();
            string text = File.ReadAllText("Выражение.txt", Encoding.GetEncoding(1251));
            string[] array = text.Split(' ').ToArray();
            Root = new Node();
            Node current = Root;

            //если прочитанный символ - цифра, то строится терминальный узел, иначе предполагается, что прочитана скобка (рекурсивно строится левое поддерево, корень, правое поддерево)
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
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
                        if (character_set.Contains(array[i]))
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
            Console.WriteLine();
            Console.WriteLine();
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

        Double Operator(string zn, double x, double y)
        {
            if (zn == "*")
            {
                return x * y;
            }
            else
            {
                if (zn == "/")
                {
                    return x / y;
                }
                else
                {
                    if (zn == "+")
                    {
                        return x + y;
                    }
                    else
                    {
                        return x - y;
                    }
                }
            }
        }

        public double Result(Node node)
        {
            if (node.Left == null || node.Right == null)
            {
                return node.Number;
            }
            double x = Result(node.Left);
            double y = Result(node.Right);
            return Operator(node.Sign, x, y);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Tree tree = new Tree();
            tree.Print();
            Console.WriteLine("Результат: " + tree.Result(tree.Root));
            Console.ReadLine();
        }
    }
}
