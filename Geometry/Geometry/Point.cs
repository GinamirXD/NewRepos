using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public class Point : IRotatable, IMovable
    {
        private double x;
        private double y;
       public Point() { }
        public double X { get => x; set { x = Math.Round(value, 5); } }
        public double Y { get => y; set { y = Math.Round(value, 5); } }
        public Point(double xs, double ys)
        { 
            X = xs;
            Y = ys; 
        }

        public static double GetRotatedX(double x, double y, double angle) => x * Math.Cos(angle) - y * Math.Sin(angle);
        public static double GetRotatedY(double x, double y, double angle) => x * Math.Sin(angle) + y * Math.Cos(angle);
        public void Move(double xm, double ym)
        {
            X += xm;
            Y += ym;
        }

        public void Rotate(double angle) 
        {
            var xr = GetRotatedX(X,Y,angle);
            Y = GetRotatedY(X,Y,angle);
            X = xr;
        }

        public override string ToString() => $"Координаты точки:\n({X},{Y})";
    }
}
