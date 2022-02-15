using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05
{
    public enum Node
    {
        Left,
        Right
    }

    public class BinaryTree
    {

        public int? Data
        {
            get;
            private set;
        }
        public BinaryTree Left
        {
            get;
            set;
        }
        public BinaryTree Right
        {
            get;
            set;
        }
        public BinaryTree Parent
        {
            get;
            set;
        }
        
        public void Insert(int data)
        {
            if (Data == null || Data == data)
            {
                Data = data;
                return;
            }
            if (Data > data)
            {
                if (Left == null)
                {
                    Left = new BinaryTree();
                }
                Insert(data, Left, this);
            }
            else
            {
                if (Right == null)
                {
                    Right = new BinaryTree();
                }
                Insert(data, Right, this);
            }
        }

        private void Insert(int data, BinaryTree node, BinaryTree parent)
        {

            if (node.Data == null || node.Data == data)
            {
                node.Data = data;
                node.Parent = parent;
                return;
            }
            if (node.Data > data)
            {
                if (node.Left == null)
                {
                    node.Left = new BinaryTree();
                }
                Insert(data, node.Left, node);
            }
            else
            {
                if (node.Right == null) node.Right = new BinaryTree();
                Insert(data, node.Right, node);
            }
        }

        private void Insert(BinaryTree data, BinaryTree node, BinaryTree parent)
        {
            if (node.Data == null || node.Data == data.Data)
            {
                node.Data = data.Data;
                node.Left = data.Left;
                node.Right = data.Right;
                node.Parent = parent;
                return;
            }
            if (node.Data > data.Data)
            {
                if (node.Left == null)
                {
                    node.Left = new BinaryTree();
                }
                Insert(data, node.Left, node);
            }
            else
            {
                if (node.Right == null)
                {
                    node.Right = new BinaryTree();
                }
                Insert(data, node.Right, node);
            }
        }

        private Node? MeForParent(BinaryTree node)
        {
            if (node.Parent == null)
            {
                return null;
            }
            if (node.Parent.Left == node)
            {
                return Node.Left;
            }
            if (node.Parent.Right == node)
            {
                return Node.Right;
            }
            return null;
        }

        public void Remove(BinaryTree node)
        {
            if (node == null) return;
            var me = MeForParent(node);
            //Если у узла нет дочерних элементов, его можно удалять
            if (node.Left == null && node.Right == null)
            {
                if (me == Node.Left)
                {
                    node.Parent.Left = null;
                }
                else
                {
                    node.Parent.Right = null;
                }
                return;
            }
            //Если нет левого дочернего, то правый дочерний становится на место удаляемого
            if (node.Left == null)
            {
                if (me == Node.Left)
                {
                    node.Parent.Left = node.Right;
                }
                else
                {
                    node.Parent.Right = node.Right;
                }

                node.Right.Parent = node.Parent;
                return;
            }
            //Если нет правого дочернего, то левый дочерний становится на место удаляемого
            if (node.Right == null)
            {
                if (me == Node.Left)
                {
                    node.Parent.Left = node.Left;
                }
                else
                {
                    node.Parent.Right = node.Left;
                }

                node.Left.Parent = node.Parent;
                return;
            }

            //Если присутствуют оба дочерних узла
            //то правый ставим на место удаляемого
            //а левый вставляем в правый

            if (me == Node.Left)
            {
                node.Parent.Left = node.Right;
            }
            if (me == Node.Right)
            {
                node.Parent.Right = node.Right;
            }
            if (me == null)
            {
                var bufLeft = node.Left;
                var bufRightLeft = node.Right.Left;
                var bufRightRight = node.Right.Right;
                node.Data = node.Right.Data;
                node.Right = bufRightRight;
                node.Left = bufRightLeft;
                Insert(bufLeft, node, node);
            }
            else
            {
                node.Right.Parent = node.Parent;
                Insert(node.Left, node.Right, node.Right);
            }
        }

        public void Remove(long data)
        {
            var removeNode = Find(data);
            if (removeNode != null)
            {
                Remove(removeNode);
            }
        }

        public BinaryTree Find(long data)
        {
            if (Data == data)
            {
                return this;
            }
            if (Data > data)
            {
                return Find(data, Left);
            }
            return Find(data, Right);
        }

        public BinaryTree Find(long data, BinaryTree node)
        {
            if (node == null)
            {
                return null;
            }
            if (node.Data == data)
            {
                return node;
            }
            if (node.Data > data)
            {
                return Find(data, node.Left);
            }
            return Find(data, node.Right);
        }

        public long CountElements()
        {
            return CountElements(this);
        }

        private long CountElements(BinaryTree node)
        {
            long count = 1;
            if (node.Right != null)
            {
                count += CountElements(node.Right);
            }
            if (node.Left != null)
            {
                count += CountElements(node.Left);
            }
            return count;
        }

        public void Print(BinaryTree node, int k)
        {
            if (node != null)
            {
                Print(node.Right, k + 1);
                for (int i = 1; i <= k; i++)
                {
                    Console.Write("    ");
                }
                Console.WriteLine(node.Data);
                Print(node.Left, k + 1);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var tree = new BinaryTree();
            int count = 15;
            int[] nodes = { 33, 98, 38, 26, 22, 82, 23, 16, 73, 77, 74, 26, 84, 75, 35 };
            for (int i = 0; i < count; i++)
            {
                tree.Insert(nodes[i]);
            }
            Console.WriteLine("Исходное дерево:");
            tree.Print(tree, 0);
            for (int i = 0; i < 7; i++)
            {
                tree.Remove(nodes[i]);
                Console.WriteLine("Дерево после удаления:");
                tree.Print(tree, 0);
            }
        }
    }
}
