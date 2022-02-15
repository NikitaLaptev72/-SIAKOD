using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04
{
    class Node
    {
        public double frequency;
        public string data;
        public Node leftChild, rightChild;

        public Node(string data, double frequency)
        {
            this.data = data;
            this.frequency = frequency;
        }

        public Node(Node leftChild, Node rightChild)
        {
            this.leftChild = leftChild;
            this.rightChild = rightChild;

            data = leftChild.data + ":" + rightChild.data;
            frequency = leftChild.frequency + rightChild.frequency;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст:");
            string text = Console.ReadLine();
            double count_a = 0, count_b = 0, count_v = 0, count_g = 0, count_d = 0, count_e = 0;
            char[] letter = text.ToLower().ToCharArray();
            char[] alphabet = { 'а', 'б', 'в', 'г', 'д', 'е' };
            double mycount = 0;
            for (int i = 0; i < letter.Length; i++)
            {
                mycount++;
                switch (letter[i])
                {
                    case 'а': count_a++; break;
                    case 'б': count_b++; break;
                    case 'в': count_v++; break;
                    case 'г': count_g++; break;
                    case 'д': count_d++; break;
                    case 'е': count_e++; break;
                }
            }

            Console.WriteLine("Букв в тексте: " + mycount);
            double[] frequencies = new double[6];
            double friq = 0;
            char alph;

            frequencies[0] = count_a / mycount;
            frequencies[1] = count_b / mycount;
            frequencies[2] = count_v / mycount;
            frequencies[3] = count_g / mycount;
            frequencies[4] = count_d / mycount;
            frequencies[5] = count_e / mycount;

            for (int i = 0; i < frequencies.Length; i++)//сортировка частоты по убыванию
            {
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (frequencies[i] > frequencies[j])
                    {
                        friq = frequencies[j];
                        alph = alphabet[j];
                        frequencies[j] = frequencies[i];
                        alphabet[j] = alphabet[i];
                        frequencies[i] = friq;
                        alphabet[i] = alph;
                    }
                }
            }

            for (int i = 0; i < frequencies.Length; i++)
            {
                Console.WriteLine("Символ: {0} имеет частоту: {1}", alphabet[i], String.Format("{0:0.00}", frequencies[i]));
            }

            List<Node> list = new List<Node>();
            for (int i = 0; i < frequencies.Length; i++)
            {
                list.Add(new Node(alphabet[i].ToString(), frequencies[i]));
            }
            Stack<Node> stack = GetSortedStack(list);

            while (stack.Count > 1)
            {
                Node leftChild = stack.Pop();
                Node rightChild = stack.Pop();
                Node parentNode = new Node(leftChild, rightChild);
                stack.Push(parentNode);
                stack = GetSortedStack(stack.ToList());
            }
            Node parentNode1 = stack.Pop();
            GenerateCode(parentNode1, "", 0);
            Console.ReadKey();
        }

        public static Stack<Node> GetSortedStack(List<Node> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count; j++)
                {
                    if (list[i].frequency > list[j].frequency)
                    {
                        Node tempNode = list[j];
                        list[j] = list[i];
                        list[i] = tempNode;
                    }
                }
            }
            Stack<Node> stack = new Stack<Node>();
            for (int i = 0; i < list.Count; i++)  
            {
                stack.Push(list[i]);
            }
            return stack;
        }

        public static void GenerateCode(Node parentNode, string code, int l)
        {
            if (parentNode != null)
            {
                GenerateCode(parentNode.leftChild, code + "0", l + 1);
                if (parentNode.leftChild == null && parentNode.rightChild == null)
                {
                    for (int i = 1; i <= l; i++) Console.Write("  ");
                    Console.WriteLine(parentNode.data + " {" + code + "} ");
                }
                GenerateCode(parentNode.rightChild, code + "1", l + 1);
            }
        }
    }
}
