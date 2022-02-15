using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _4
{
    class Program
    {
        static int[] ShellSort1(int[] mass)
        {
            int j;
            int step = 4096;
            while (step > 0)
            {
                for (int i = 0; i < (mass.Length - step); i++)
                {
                    j = i;
                    while ((j >= 0) && (mass[j] > mass[j + step]))
                    {
                        int tmp = mass[j];
                        mass[j] = mass[j + step];
                        mass[j + step] = tmp;
                        j -= step;
                    }
                }
                step = step / 2;
            }
            return mass;
        }

        public static int[] ShellSort2(int[] mass)
        {
            int j;
            int step = 800;
            while (step > 0)
            {
                for (int i = 0; i < (mass.Length - step); i++)
                {
                    j = i;
                    while ((j >= 0) && (mass[j] > mass[j + step]))
                    {
                        int tmp = mass[j];
                        mass[j] = mass[j + step];
                        mass[j + step] = tmp;
                        j -= step;
                    }
                }
                step = (step - 20) / 3;
            }
            return mass;
        }
        public static int[] ShellSort3(int[] mass)
        {
            int j;
            int step = 3000;
            while (step > 0)
            {
                for (int i = 0; i < (mass.Length - step); i++)
                {
                    j = i;
                    while ((j >= 0) && (mass[j] > mass[j + step]))
                    {
                        int tmp = mass[j];
                        mass[j] = mass[j + step];
                        mass[j + step] = tmp;
                        j -= step;
                    }
                }
                step = (step - 200) / 2;
            }
            return mass;
        }

        static int[] CreationArray(int[] keys)
        {
            Random rnd = new Random();
            for (int i = 0; i < keys.Count(); i++)
            {
                keys[i] = rnd.Next(1, int.MaxValue);
            }
            return keys;
        }

        static void CallShellSort1(int[] mass)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            mass = ShellSort1(mass);
            timer.Stop();
            Console.WriteLine("Сортировка " + mass.Count() + " элементов заняла: " + timer.ElapsedTicks + " ticks");
            timer.Reset();
            Console.WriteLine();
            return;
        }

        static void CallShellSort2(int[] mass)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            mass = ShellSort2(mass);
            timer.Stop();
            Console.WriteLine("Сортировка " + mass.Count() + " элементов заняла: " + timer.ElapsedTicks + " ticks");
            timer.Reset();
            Console.WriteLine();
            return;
        }

        static void CallShellSort3(int[] mass)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            mass = ShellSort3(mass);
            timer.Stop();
            Console.WriteLine("Сортировка " + mass.Count() + " элементов заняла: " + timer.ElapsedTicks + " ticks");
            timer.Reset();
            Console.WriteLine();
            return;
        }

        static void Main(string[] args)
        {
            int[] mass;
            mass = new int[25000];
            mass = CreationArray(mass);
            CallShellSort1(mass);
            mass = new int[50000];
            mass = CreationArray(mass);
            CallShellSort2(mass);
            mass = new int[100000];
            mass = CreationArray(mass);
            CallShellSort3(mass);
        }
    }
}
