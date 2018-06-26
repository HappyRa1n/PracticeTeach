using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_10
{
    class Point
    {
        private int i;
        private double x1;
        private double x2;
        public Point next;
        public Point()
        {
            x1 = 0;
            x2 = 0;
            next = null;
        }
        public Point(int i1,double x)
        {
            i = i1;
            x1 = x;
        }
        public double QualityX1
        {
            get { return x1; }
            set { x1 = value; }
        }
        public double QualityX2
        {
            get { return x2; }
            set { x2 = value; }
        }
    }
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
                if ((n < left || n > right) && b == true)
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
        static void CreatePointX2(Point list,double xn)//создание второй последовательности xi-xn
        {
            Point beg = list;
            Console.ForegroundColor = ConsoleColor.Yellow;
           while (beg.next!=null)
            {
                beg.QualityX2 = beg.QualityX1 - xn;
                Console.Write(beg.QualityX2 + " ");
                beg = beg.next;
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        static void WritePointX2(Point list)//вывод последовательности xi-xn
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Point beg = list;
            while (beg.next != null)
            {
                Console.Write(beg.QualityX2 + " ");
                beg = beg.next;
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;

        }
        static void WritePointX1(Point list)//вывод начальной последовательности
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Point beg = list;
            while (beg.next != null)
            {
                Console.Write(beg.QualityX1 + " ");
                beg = beg.next;
            }
            Console.Write(beg.QualityX1);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;

        }
        static Point CreatePoint(ref double xn)//создание начальной последовательности в ручную и с помощью ГСЧ
        {
            Console.WriteLine("Введите n");
            int n = EnterN(2, Int32.MaxValue);
            Console.WriteLine("Если хотите вручную вводить элементы введите 1, иначе введите 0");
            int t = EnterN(0, 1);
            if (t == 1)
            {
                Console.WriteLine("Введите значение 1-го элемента");
                double x1 = EnterD(Double.MinValue, Double.MaxValue);
                Point list = new Point(1, x1);
                Point beg = list;
                for (int i = 2; i <= n; i++)
                {
                    Console.WriteLine("Введите значение {0}-го элемента", i);
                    x1 = EnterD(Double.MinValue, Double.MaxValue);
                    beg.next = new Point(i, x1);
                    beg = beg.next;
                }
                xn = beg.QualityX1;
                WritePointX1(list);
                return list;
            }
            else
            {
                Random rnd = new Random();
                double x1 = Math.Round(rnd.Next(-100, 100) * 0.3,2);
                Point list = new Point(1, x1);
                Point beg = list;
                for (int i = 2; i <= n; i++)
                {
                    x1 = Math.Round(rnd.Next(-100, 100) * 0.3, 2);
                    beg.next = new Point(i, x1);
                    beg = beg.next;
                }
                xn = beg.QualityX1;
                WritePointX1(list);
                return list;
            }
        }
        static void Main(string[] args)
        {
            bool b2 = false;
            bool b=false;
            double xn=0;
            int k=0;
            Point list = new Point();
            while (k != 5)
            {
                Console.WriteLine("1. Создать начальную последовательность.\n2. Вывести начальную последовательность.\n3. Создать последовательность xi-xn.\n4. Вывести последовательность xi-xn.\n5. Выход.");
                k = EnterN(1, 5);
                switch (k)
                {
                    case 1:
                        list=CreatePoint(ref xn);
                        b = true;
                        break;
                    case 2:
                        if (b != false)
                        {
                            WritePointX1(list);
                        }
                        else
                            Console.WriteLine("Начальная последовательность еще не создана.");
                        break;
                    case 3:
                        if (b != false)
                        {
                            CreatePointX2(list,xn);
                            b2 = true;
                        }
                        else
                            Console.WriteLine("Начальная последовательность еще не создана.");
                        break;
                    case 4:
                        if (b2 != false)
                        {
                            WritePointX2(list);
                        }
                        else
                            Console.WriteLine("Последовательность xi-xn еще не создана.");
                        break;
                }
            }
        }
    }
}
