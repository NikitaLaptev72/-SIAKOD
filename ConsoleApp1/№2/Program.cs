using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _2
{
    class Program
    {
        static int[] BubbleSort(int[] mas)//Пузырьком
        {
            int temp;
            for (int i = 0; i < mas.Length; i++)
            {
                for (int j = i + 1; j < mas.Length; j++)
                {
                    if (mas[i] > mas[j])
                    {
                        temp = mas[i];
                        mas[i] = mas[j];
                        mas[j] = temp;
                    }
                }
            }
            return mas;
        }

        static int[] Shaker(int[] mass)//Шейкер-сортировка
        {
            int b = 0;
            int left = 0;//Левая граница
            int right = mass.Length - 1;//Правая граница
            while (left < right)
            {
                for (int i = left; i < right; i++)//Слева направо...
                {
                    if (mass[i] > mass[i + 1])
                    {
                        b = mass[i];
                        mass[i] = mass[i + 1];
                        mass[i + 1] = b;
                        b = i;
                    }
                }
                right = b;//Сохраним последнюю перестановку как границу
                if (left >= right) break;//Если границы сошлись выходим
                for (int i = right; i > left; i--)//Справа налево...
                {
                    if (mass[i - 1] > mass[i])
                    {
                        b = mass[i];
                        mass[i] = mass[i - 1];
                        mass[i - 1] = b;
                        b = i;
                    }
                }
                left = b;//Сохраним последнюю перестановку как границу
            }
            return mass;
        }

        //Сортировка бинарной вставкой
        static int[] Sort_bin_insert(int[] mass) // Сортировка бинарными вставками
        {
            int x, left, right, sred;
            for (int i = 1; i < mass.Length; i++)
            {
                if (mass[i - 1] > mass[i])
                {
                    x = mass[i];       // x – включаемый элемент
                    left = 0;       // левая граница отсортированной части массива
                    right = i - 1;  // правая граница отсортированной части массива 
                    do
                    {
                        sred = (left + right) / 2; // sred – новая "середина" последовательности
                        if (mass[sred] < x)
                        {
                            left = sred + 1;
                        }
                        else
                        {
                            right = sred - 1;
                        }
                    } while (left <= right); // поиск ведется до тех пор, пока левая граница не окажется правее правой границы
                    for (int j = i - 1; j >= left; j--)
                    {
                        mass[j + 1] = mass[j];
                    }
                    mass[left] = x;
                }
            }
            return mass;
        }

        //Сортировка вставками
        static int[] InsertionSort(int[] mass)
        {
            int newElement, location;

            for (int i = 1; i < mass.Count(); i++)
            {
                newElement = mass[i];
                location = i - 1;
                while (location >= 0 && mass[location] > newElement)
                {
                    mass[location + 1] = mass[location];
                    location = location - 1;
                }
                mass[location + 1] = newElement;
            }
            return mass;
        }

        //Сортировка выбором
        static int[] ChoosingSort(int[] mas)
        {

            for (int i = 0; i < mas.Length - 1; i++)
            {
                //поиск минимального числа
                int min = i;
                for (int j = i + 1; j < mas.Length; j++)
                {
                    if (mas[j] < mas[min])
                    {
                        min = j;
                    }
                }
                //обмен элементов
                int temp = mas[min];
                mas[min] = mas[i];
                mas[i] = temp;
            }
            return mas;
        }

        static int[] ShellSort(int[] mass)
        {
            int i, j, step;
            int tmp;
            for (step = mass.Count() / 2; step > 0; step /= 2)
            {
                for (i = step; i < mass.Count(); i++)
                {
                    tmp = mass[i];
                    for (j = i; j >= step; j -= step)
                    {
                        if (tmp < mass[j - step])
                        {
                            mass[j] = mass[j - step];
                        }
                        else
                        {
                            break;
                        }
                    }
                    mass[j] = tmp;
                }
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

        static void CallBuble(int[] mass)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            mass = BubbleSort(mass);
            timer.Stop();
            Console.WriteLine(" сортировка заняла: " + timer.ElapsedMilliseconds + " миллисекунд");
            timer.Reset();
            Console.WriteLine();
            mass = null;
            return;
        }

        static void CallShaker(int[] mass)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            mass = Shaker(mass);
            timer.Stop();
            Console.WriteLine(" сортировка заняла: " + timer.ElapsedTicks + " ticks");
            timer.Reset();
            Console.WriteLine();
            mass = null;
            return;
        }

        static void CallBinaryInsertionSort(int[] mass)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            mass = Sort_bin_insert(mass);
            timer.Stop();
            Console.WriteLine(" сортировка заняла: " + timer.ElapsedTicks + " ticks");
            timer.Reset();
            Console.WriteLine();
            Console.WriteLine();
            mass = null;
            return;
        }

        static void CallInsertionSort(int[] mass)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            mass = InsertionSort(mass);
            timer.Stop();
            Console.Write(" сортировка  заняла: " + timer.ElapsedTicks + " ticks");
            timer.Reset();
            Console.WriteLine();
            Console.WriteLine();
            mass = null;
            return;
        }

        static void CallChoosingSort(int[] mass)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            mass = ChoosingSort(mass);
            timer.Stop();
            Console.Write(" сортировка заняла: " + timer.ElapsedMilliseconds + " миллисекунд");
            timer.Reset();
            Console.WriteLine();
            Console.WriteLine();
            mass = null;
            return;
        }

        static void CallShellSort(int[] mass)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            mass = ShellSort(mass);
            timer.Stop();
            Console.Write(" сортировка заняла: " + timer.ElapsedMilliseconds + " миллисекунд");
            timer.Reset();
            Console.WriteLine();
            Console.WriteLine();
            mass = null;
            return;
        }

        static void Main(string[] args)
        {
            int[] mass = new int[5000];
            mass = CreationArray(mass);
            int[] masss = new int[10000];
            masss = CreationArray(mass);
            int[] massss = new int[20000];
            massss = CreationArray(mass);
            Console.WriteLine("\t\tПузырьковая сортировка");
            Console.WriteLine();
            int[] mass1 = new int[5000];
            mass1 = mass;
            int[] masss1 = new int[10000];
            masss1 = masss;
            int[] massss1 = massss;
            Console.Write("Для количества элементов = 5000");
            CallBuble(mass1);
            Console.Write("Для количества элементов = 10000");
            CallBuble(masss1);
            Console.Write("Для количества элементов = 20000");
            CallBuble(massss1);
            Console.WriteLine();
            Console.WriteLine("\t\tШейкер сортировка");
            Console.WriteLine();
            int[] mass2 = mass;
            int[] masss2 = masss;
            int[] massss2 = massss;
            Console.Write("Для количества элементов = 5000");
            CallShaker(mass2);
            Console.Write("Для количества элементов = 10000");
            CallShaker(masss2);
            Console.Write("Для количества элементов = 20000");
            CallShaker(massss2);
            Console.WriteLine();
            Console.WriteLine("\t\tСортировка бинарными вставками");
            Console.WriteLine();
            int[] mass3 = mass;
            int[] masss3 = masss;
            int[] massss3 = massss;
            Console.Write("Для количества элементов = 5000");
            CallBinaryInsertionSort(mass3);
            Console.Write("Для количества элементов = 10000");
            CallBinaryInsertionSort(masss3);
            Console.Write("Для количества элементов = 20000");
            CallBinaryInsertionSort(massss3);
            Console.WriteLine();
            Console.WriteLine("\t\tСортировка простыми вставками");
            Console.WriteLine();
            int[] mass4 = mass;
            int[] masss4 = masss;
            int[] massss4 = massss;
            Console.Write("Для количества элементов = 5000");
            CallInsertionSort(mass4);
            Console.Write("Для количества элементов = 10000");
            CallInsertionSort(masss4);
            Console.Write("Для количества элементов = 20000");
            CallInsertionSort(massss4);
            Console.WriteLine();
            Console.WriteLine("\t\tСортировка выбором");
            Console.WriteLine();
            int[] mass5 = mass;
            int[] masss5 = masss;
            int[] massss5 = massss;
            Console.Write("Для количества элементов = 5000");
            CallChoosingSort(mass5);
            Console.Write("Для количества элементов = 10000");
            CallChoosingSort(masss5);
            Console.Write("Для количества элементов = 20000");
            CallChoosingSort(massss5);
            Console.WriteLine();
            Console.WriteLine("\t\tСортировка Шелла");
            Console.WriteLine();
            int[] mass6 = mass;
            int[] masss6 = masss;
            int[] massss6 = massss;
            Console.Write("Для количества элементов = 5000");
            CallShellSort(mass6);
            Console.Write("Для количества элементов = 10000");
            CallShellSort(masss6);
            Console.Write("Для количества элементов = 20000");
            CallShellSort(massss6);
        }
    }
}
