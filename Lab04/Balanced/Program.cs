using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balanced
{
    class Program
    {
        static void Main(string[] args)
        {
            BalancedTree tree = new BalancedTree();
            tree.Open();
            tree.Print();
            Console.ReadLine();
        }
    }

    public class Node
    {
        public string Value;
        public Node Right;
        public Node Left;
    }

    public class BalancedTree
    {
        public Node Root;
        public string[] input;
        public int Index;

        public BalancedTree()
        {
            Root = null;
        }
        
        public void Open()
        {
            string text = "";
            //Чтение файла
            using (StreamReader reader = new StreamReader("G:\\СИАКОД\\Никитины лабы\\Lab04SIACOD\\Lab04\\Balanced\\bin\\Debug\\Узлы.txt"))
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
            //Разбиение на узлы
            input = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int count = input.Length;
            Index = 0;
            Root = new Node();
            Building(count, Root);
        }

        public void Print()
        {
            Print(Root, 0);
        }

        void Print(Node node, int k)
        {
            if (node != null)
            {
                Print(node.Right, k + 1);
                for (int i = 1; i <= k; i++)
                {
                    Console.Write("  ");
                }
                Console.WriteLine(node.Value);
                Print(node.Left, k + 1);
            }
        }

        void Building(int N, Node node)
        {
            if (N != 0)
            {
                int nl = N / 2;//количество узлов слева
                int nr = N - nl - 1;//количество узлов справа
                node.Value = input[Index++];
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
    }
}
