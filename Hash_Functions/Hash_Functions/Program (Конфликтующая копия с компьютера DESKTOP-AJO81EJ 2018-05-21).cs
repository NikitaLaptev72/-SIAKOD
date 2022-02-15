using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash_Functions
{
    class Program
    {
        public static int Function(int param)
        {
            return (param + 18) / 63;
        }

        public static bool Test(int[] array)
        {
            bool test = false;

            for (int i = 0; i < (array.Count() - 1); i++)
            {
                for (int j = i+1; j < array.Count(); j++)
                {
                    if (array[j] == array[i])
                    {
                        test = true;
                        break;
                    }
                }
                if (test == true)
                {
                    break;
                }
            }

            if (test == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void Main(string[] args)
        {
            int[] keys = { 81, 129, 301, 38, 434, 216, 412, 487, 234 };
            Console.WriteLine("Хеш-функция:");
            for (int i = 0; i < keys.Count(); i++)
            {                
                keys[i] = Function(keys[i]);
                Console.Write(keys[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Проверка на совершенность:");
            if (Test(keys) == true)
            {
                Console.WriteLine("Хеш-функция не совершенна");
            }
            else
            {
                Console.WriteLine("Хеш-функция совершенна");
            }
        }
    }
}
