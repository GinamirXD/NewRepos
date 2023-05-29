using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixVectorMultiplier
{
    public class ParallelMultiply
    {
        public static double[] _ParallelMultiply(double[,] matrix, double[] vector)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            double[] result = new double[rows];

            Parallel.For(0, rows, rowIndex =>
            {
                double sum = 0;
                for (int j = 0; j < cols; j++)
                {
                    sum += matrix[rowIndex, j] * vector[j];
                }
                result[rowIndex] = sum;
            });

            return result;
        }
    }
}