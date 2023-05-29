using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorTask2
{
    public class Geometry
    {
        public double GetLength(Vector vector)
        {
            return Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
        }

        public static Vector Add(Vector vector1, Vector vector2)
        {
            Vector vector3 = new Vector(vector1.X + vector2.X, vector1.Y + vector2.Y);
            return vector3;
        }
        public static double GetLength(Segment s)
        {
            return Math.Sqrt((s.End.X - s.Begin.X)*(s.End.X - s.Begin.X) 
                + (s.End.Y - s.Begin.Y) * (s.End.Y - s.Begin.Y));
        }
        public static bool IsVectorInSegment(Vector vector, Segment segment)
        {
            if (((vector.X == segment.Begin.X) || (vector.X == segment.End.X)) && ((vector.Y == segment.End.Y) || (vector.Y == segment.Begin.Y)))
                return true;

            return ((vector.X - segment.Begin.X) * (vector.X - segment.End.X) <= 0) && ((vector.Y - segment.Begin.Y) * (vector.Y - segment.End.Y) < 0);
        }
    }
}
