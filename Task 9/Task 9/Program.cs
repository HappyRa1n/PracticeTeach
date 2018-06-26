using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_9
{
    class Point
    {
        public int date;
        public Point pred, next;
        public Point()
        {
            date = 0;
            pred = null;
            next = null;
        }
        public Point(int d)
        {
            date = d;
            pred = null;
            next = null;
        }
    }
    class Program
    {
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
        static Point CreateEL(int d)
        {
            Point p = new Point(d);
            return p;
        }
        static Point CreateList(int n)//функция для создания списка
        {
            Point beg = CreateEL(1);
            Point beg1 = beg;
            for(int i = 2; i <= n; i++)
            {
                Point p = CreateEL(i);
                beg1.next = p;
                p.pred = beg1;
                beg1 = p;
            }
            return beg;
        }
        static void WriteList(Point p)//функция для печати списка
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            while (p.next != null)
            {
                Console.Write(p.date+" ");
                p = p.next;
            }
            Console.Write(p.date);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
        }
        static int FindEl(Point p,int date1)//функция для поиска элемента
        {
            int f = 1;
            while (p.next != null)
            {
                if (p.date == date1)
                    return f;
                f++;
                p = p.next;
            }
            if (p.date == date1)
                return f;
            else return 0;
        }
        static void DelEl(ref Point p,int d)//функция для удаления элемента
        {
            Point beg = p;
            if (beg.date == d)
            {
                p = beg.next;
                p.pred = null;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Элемент удален");
                Console.ForegroundColor = ConsoleColor.Gray;
                return;
            }
            beg = beg.next;
            while (beg.next != null)
            {
                if(beg.date==d)
                {
                    beg.pred.next = beg.next;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Элемент удален");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    return;
                }
                beg = beg.next;
            }
            if (beg.date == d)
            {
                beg.pred.next = null;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Элемент удален");
                Console.ForegroundColor = ConsoleColor.Gray;
                return;
            }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Элемент не найден");
                Console.ForegroundColor = ConsoleColor.Gray;
        }
        static void Main(string[] args)
        {
            int n=0;
            bool b = false;
            Point list = new Point();
            int k=0;
            while(k!=5)
            {
                Console.WriteLine("1. Создать двунаправленный список.\n2. Распечатать список.\n3. Найти элемент в списке по информационному полю.\n4. Удалить эелемент из списка.\n5. Выход");
                k = EnterN(1, 5);
                switch (k)
                {
                    case 1:
                        Console.WriteLine("Введите N");
                        n = EnterN(1, Int32.MaxValue);
                        list = CreateList(n);
                        CreateList(n);
                        Console.WriteLine("Получился список: ");
                        WriteList(list);
                        b = true;
                        break;
                    case 2:
                        if (b)
                            WriteList(list);
                        else
                            Console.WriteLine("Список еще не создан");
                        break;
                    case 3:
                        if (b)
                        {
                            Console.WriteLine("Введите значение информационного поля искомого элемента списка");
                            int el = EnterN(Int32.MinValue, Int32.MaxValue);
                            int num = FindEl(list, el);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            if (num != 0)
                                Console.WriteLine("Элемент {0} найден. Позиция элемента - {1}", el, num);
                            else
                                Console.WriteLine("Элемент не найден!");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        else
                            Console.WriteLine("Список еще не создан");
                        break;
                    case 4:
                        if (b)
                        {
                            Console.WriteLine("Введите значение информационного поля искомого элемента списка");
                            int el2 = EnterN(Int32.MinValue, Int32.MaxValue);
                            if (n != 1)
                            {
                                DelEl(ref list, el2);
                                n--;
                            }
                            else
                            {
                                b = false;
                                Console.WriteLine("Список удален");
                            }
                        }
                        else
                            Console.WriteLine("Список еще не создан");
                        break;
                }
            }
        }
    }
}
