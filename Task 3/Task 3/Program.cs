using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    class Program
    {
        static float EnterF(float left,float right)//функция для ввода действительного числа по заданным параметрам
        {
            bool b;
            float n;
            do
            {
                b = Single.TryParse(Console.ReadLine(), out n);
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
        static bool CirclePlanPoint(float x,float y,float r)//функция проверят лежит ли точка в окружности заданного радиуса
        {
            if ((x * x + y * y) <= r*r)
                return true;
            else
                return false;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите X ");
            float x = EnterF(Single.MinValue,Single.MaxValue);
            Console.WriteLine("Введите Y ");
            float y = EnterF(Single.MinValue, Single.MaxValue);
            bool b = CirclePlanPoint(x, y, 1);//проверяем нашу точку
            if (b == true)//выводим результат
                Console.WriteLine("Точка принадлежит в окружности");
            else
                Console.WriteLine("Точка не принадлежит окружности");
            Console.ReadKey();
        }
    }
}
