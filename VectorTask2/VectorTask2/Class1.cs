using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorTask2
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
    
}