using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5
{
    class Program
    {
        static double EnterD(double left, double right)//функция для ввода действительного числа по заданным параметрам
        {
            bool b;
            double n;
            do
            {
                b = Double.TryParse(Console.ReadLine(), out n);
                if (b == false)
                    Console.WriteLine("Ошибка ввода! Повторите ввод!");
                if ((n < left || n > right)&&b==true)
                {
                    Console.WriteLine("Ошибка ввода! Повторите ввод!");
                    b = false;
                }
            } while (b == false);
            return n;
        }
        static int EnterN(int left, int right)//функция для ввода целого числа по заданным параметрам
        {
            bool b;
            int n;
            do
            {
                b = Int32.TryParse(Console.ReadLine(), out n);
                if (b == false)
                    Console.WriteLine("Ошибка ввода! Повторите ввод!");
                if ((n < left || n > right) && b == true)
                {
                    Console.WriteLine("Ошибка ввода! Повторите ввод!");
                    b = false;
                }
            } while (b == false);
            return n;
        }
        static void EnterMatrix(ref double[,] m,int size)//функция для ввода марицы
        {
            Console.WriteLine("Если вы хотите сами вводить элементы, то введите 1, иначе введите 0");
            int k = EnterN(0, 1);
            if (k == 0)
            {
                Random rnd = new Random();
                for (int i = 0; i < size; i++)
                    for (int j = 0; j < size; j++)
                        m[i, j] = Math.Round(rnd.Next(-100,100)*0.3,1);
            }
            else
            {
                for (int i = 0; i < size; i++)
                    for (int j = 0; j < size; j++)
                    {
                        Console.WriteLine("Введите элемент {0},{1} ", i, j);
                        m[i, j] = EnterD(Double.MinValue, Double.MaxValue);
                    }
            }
            Console.WriteLine("Получилась такая матрица ");
            WriteMatrix(m, size);
        }
        static void WriteMatrix(double[,] m, int size)//функция для печати матрицы
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                    Console.Write(m[i, j] + "\t ");
                Console.WriteLine();
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите порядок матрицы");
            int size = EnterN(1, Int32.MaxValue);
            double[,] m = new double[size, size];
            EnterMatrix(ref m, size);
            double Sup=0;
            double Sdown=0;
            for(int i = 0; i < size; i++)//считаем суммы элементов
            {
                if(m[i,0]<0)
                {
                    for(int j=0;j<size;j++)
                    {
                        if (i != j && j < i)
                            Sdown = Sdown + m[i, j];
                        else
                        {
                            if (i != j)
                                Sup = Sup + m[i, j];
                        }
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Сумма элементов строк, начинающихся с отрицательного элемента и находящихся ниже главной диагонали матрицы равна " + Sdown);
            Console.WriteLine("Сумма элементов строк, начинающихся с отрицательного элемента и находящихся выше главной диагонали матрицы равна " + Sup);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ReadKey();
        }
    }
}
