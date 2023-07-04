using System;

namespace TZ_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n=0, m=0;

            Console.WriteLine("Размерность массива");
            try
            {
                n = int.Parse(Console.ReadLine());
                m = int.Parse(Console.ReadLine());
            }
            catch(Exception e)
            {
                Console.WriteLine("Не валидные значения");
                return;
            }

            if (n < 0 || m < 0) return;

            int[,] matrix = new int[n,m];

            FillMatrix(ref matrix, n, m);

            Console.WriteLine("Сумма главной диагонали: " + GetMatrixDiagonalSum(ref matrix, n, m));

            Console.WriteLine("Сумма элементов кратных 3 : " + GetMultiple3Sum(ref matrix, n, m));

            Console.ReadKey();

            return;
        }

        static int GetMatrixDiagonalSum(ref int[,] matrix, int n, int m)
        {
            int sum = 0;

            int matrix_size = Math.Min(n, m);

            for (int i = 0; i < matrix_size; i++)
            {
                sum += matrix[i,i];
            }
            return sum;
        }

        static int GetMultiple3Sum(ref int[,] matrix, int n, int m)
        {
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] % 3 == 0) sum += matrix[i, j];
                }
            }

            return sum;
        }

        static void FillMatrix(ref int[,] matrix, int n, int m)
        {

            Random ran = new Random();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i,j] = ran.Next(1, 15);
                    Console.Write("{0}\t", matrix[i,j]);
                }
                Console.WriteLine();
            }

        }
    }
}
