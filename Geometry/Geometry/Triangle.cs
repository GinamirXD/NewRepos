using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public class Triangle : IRotatable, IMovable
    {
        public Point Point1 { get; set; } = new();
        public Point Point2 { get; set; } = new();
        public Point Point3 { get; set; } = new();
        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            Point1 = new Point(x1, y1);
            Point2 = new Point(x2, y2);
            Point3 = new Point(x3, y3);
        }

        public void Move(double x, double y)
        {
            Point1.Move(x, y);
            Point2.Move(x, y);
            Point3.Move(x, y);
        }

        public void Rotate(double angle)
        {
            Point1.Rotate(angle);
            Point2.Rotate(angle);
            Point3.Rotate(angle);
        }

        public override string ToString() => $"Координаты треугольника:\n({Point1.X},{Point1.Y})\n({Point2.X},{Point2.Y})\n({Point3.X},{Point3.Y})";
    }
}
