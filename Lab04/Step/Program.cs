using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step
{
    class Program
    {
        static void Main(string[] args)
        {
            int ch = 1;
            MyTree tree = new MyTree();
            tree.Initial();
            tree.Print();
            while (ch != 0)
            {
                Console.WriteLine(" 1) Префиксный обход\n 2) Инфиксный обход\n 3) Постфиксный обход\n 4) Поуровневый обход\n 0) Выход из программы");
                ch = Convert.ToInt32(Console.ReadLine());
                switch (ch)
                {
                    case (1): Console.WriteLine(); tree.Prefix(tree.Root); Console.WriteLine(); break;
                    case (2): Console.WriteLine(); tree.Infix(tree.Root); Console.WriteLine(); break;
                    case (3): Console.WriteLine(); tree.Postfix(tree.Root); Console.WriteLine(); break;
                    case (4): Console.WriteLine(); foreach (var item in tree.Levels()) Console.Write(item.Value + " "); Console.WriteLine(); break;
                    case (0): break;
                    default: Console.WriteLine(); Console.WriteLine("Неверные данные!"); Console.WriteLine(); break;
                }
            }
        }
    }

    public class Node
    {
        public string Value;
        public int Level;
        public Node Right;
        public Node Left;
    }

    public class MyTree
    {
        public Node Root;
        public string[] array;
        int Index;

        public MyTree()
        {
            Root = null;
        }

        public void Initial()
        {
            array = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15" };
            int N = array.Length;
            Index = 0;
            Root = new Node();
            Building(N, Root);
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
                Console.WriteLine(node.Value);
                Print(node.Left, l + 1);
            }
        }

        void Building(int N, Node node)
        {
            if (N != 0)
            {
                int nl = N / 2;//количество узлов слева
                int nr = N - nl - 1;//количество узлов справа
                node.Value = array[Index++];
                if (nl != 0)
                {
                    node.Left = new Node();
                    Building(nl, node.Left);
                }
                if (nr != 0)
                {
                    node.Right = new Node();
                    Building(nr, node.Right);
                }
            }
        }

        public void Prefix(Node root)
        {
            var stack = new Stack<Node>();
            Node current = root;
            bool check = true;
            while (check)
            {
                if (current != null)
                {
                    Console.Write(current.Value + " ");
                    stack.Push(current);
                    current = current.Left;
                }
                else
                {
                    if (stack.Count == 0)
                    {
                        check = false;
                    }
                    else
                    {
                        current = stack.Pop();
                        current = current.Right;
                    }
                }
            }
            Console.WriteLine();
        }

        public void Infix(Node root)
        {
            var stack = new Stack<Node>();
            Node current = root;
            bool check = true;
            while (check)
            {
                if (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }
                else
                {
                    if (stack.Count == 0)
                    {
                        check = false;
                    }
                    else
                    {
                        current = stack.Pop();
                        Console.Write(current.Value + " ");
                        current = current.Right;
                    }
                }
            }
            Console.WriteLine();
        }

        public void Postfix(Node root)
        {
            var stack = new Stack<Node>();
            Node current = root;
            Node temp = null;
            Node insert = null;
            bool check = true;
            while (check)
            {
                if (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }
                else
                {
                    if (stack.Count == 0)
                    {
                        check = false;
                    }
                    else
                    {
                        insert = stack.Peek();
                        if (insert.Right != null && temp != insert.Right)
                        {
                            current = insert.Right;
                        }
                        else
                        {
                            stack.Pop();
                            Console.Write(insert.Value + " ");
                            temp = insert;
                        }
                    }
                }
            }
            Console.WriteLine();
        }

        public IEnumerable<Node> Levels()
        {
            if (Root == null)
            {
                yield break;//для каждой итерации
            }

            var queue = new Queue<Node>();
            queue.Enqueue(Root);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                yield return node;
                if (node.Left != null)
                {
                    queue.Enqueue(node.Left);
                }
                if (node.Right != null)
                {
                    queue.Enqueue(node.Right);
                }
            }
        }
    }
}
