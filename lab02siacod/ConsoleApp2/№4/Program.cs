using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество предметов: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] weight = new int[n]; //вес
            int[] cost = new int[n]; //цена
            Console.WriteLine("Введите вместимость рюкзака: ");
            int size = Convert.ToInt32(Console.ReadLine()); //размер рюкзака

            for (int i = 0; i < n; i++)
            {
                Console.Write("Введите вес {0} предмета :", i + 1);
                weight[i] = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите стоимость {0} предмета :", i + 1);
                cost[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Метод восходящего программирования: ");
            Console.Write("Максимальная стоимость: ");
            KnapSolution(weight, cost, size);
            Console.WriteLine("Метод разделяй и властвуй: ");
            Console.WriteLine("Максимальная стоимость: ");
            Console.Write(KnapSolution2(weight, cost, size).ToString());
            Console.ReadKey();
        }

        //Восходящее динамическое
        static void KnapSolution(int[] weight, int[] cost, int size)
        {
            int n = weight.Length;
            int[] max = new int[size + 1];//максимальная стоимость при весе не более weight

            for (int i = 1; i <= size; i++)
            {
                max[i] = max[i - 1];
                Console.Write(" 1) " + max[i]);
                for (int j = 0; j < n; j++)
                {
                    if (weight[j] <= i)
                    {
                        Console.Write("2) " + max[i] + " ");
                        Console.Write("3) " + (max[i - weight[j]] + cost[j]) + " ");
                        max[i] = Math.Max(max[i], max[i - weight[j]] + cost[j]);
                        Console.Write("4) " + max[i]);
                        Console.Write("   ");
                    }
                }
            }
            Console.WriteLine(max[max.Length - 1]);
        }

        //Разделяй и властвуй
        static int KnapSolution2(int[] weight, int[] cost, int size)
        {
            int i, space, max, t;
            for (i = 0, max = 0; i < weight.Length; i++)
            {
                space = size - weight[i];
                if (space >= 0)
                {
                    t = KnapSolution2(weight, cost, space) + cost[i];
                    if (t > max)
                    {
                        max = t;
                    }
                }

            }
            return max;
        }
    }
}
