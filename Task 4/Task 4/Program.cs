using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4
{
    class Program
    {
        static Double EnterD(double left, double right)//функция для ввода действительного числа по заданным параметрам
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
        static double Equation(double x)//функция для вычисления уравнения с заданным x
        {
             double y = Math.Round(Math.Pow(x, 5) - x - 0.2,15);//раунд использую чтобы не выйти за рпеделы разрядности
            return y;
        }
        static double Midle(double a, double b)//функция для нахождения середины отрезка
        {
            double x = (a + b) / 2;
            return x;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Перед вами программа, которая считает корень уравнения x^5-x-0.2 на отрезке [1,1.1] с указанной точностью(абсолютной погрешностью)");
            Console.WriteLine("Введите абсолютную погрешность(маленькое положительное действительное число)");
            double e = EnterD(0, Double.MaxValue);
            double a = 1;
            double b = 1.1;
            double x = Midle(a, b);
            while (Math.Abs(b - a) >= e)//проверяем корень на погрешность
            {
                if(Equation(a)*Equation(x)<0)
                    b = x;
                else
                    a = x;
                x = Midle(a, b);
            }
            Console.WriteLine(x);
            Console.ReadKey();
        }
    }
}
