using System;

namespace TZ_2a
{
    class Program
    {
        static double result = 1;

        static void Main(string[] args)
        {
            Console.WriteLine("Введите число, а затем степень в которую его нужно возвести: ");

            int number = int.Parse(Console.ReadLine());
            int degree = int.Parse(Console.ReadLine());

            result = number;

            Console.WriteLine("Число " + number +" в степени " + degree+ ": " + GetDegreeNumber(number, degree));

            Console.ReadKey();

            return;
        }

        static double GetDegreeNumber(int number, int degree)
        {
            int modDegree = Math.Abs(degree);

            if (modDegree == 1) return result;

            modDegree--;

            result *= number;

            GetDegreeNumber(number, modDegree);

            if (degree > 0)
            {
                return result;
            }
            else if (degree<0)
            {
                return (1 / result); 
            }

            return result;
        }

    }
}
