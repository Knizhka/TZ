using System;

namespace TZ_2a
{
    class Program
    {
        static int prev = 1, cur = 0;

        static void Main(string[] args)
        {

            Console.WriteLine("Введите порядковый номер числа в последовательности фибоначи: ");

            int num = int.Parse(Console.ReadLine()) + 1;

            if (num < 1) return;

            Console.WriteLine("Число в последовательности фибоначи: " + Fibonachi(num));

            Console.ReadKey();

            return;
        }

        static int Fibonachi(int num)
        {
            if (num == 1)
            {
                return cur;
            }

            int tmp = cur;

            cur += prev;
            prev = tmp;
            num--;

            Fibonachi(num);

            return cur;
        }

    }
}
