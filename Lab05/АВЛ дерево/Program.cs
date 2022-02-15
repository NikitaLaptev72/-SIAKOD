using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АВЛ_дерево
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nodes = { 15, 42, 23, 44, 8, 51, 93, 53, 41, 24, 54, 10, 11, 3, 42 };
            AVLTree tree = new AVLTree();
            for (int i = 0; i < nodes.Count(); i++)
            {
                tree.Add(nodes[i]);
            }
            Console.WriteLine("*********МЕНЮ*********");
            int menu = 1;
            while (menu != 0)
            {
                Console.WriteLine("1)Добавить элемент\n2)Удалить элемент\n3)Отобразить дерево\n4)Найти элемент\n0)Выход");
                Console.Write("Выберите действие: ");
                menu = Convert.ToInt32(Console.ReadLine());
                switch(menu)
                {
                    case (1):
                        {
                            Console.Clear();
                            Console.Write("Введите элемент для вставки:");
                            int el = Convert.ToInt32(Console.ReadLine());
                            tree.Add(el);
                            Console.WriteLine("Дерево после добавления:");
                            tree.Print();
                        }
                        break;
                    case (2):
                        {
                            Console.Clear();
                            Console.Write("Введите элемент для удаления:");
                            int el = Convert.ToInt32(Console.ReadLine());
                            tree.Delete(el);
                            Console.WriteLine("Дерево после удаления:");
                            tree.Print();
                        }
                        break;
                    case (3):
                        {
                            Console.Clear();
                            tree.Print();
                            Console.WriteLine();
                        }
                        break;
                    case (4):
                        {
                            Console.Clear();
                            Console.Write("Введите элемент для поиска:");
                            int el = Convert.ToInt32(Console.ReadLine());
                            tree.Find(el);
                            Console.WriteLine();
                        }
                        break;
                    default:
                        {
                            break;
                        }
                }
            }
        }
    }

    class AVLTree
    {
        //Класс узлов
        class Node
        {
            public int Value;
            public Node Left;
            public Node Right;

            public Node(int value)
            {
                Value = value;
            }
        }

        //Корень
        Node Root;

        //Конструктор по умолчанию
        public AVLTree()
        {

        }

        //Добавление элемента в дерево
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

        //Вставка элемента
        private Node Insert(Node current, Node newnode)
        {
            if (current == null)
            {
                current = newnode;
                return current;
            }
            else if (newnode.Value < current.Value)
            {
                current.Left = Insert(current.Left, newnode);
                current = Balance_Tree(current);
            }
            else if (newnode.Value >= current.Value)
            {
                current.Right = Insert(current.Right, newnode);
                current = Balance_Tree(current);
            }
            return current;
        }

        //Балансировка дерева
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


        private int Balance(Node current)
        {
            int left = Height(current.Left);
            int right = Height(current.Right);
            int b_factor = left - right;
            return b_factor;
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

        private int Max(int l, int r)
        {
            return l > r ? l : r;
        }

        //Удаление
        public void Delete(int target)
        {
            Root = Delete(Root, target);
        }

        //Удаление элемента
        private Node Delete(Node current, int target)
        {
            Node parent;
            if (current == null)
            { return null; }
            else
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
                else if (target > current.Value)
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
            return current;
        }

        //Поиск в дереве
        public void Find(int value)
        {
            if (Find(value, Root).Value == value)
            {
                Console.WriteLine("Элемент {0} найден в дереве!", value);
            }
            else
            {
                Console.WriteLine("Поиск не дал результатов!");
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
                    return Find(value, current.Left);
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
                    return Find(value, current.Right);
                }
            }

        }

        //Вывод дерева
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
                Console.WriteLine(current.Value);
                Print(current.Left, Indent + 1);
            }
        }


        


       
    }
}
