using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace num2
{
    class Program
    {
        static int Function(int param)
        {
            return param = param % 55;
        }

        static void Main(string[] args)
        {
            string[] keys = { "Иван", "Пётр", "Варвара", "Александр", "Анна", "Алла" };
            int[] keys1 = new int[keys.Count()];
            for (int i = 0; i < keys.Count(); i++)
            {
                Console.Write(keys[i] + " - ");
                for (int j = 0; j < keys[i].Count(); j++)
                {
                    keys1[i] += Convert.ToInt32(keys[i][j]);
                }
                keys1[i] = Function(keys1[i]);
                Console.WriteLine(keys1[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
