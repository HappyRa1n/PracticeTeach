using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_7
{
    class Program
    {
        static void Monoton(int[]y)
        {
            bool b = true;
            int s1 = y[0] * 1000 + y[1] * 100 + y[2] * 10 + y[3];
            int s2 = y[4] * 1000 + y[5] * 100 + y[6] * 10 + y[7];
            if (s2 < s1)
            {
                Console.WriteLine("Функция не монотонна");
                return;
            }
            s1 = y[0] * 10 + y[1];
            s2 = y[2] * 10 + y[3];
            if (s2 < s1)
            {
                Console.WriteLine("Функция не монотонна");
                return;
            }
            s1 = y[4] * 10 + y[5];
            s2 = y[6] * 10 + y[7];
            if (s2 < s1)
            {
                Console.WriteLine("Функция не монотонна");
                return;
            }
            for(int i=0;i<y.Length;i=i+2)
            {
                if (y[i + 1] < y[i])
                {
                    Console.WriteLine("Функция не монотонна");
                    return;
                }
            }
            Console.WriteLine("Функция монотонна");
        }
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Console.WriteLine("начальная функция: ");
            int[] y = new int[8];
            for (int i = 0; i < y.Length; i++)
                y[i] = rnd.Next(0, 2);
            Console.Write("f( ");
            for (int i = 0; i < y.Length; i++)
            Console.Write(y[i] + " ");
            Console.WriteLine(")");
            Monoton(y);
            Console.ReadKey();
        }
    }
}
