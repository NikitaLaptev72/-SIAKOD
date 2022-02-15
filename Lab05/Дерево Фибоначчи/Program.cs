using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Дерево_Фибоначчи
{
    public class FibonacciTree
    {
        public int Height;
        public int Value;
        public FibonacciTree Left;
        public FibonacciTree Right;
        public FibonacciTree Parent;
        public FibonacciTree BuildTree(int k)
        {
            if (k == -1)
                return null;
            else
            if (k == 0)
            {
                FibonacciTree tree = new FibonacciTree
                {
                    Value = 1
                };
                return tree;
            }
            else
                if (k == 1)
            {
                FibonacciTree tree = new FibonacciTree
                {
                    Value = 2,
                    Left = BuildTree(k - 1)
                };
                return tree;
            }
            else
            {
                FibonacciTree tree = new FibonacciTree
                {
                    Left = BuildTree(k - 1)
                };
                tree.Value = tree.Left.Value + tree.Left.Left.Value;
                FibonacciTree rightTree = new FibonacciTree
                {
                    Value = tree.Value + tree.Left.Left.Value
                };
                tree.Right = rightTree;
                BuildRightSubTree(ref rightTree, ref tree.Left.Left, tree.Value);
                return tree;
            }
        }
        public void BuildRightSubTree(ref FibonacciTree Tree, ref FibonacciTree currentTree, int value)
        {
            if (currentTree.Left != null)
            {
                FibonacciTree LeftTree = new FibonacciTree
                {
                    Value = currentTree.Left.Value + value
                };
                Tree.Left = LeftTree;
                BuildRightSubTree(ref Tree.Left, ref currentTree.Left, value);
            }
            if (currentTree.Right != null)
            {
                FibonacciTree rightTree = new FibonacciTree
                {
                    Value = currentTree.Right.Value + value
                };
                Tree.Right = rightTree;
                BuildRightSubTree(ref Tree.Right, ref currentTree.Right, value);
            }
        }
        public void SetParams(ref FibonacciTree currentTree)
        {
            if (currentTree.Left != null)
            {
                currentTree.Left.Height = currentTree.Height + 1;
                currentTree.Left.Parent = currentTree;
                SetParams(ref currentTree.Left);
            }
            if (currentTree.Right != null)
            {
                currentTree.Right.Height = currentTree.Height + 1;
                currentTree.Right.Parent = currentTree;
                SetParams(ref currentTree.Right);
            }
        }
        public void PrintTree(FibonacciTree W, int l)
        {
            int i;
            if (W != null)
            {
                PrintTree(W.Right, l + 1);
                for (i = 1; i <= l; i++)
                {
                    Console.Write("   ");
                }
                Console.WriteLine(W.Value);
                PrintTree(W.Left, l + 1);
            }
        }

        public FibonacciTree Delete(int target)
        {
            return Delete(this, target);
        }
        private FibonacciTree Delete(FibonacciTree current, int target)
        {
            FibonacciTree parent;
            if (current == null)
            { return null; }
            else
            {
                if (target < current.Value)
                {
                    current.Left = Delete(current.Left, target);
                    if (Balance_factor(current) == -2)
                    {
                        if (Balance_factor(current.Right) <= 0)
                        {
                            current = RotateRR(current);
                        }
                        else
                        {
                            current = RotateRL(current);
                        }
                    }
                }
                else if (target > current.Value)
                {
                    current.Right = Delete(current.Right, target);
                    if (Balance_factor(current) == 2)
                    {
                        if (Balance_factor(current.Left) >= 0)
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
                {
                    if (current.Right != null)
                    {
                        parent = current.Right;
                        while (parent.Left != null)
                        {
                            parent = parent.Left;
                        }
                        current.Value = parent.Value;
                        current.Right = Delete(current.Right, Parent.Value);
                        if (Balance_factor(current) == 2)
                        {
                            if (Balance_factor(current.Left) >= 0)
                            {
                                current = RotateLL(current);
                            }
                            else { current = RotateLR(current); }
                        }
                    }
                    else
                    {
                        return current.Left;
                    }
                }
            }
            return current;
        }
        private int Balance_factor(FibonacciTree current)
        {
            int l = GetHeight(current.Left);
            int r = GetHeight(current.Right);
            int b_factor = l - r;
            return b_factor;
        }
        private int GetHeight(FibonacciTree current)
        {
            int height = 0;
            if (current != null)
            {
                int l = GetHeight(current.Left);
                int r = GetHeight(current.Right);
                int m = Max(l, r);
                height = m + 1;
            }
            return height;
        }
        private int Max(int l, int r)
        {
            return l > r ? l : r;
        }
        private FibonacciTree RotateRR(FibonacciTree parent)
        {
            FibonacciTree pivot = parent.Right;
            parent.Right = pivot.Left;
            pivot.Left = parent;
            return pivot;
        }
        private FibonacciTree RotateLL(FibonacciTree parent)
        {
            FibonacciTree pivot = parent.Left;
            parent.Left = pivot.Right;
            pivot.Right = parent;
            return pivot;
        }
        private FibonacciTree RotateLR(FibonacciTree parent)
        {
            FibonacciTree pivot = parent.Left;
            parent.Left = RotateRR(pivot);
            return RotateLL(parent);
        }
        private FibonacciTree RotateRL(FibonacciTree parent)
        {
            FibonacciTree pivot = parent.Right;
            parent.Right = RotateLL(pivot);
            return RotateRR(parent);
        }
        
        public int Righted()
        {
            FibonacciTree tree = new FibonacciTree();
            tree = this;
            while (tree.Right != null)
            {
                tree = tree.Right;
            }
            return tree.Value;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Исходное дерево:");
            FibonacciTree tree = new FibonacciTree();
            tree = tree.BuildTree(8);
            tree.SetParams(ref tree);
            tree.PrintTree(tree, 0);
            Console.WriteLine();
        }
    }
}
