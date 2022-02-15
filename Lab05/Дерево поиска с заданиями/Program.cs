using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Дерево_поиска_с_заданиями
{
    class Node
    {
        public int Value;
        public Node Left;
        public Node Right;
        public int count = 1;
        public int Count = 0;

        public Node(int value)
        {
            Value = value;
        }
    }

    class AVLTree
    {
        public Node Root;

        public void Infix(Node root)
        {
            int[] nodes = new int[root.Count];
            var stack = new Stack<Node>();
            Node current = root;
            bool check = true;
            using (StreamWriter writer = new StreamWriter("Nodes.txt"))
            {
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
                            if (current.count > 1)
                            {
                                int helpcount = current.count;
                                while (helpcount > 0)
                                {
                                    writer.Write(current.Value + " ");
                                    helpcount--;
                                }
                            }
                            else
                            {
                                writer.Write(current.Value + " ");
                            }
                            current = current.Right;
                        }
                    }
                }
            }
            Console.WriteLine("Узлы записаны!");
            Console.WriteLine();
        }

        public AVLTree()
        {

        }

        public void Add(int value)
        {
            Node NewNode = new Node(value);

            if (Root == null)
            {
                Root = NewNode;
            }
            else
            {
                Root = Insert(Root, NewNode);
            }
        }

        private Node Insert(Node current, Node newnode)
        {
            if (current == null)
            {
                current = newnode;
                return current;
            }
            else
            {
                if (newnode.Value < current.Value)
                {
                    current.Left = Insert(current.Left, newnode);
                    current = Balance_Tree(current);
                }
                else
                {
                    if (newnode.Value > current.Value)
                    {
                        current.Right = Insert(current.Right, newnode);
                        current = Balance_Tree(current);
                    }
                    else
                    {
                        if (newnode.Value == current.Value)
                        {
                            current.count++;
                        }
                    }
                }
            }
            current.Count++;
            return current;
        }

        private Node Balance_Tree(Node current)
        {
            int b_factor = Balance(current);
            if (b_factor > 1)
            {
                if (Balance(current.Left) > 0)
                {
                    current = RotateLL(current);
                }
                else
                {
                    current = RotateLR(current);
                }
            }
            else if (b_factor < -1)
            {
                if (Balance(current.Right) > 0)
                {
                    current = RotateRL(current);
                }
                else
                {
                    current = RotateRR(current);
                }
            }
            return current;
        }

        public void Delete(int target)
        {
            Root = Delete(Root, target);
        }

        private Node Delete(Node current, int target)
        {
            Node parent;
            if (current == null)
            {
                return null;
            }
            else
            {
                if (current.count == 1)
                {
                    //идем по левому поддереву
                    if (target < current.Value)
                    {
                        current.Left = Delete(current.Left, target);
                        if (Balance(current) == -2)
                        {
                            if (Balance(current.Right) <= 0)
                            {
                                current = RotateRR(current);
                            }
                            else
                            {
                                current = RotateRL(current);
                            }
                        }
                    }
                    //идем по правому поддереву
                    else
                    {
                        if (target > current.Value)
                        {
                            current.Right = Delete(current.Right, target);
                            if (Balance(current) == 2)
                            {
                                if (Balance(current.Left) >= 0)
                                {
                                    current = RotateLL(current);
                                }
                                else
                                {
                                    current = RotateLR(current);
                                }
                            }
                        }
                        //если элемент найден
                        else
                        {
                            if (current.Right != null)
                            {
                                parent = current.Right;
                                while (parent.Left != null)
                                {
                                    parent = parent.Left;
                                }
                                current.Value = parent.Value;
                                current.Right = Delete(current.Right, parent.Value);
                                if (Balance(current) == 2)
                                {
                                    if (Balance(current.Left) >= 0)
                                    {
                                        current = RotateLL(current);
                                    }
                                    else
                                    {
                                        current = RotateLR(current);
                                    }
                                }
                            }
                            else
                            {   //if (current.left != null)
                                return current.Left;
                            }
                        }
                    }
                }
                else
                {
                    current.count--;
                }
            }
            return current;
        }

        public bool FindForDel(int value)
        {
            if (Find(value, Root).Value == value)
            {
                return true;
            }
            else
            {
                if (Find(value, Root).Value == Root.Value)
                {
                    return false;
                }
                return true;
            }
        }

        public void Find(int value)
        {
            if (Find(value, Root).Value == value)
            {
                Console.WriteLine("Элемент {0} найден в дереве!", value);
            }
            else
            {
                if (Find(value, Root).Value == Root.Value)
                {
                    Console.WriteLine("Поиск не дал результатов!");
                }
            }
        }

        private Node Find(int value, Node current)
        {
            if (value < current.Value)
            {
                if (value == current.Value)
                {
                    return current;
                }
                else
                {
                    if (current.Right != null)
                    {
                        return Find(value, current.Left);
                    }
                    else
                    {
                        return Root;
                    }
                }
            }
            else
            {
                if (value == current.Value)
                {
                    return current;
                }
                else
                {
                    if (current.Right != null)
                    {
                        return Find(value, current.Right);
                    }
                    else
                    {
                        return Root;
                    }
                }
            }
        }

        public void Print()
        {
            if (Root == null)
            {
                Console.WriteLine("В дереве нет элементов!");
                return;
            }
            Print(Root, 0);
            Console.WriteLine();
        }

        private void Print(Node current, int Indent)
        {
            if (current != null)
            {
                Print(current.Right, Indent + 1);
                for (int i = 0; i < Indent; i++)
                {
                    Console.Write("   ");
                }
                Console.WriteLine(current.Value.ToString() + " {" + current.count.ToString() + "}");
                Print(current.Left, Indent + 1);
            }
        }

        private int Max(int l, int r)
        {
            return l > r ? l : r;
        }

        private int Height(Node current)
        {
            int height = 0;
            if (current != null)
            {
                int left = Height(current.Left);
                int right = Height(current.Right);
                int m = Max(left, right);
                height = m + 1;
            }
            return height;
        }

        private int Balance(Node current)
        {
            int left = Height(current.Left);
            int right = Height(current.Right);
            int b_factor = left - right;
            return b_factor;
        }

        private Node RotateRR(Node parent)
        {
            Node helpnode = parent.Right;
            parent.Right = helpnode.Left;
            helpnode.Left = parent;
            return helpnode;
        }

        private Node RotateLL(Node parent)
        {
            Node helpnode = parent.Left;
            parent.Left = helpnode.Right;
            helpnode.Right = parent;
            return helpnode;
        }

        private Node RotateLR(Node parent)
        {
            Node helpnode = parent.Left;
            parent.Left = RotateRR(helpnode);
            return RotateLL(parent);
        }

        private Node RotateRL(Node parent)
        {
            Node helpnode = parent.Right;
            parent.Right = RotateLL(helpnode);
            return RotateRR(parent);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string text = "";
            //Чтение файла
            using (StreamReader reader = new StreamReader("Nodes.txt"))
            {
                while (true)
                {
                    string temp = reader.ReadLine();
                    if (temp == null)
                    {
                        break;
                    }
                    text += temp;
                }
            }
            string[] input = new string[text.Length];
            input = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] nodes = new int[input.Length];
            //Разбиение на узлы
            for (int i = 0; i < input.Length; i++)
            {
                nodes[i] = Convert.ToInt32(input[i]);
            }
            AVLTree tree = new AVLTree();
            for (int i = 0; i < nodes.Count(); i++)
            {
                tree.Add(nodes[i]);
            }
            int menu = 1;
            while (menu != 0)
            {
                Console.WriteLine("1)Добавить элемент \n2)Найти элемент \n3)Удалить элемент \n4)Записать узлы в файл \n5)Отобразить дерево \n0)Выход");
                menu = Convert.ToInt32(Console.ReadLine());
                switch (menu)
                {
                    case (1):
                        {
                            Console.Write("Введите элемент для добавления: ");
                            int node = Convert.ToInt32(Console.ReadLine());
                            tree.Add(node);
                            Console.WriteLine();
                        }
                        break;
                    case (2):
                        {
                            Console.Write("Введите элемент для поиска: ");
                            int request = Convert.ToInt32(Console.ReadLine());
                            tree.Find(request);
                            Console.WriteLine("Узел добавлен");
                            Console.WriteLine();
                        }
                        break;
                    case (3):
                        {
                            Console.Write("Введите элемент для удаления: ");
                            int del = Convert.ToInt32(Console.ReadLine());
                            if (tree.FindForDel(del) == true)
                            {
                                tree.Delete(del);
                                Console.WriteLine("Элемент удален!");
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.WriteLine("Данного узла нет в дереве!");
                                Console.WriteLine();
                            }
                        }
                        break;
                    case (4):
                        {
                            tree.Infix(tree.Root);
                        }
                        break;
                    case (5):
                        {
                            Console.WriteLine("Дерево:");
                            tree.Print();
                            Console.WriteLine();
                        }
                        break;
                    default: Console.WriteLine("Проверьте введенные данные!"); break;
                }
            }
        }
    }
}
