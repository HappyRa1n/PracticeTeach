using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_11
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
                if ((n < left || n > right) && b == true)
                {
                    Console.WriteLine("Ошибка ввода! Повторите ввод!");
                    b = false;
                }
            } while (b == false);
            return n;
        }
        static string deShifr(string text,int [] k)//функция дешифровки
        {
            string str = "";
            while (text.Length >= k.Length)
            {
                string substr = text.Substring(0, k.Length);
                char[] array = new char[k.Length];
                for (int i = 0; i < k.Length; i++)
                {
                    array[k[i]] = substr[i];
                }
                string newstr = new string(array);
                str = str + newstr;
                text = text.Remove(0, k.Length);
            }
            return str;
        }
        static string Shifr(string text,int[] k)//функция шифровки
        {
            string str = "";
            while (text.Length >= k.Length)
            {
                string newstr = "";
                string substr = text.Substring(0, k.Length);
                char[] array = substr.ToCharArray();
                for (int i = 0; i < k.Length; i++)
                {
                    newstr = newstr + array[k[i]];
                }
                str = str + newstr;
                text=text.Remove(0, k.Length);
            }
            if (text!="")
            {
                int raznica = k.Length - text.Length;
                string substring = text;
                for (int i = 0; i < raznica; i++)
                    substring = substring + " ";
                char[] array = substring.ToCharArray();
                string newstr = "";
                for (int i = 0; i < k.Length; i++)
                {
                    newstr = newstr + array[k[i]];
                }
                str = str + newstr;
            }
            return str;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Исходны текст для кодирования: ");
            string text = "Шура и Миша бегут на речку. С ними их пес Дружок. Друзья бросились в воду и поплыли. Дружок тоже любит купаться. Он сидит и скулит. Но вот его зовут и он прыгает в воду.";
            Console.WriteLine(text);
            Console.WriteLine();
            Console.WriteLine("Зафиксируйте k");
            int k = EnterN(2, Int32.MaxValue);
            int[] kmas = new int[k];
            Console.WriteLine("Введем перестановку k, символов");
            for(int i=0; i < k; i++)
            {
                bool b;
                do
                {
                    Console.WriteLine("Символ с какой позиции переметить на позицию {0}?", i);
                    b = true;
                    kmas[i] = EnterN(0, k-1);
                    for(int j=0;j<i;j++)
                        if (kmas[i]==kmas[j])
                        {
                            b = false;
                            Console.WriteLine("Ошибка! Вы уже ввели эту позицию ранее. Повторите ввод!");
                            break;
                        }
                }
                while (b == false);
            }
            Console.WriteLine("У вас получалась вот такая перестановка чисел к: ");
            for (int i = 0; i < k; i++)
                Console.Write(kmas[i] + " ");
            Console.WriteLine();
            Console.ReadKey();
            Console.WriteLine("Начальный текст: \n" + text);
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Зашифруем изначальный текст");
            Console.ForegroundColor = ConsoleColor.Gray;
            string text2 = Shifr(text, kmas);
            Console.WriteLine(text2);
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Расшифруем полученный текст");
            Console.ForegroundColor = ConsoleColor.Gray;
            string text3 = deShifr(text2, kmas);
            Console.WriteLine(text3);
            Console.ReadKey();
        }
    }
}
