using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixVectorMultiplier
{
    public class ThreadMultiply
    {
        public static double[] _ThreadMultiply(double[,] matrix, double[] vector)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            double[] result = new double[rows];

            Thread[] threads = new Thread[rows];

            for (int i = 0; i < rows; i++)
            {
                int rowIndex = i;
                threads[i] = new Thread(() =>
                {
                    double sum = 0;
                    for (int j = 0; j < cols; j++)
                    {
                        sum += matrix[rowIndex, j] * vector[j];
                    }
                    result[rowIndex] = sum;
                });

                threads[i].Start();
            }

            for (int i = 0; i < rows; i++)
            {
                threads[i].Join();
            }

            return result;
        }
    }
}
