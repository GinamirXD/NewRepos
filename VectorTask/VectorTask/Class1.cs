using System;
namespace VectorTask
{
    public class Vector
    {
        public double X;
        public double Y;

        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"({X};{Y})";
        }
    }

    public class Grometry
    {
        public static double GetLength(Vector vector)
        {
            return Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
        }

        public static Vector Add(Vector vector1, Vector vector2)
        {
            Vector vector3 = new Vector(vector1.X + vector2.X, vector1.Y + vector2.Y);
            return vector3;
        }
    }

    public static void Main()
    {
        Vector v = new Vector(0, 0);
        Console.WriteLine(v);
    }
}