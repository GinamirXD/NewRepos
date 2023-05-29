using System.Drawing;
using System;
using System.Threading;
using System.Diagnostics;

namespace MatrixVectorMultiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = 10000;
            Stopwatch stopwatch = new Stopwatch();

            double[,] matrix = new double[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Random rnd = new Random();
                    matrix[i, j] = rnd.Next(10);
                }
            }

            double[] vector = new double[size];

            for (int i = 0; i < size; i++)
            {
                Random rnd = new Random();
                vector[i] = rnd.Next(10);
            }

            stopwatch.Start();

            double[] result = ParallelMultiply._ParallelMultiply(matrix, vector);

            stopwatch.Stop();

            long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;

            Console.WriteLine("Программа выполнилась за {0} миллисекунд.", elapsedMilliseconds);
        }
    }
}