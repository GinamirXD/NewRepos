using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public class Circle : IRotatable, IMovable
    {
        public double Radius { get; set; }
        public Point Center { get; set; } = new();
        public Circle(double radius, double x, double y) 
        {
            Radius = radius;
            Center = new Point(x, y);
        }

        public void Move(double x, double y) => Center.Move(x, y);
        public void Rotate(double angle) => Center.Rotate(angle);

        public override string ToString()
        {
            if (Center.X < 0 && Center.Y < 0) return $"Координаты точек:\n(x + {-Center.X})^2 + (y + {-Center.Y})^2 = {Radius}";
            if (Center.X >0 && Center.Y <0) return $"Координаты точек:\n(x - {Center.X})^2 + (y + {-Center.Y})^2 = {Radius}";
            if (Center.X <0 && Center.Y >0) return $"Координаты точек:\n(x + {-Center.X})^2 + (y - {Center.Y})^2 = {Radius}";
            return $"Координаты точек:\n(x- {Center.X})^2 + (y - {Center.Y})^2 = {Radius}";
        }
    }
}
