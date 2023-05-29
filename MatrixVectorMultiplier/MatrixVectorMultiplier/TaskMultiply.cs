using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixVectorMultiplier
{
    public class TaskMultiply
    {
        public static double[] _TaskMultiply(double[,] matrix, double[] vector)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            double[] result = new double[rows];

            Task[] tasks = new Task[rows];

            for (int i = 0; i < rows; i++)
            {
                int rowIndex = i;
                tasks[i] = Task.Run(() =>
                {
                    double sum = 0;
                    for (int j = 0; j < cols; j++)
                    {
                        sum += matrix[rowIndex, j] * vector[j];
                    }
                    result[rowIndex] = sum;
                });
            }

            Task.WaitAll(tasks);

            return result;
        }
    }
}
