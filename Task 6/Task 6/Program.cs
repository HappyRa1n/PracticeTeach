using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_6
{
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
                if (n < left || n > right)
                {
                    Console.WriteLine("Ошибка ввода! Повторите ввод!");
                    b = false;
                }
            } while (b == false);
            return n;
        }
        static void FunctionR(int a1, int a2, int a3,int e,int n,ref int n1,ref int num)//рекурсия для вывода элементов
        {
            num++;
            int a4 = a3 + 2 * a2 * a1;
            if (Math.Abs(a4 - a3) > e)//проверяем условие
            {
                n1++;
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            Console.WriteLine("a{0}= {1}", num, a4);
            Console.ForegroundColor = ConsoleColor.Gray;
            if (n1 != n)//условие выходя из рекурсии
            {
                FunctionR(a2, a3, a4, e, n, ref n1,ref num);
            }

        }
        static void Main(string[] args)
        {
            Console.WriteLine("11.	Ввести а1, а2, а3, N, E. Построить последовательность чисел ак = ак–1 + 2 * ак-2  * ак–3. Найти первые ее N элементов, такие что | ак  – ак–1 | > E. Напечатать последовательность, выделить искомые элементы и их номера.");
            Console.WriteLine("Ввведите a1");
            int a1 = EnterN(Int32.MinValue, Int32.MaxValue);
            Console.WriteLine("Ввведите a2");
            int a2 = EnterN(Int32.MinValue, Int32.MaxValue);
            Console.WriteLine("Ввведите a3");
            int a3 = EnterN(Int32.MinValue, Int32.MaxValue);
            Console.WriteLine("Введите N");
            int n = EnterN(3, Int32.MaxValue);
            Console.WriteLine("Введите E");
            int e= EnterN(Int32.MinValue, Int32.MaxValue);
            int n1=0;
            //печатаем первые элементы
            Console.WriteLine("a1= " + a1);
            if (Math.Abs(a2 - a1) > e)
            {
                n1++;
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            Console.WriteLine("a2= " + a2);
            Console.ForegroundColor = ConsoleColor.Gray;
            if (Math.Abs(a3 - a2) > e)
            {
                n1++;
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            Console.WriteLine("a3= " + a3);
            Console.ForegroundColor = ConsoleColor.Gray;
            int num = 3;
            FunctionR(a1, a2, a3, e, n, ref n1, ref num);
            Console.ReadKey();
        }
    }
}
