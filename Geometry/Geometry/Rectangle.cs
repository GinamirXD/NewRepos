using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public class Rectangle : IRotatable, IMovable
    {
        public Point BottomLeft { get; set; } = new();
        public Point TopRight { get; set; } = new();
        public Rectangle(double x1, double y1, double x2, double y2)
        {
            BottomLeft = new Point(x1, y1);
            TopRight = new Point(x2, y2);
        }

        public void Move(double x, double y) 
        {
            BottomLeft.Move(x, y);
            TopRight.Move(x, y);
        }

        public void Rotate(double angle) 
        {
            BottomLeft.Rotate(angle);
            TopRight.Rotate(angle);
        }
        
        public override string ToString() => $"Координаты прямоугольника:\n({BottomLeft.X},{BottomLeft.Y})\n({BottomLeft.X},{TopRight.Y})\n({TopRight.X},{TopRight.Y})\n({TopRight.X},{BottomLeft.Y})";
    }
}
