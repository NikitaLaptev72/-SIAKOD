using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05
{   
    public class BinaryTree
    {
        public BinaryTree Parent;
        public BinaryTree Left;
        public BinaryTree Right;
        public int Value;
        
        //Создание дерева
        public BinaryTree Creation(int value)
        {
            BinaryTree MyTree = new BinaryTree
            {
                Left = null,
                Right = null,
                Value = value
            };
            return MyTree;
        }       

        //Добавление элемента в дерево
        public BinaryTree Add(BinaryTree MyTree, int value)
        {
            if (MyTree == null)
            {
                MyTree = new BinaryTree
                {
                    Value = value
                };
            }

            if (value > MyTree.Value)
            {
                MyTree.Right = Add(MyTree.Right, value);
                MyTree.Right.Parent = MyTree;
                return MyTree;
            }

            if (value < MyTree.Value)
            {
                MyTree.Left = Add(MyTree.Left, value);
                MyTree.Left.Parent = MyTree;
                return MyTree;
            }
            return MyTree;
        }

        public void SwapNodes(ref int L, ref int F)
        {
            int t = L;
            L = F;
            F = t;
        }

        public void Print(BinaryTree MyTree)
        {
            Print(MyTree.Parent, 0);
        }

        public void Print(BinaryTree MyTree, int Indent)
        {
            if (MyTree != null)
            {
                Print(MyTree.Right, Indent + 1);
                for (int i = 1; i <= Indent; i++)
                {
                    Console.Write("  ");
                }
                Console.WriteLine(MyTree.Value);
                Print(MyTree.Left, Indent + 1);
            }
        }

        public BinaryTree Find(BinaryTree MyTree, int value)
        {
            if (MyTree != null)
            {
                //Если найден элемент
                if (MyTree.Value == value)
                {
                    return MyTree;
                }
                else
                {
                    if (MyTree.Value > value)
                    {
                        //Идем по левому
                        return Find(MyTree.Left, value);
                    }
                    else
                    {
                        //Идем по правому
                        return Find(MyTree.Right, value);
                    }
                }
            }
            return null;
        }

        public void DelNode(BinaryTree MyTree)
        {
            //Если у узла нет дочерних элементов, его можно удалять
            if ((MyTree.Left == null) && (MyTree.Right == null))
            {
                if (MyTree.Parent.Right != null)
                {
                    MyTree.Parent.Right = null;
                }
                else
                {
                    MyTree.Parent.Left = null;
                }
            }
            else
            {
                //Если один дочерний
                if ((MyTree.Left != null && MyTree.Right == null) || (MyTree.Right != null && MyTree.Left == null))
                {
                    //Если нет правого дочернего, то левый дочерний становится на место удаляемого
                    if (MyTree.Right == null)
                    {
                        if (MyTree.Parent.Left == MyTree)
                        {
                            MyTree.Parent.Left = MyTree.Left;
                        }
                        else
                        {
                            MyTree.Parent.Right = MyTree.Left;
                        }
                    }
                    //Если нет левого дочернего, то правый дочерний становится на место удаляемого
                    else
                    {
                        if (MyTree.Parent.Left == MyTree)
                        {
                            MyTree.Parent.Left = MyTree.Right;
                        }
                        else
                        {
                            MyTree.Parent.Right = MyTree.Right;
                        }
                    }
                }
                else
                {
                    //Если два дочерних
                    //Если присутствуют оба дочерних узла, то правый ставим на место удаляемого, а левый вставляем в правый
                    BinaryTree Node = new BinaryTree();
                    Node = MyTree.Left;
                    while (Node.Right != null)
                    {
                        Node = Node.Right;
                    }
                    SwapNodes(ref Node.Value, ref MyTree.Value);
                    if (Node.Left != null)
                    {
                        Node.Parent.Right = Node.Left;
                    }
                    else
                    {
                        if (Node.Parent.Left == Node)
                        {
                            Node.Parent.Left = null;
                        }
                        else
                        {
                            Node.Parent.Right = null;
                        }
                    }
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree MyTree = new BinaryTree();
            MyTree = MyTree.Creation(15);
            int[] nodes = { 42, 23, 44, 8, 51, 93, 53, 41, 24, 54, 10, 11, 3, 42 };
            for (int i = 0; i < nodes.Count(); i++)
            {
                MyTree.Add(MyTree, nodes[i]);
            }
            Console.WriteLine("Исходное дерево:");
            MyTree.Print(MyTree, 0);
            Console.WriteLine("Удаляемый элемент: " + 15);
            MyTree.DelNode(MyTree.Find(MyTree, 15));
            Console.WriteLine("Дерево после удаления 1 элемента:");
            Console.WriteLine();
            MyTree.Print(MyTree, 0);
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine("Удаляемый элемент: " + nodes[i]);
                MyTree.DelNode(MyTree.Find(MyTree, nodes[i]));
                Console.WriteLine("Дерево после удаления " + (i+1) + " элемента:");
                Console.WriteLine();
                MyTree.Print(MyTree, 0);
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
