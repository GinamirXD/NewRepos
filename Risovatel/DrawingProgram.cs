using System;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace RefactorMe
{
    class Drawer
    {
        static float x, y;
        static Graphics graphics;

        public static void Initialization(Graphics newGraphics)
        {
            graphics = newGraphics;
            graphics.SmoothingMode = SmoothingMode.None;
            graphics.Clear(Color.Black);
        }

        public static void SetPosition(float x0, float y0)
        {
            x = x0;
            y = y0;
        }

        public static void MakeIt(Pen pen, double lenght, double angle)
        {
            var x1 = (float)(x + lenght * Math.Cos(angle));
            var y1 = (float)(y + lenght * Math.Sin(angle));
            graphics.DrawLine(pen, x, y, x1, y1);
            x = x1;
            y = y1;
        }

        public static void Change(double lenght, double angle)
        {
            x = (float)(x + lenght * Math.Cos(angle));
            y = (float)(y + lenght * Math.Sin(angle));
        }
    }

    public class ImpossibleSquare
    {
        private const float SideStep = 0.375f;
        private const float DiagonalStep = 0.04f;
        private const double HalfPi = Math.PI / 2;
        private const double QuarterPi = Math.PI / 4;

        public static void Draw(int width, int height, double rotationAngle, Graphics graphics)
        {

            Drawer.Initialization(graphics);

            var size = Math.Min(width, height);

            var diagonal_length = Math.Sqrt(2) * (size * 0.375f + size * 0.04f) / 2;
            var x0 = (float)(diagonal_length * Math.Cos(Math.PI / 4 + Math.PI)) + width / 2f;
            var y0 = (float)(diagonal_length * Math.Sin(Math.PI / 4 + Math.PI)) + height / 2f;

            Drawer.SetPosition(x0, y0);

            DrawFirstSide(size);
            DrawSecondSide(size);
            DrawThirdSide(size);
            DrawFourthSide(size;
        }

        private static void DrawFirstSide(int size)
        {
            //Рисуем 1-ую сторону
            Drawer.makeIt(Pens.Yellow, size * SideStep, 0);
            Drawer.makeIt(Pens.Yellow, size * DiagonalStep * Math.Sqrt(2), QuarterPi);
            Drawer.makeIt(Pens.Yellow, size * SideStep, Math.PI);
            Drawer.makeIt(Pens.Yellow, size * SideStep - size * DiagonalStep, HalfPi);

            Drawer.Change(size * DiagonalStep, -Math.PI);
            Drawer.Change(size * DiagonalStep * Math.Sqrt(2), 3 * QuarterPi);
        }

        private static void DrawSecondSide(int size)
        {
            //Рисуем 2-ую сторону
            Drawer.makeIt(Pens.Yellow, size * SideStep, -HalfPi);
            Drawer.makeIt(Pens.Yellow, size * DiagonalStep * Math.Sqrt(2), -HalfPi + QuarterPi);
            Drawer.makeIt(Pens.Yellow, size * SideStep, -HalfPi + Math.PI);
            Drawer.makeIt(Pens.Yellow, size * SideStep - size * DiagonalStep, -HalfPi + HalfPi);

            Drawer.Change(size * DiagonalStep, -HalfPi - Math.PI);
            Drawer.Change(size * DiagonalStep * Math.Sqrt(2), -HalfPi + 3 * QuarterPi);
        }

        private static void DrawThirdSide(int size)
        {
            //Рисуем 3-ю сторону
            Drawer.makeIt(Pens.Yellow, size * SideStep, Math.PI);
            Drawer.makeIt(Pens.Yellow, size * DiagonalStep * Math.Sqrt(2), Math.PI + QuarterPi);
            Drawer.makeIt(Pens.Yellow, size * SideStep, Math.PI + Math.PI);
            Drawer.makeIt(Pens.Yellow, size * SideStep - size * DiagonalStep, Math.PI + HalfPi);

            Drawer.Change(size * DiagonalStep, Math.PI - Math.PI);
            Drawer.Change(size * DiagonalStep * Math.Sqrt(2), Math.PI + 3 * QuarterPi);
        }

        private static void DrawFourthSide(int size)
        {
            //Рисуем 4-ую сторону
            Drawer.makeIt(Pens.Yellow, size * SideStep, HalfPi);
            Drawer.makeIt(Pens.Yellow, size * DiagonalStep * Math.Sqrt(2), HalfPi + QuarterPi);
            Drawer.makeIt(Pens.Yellow, size * SideStep, HalfPi + Math.PI);
            Drawer.makeIt(Pens.Yellow, size * SideStep - size * DiagonalStep, HalfPi + HalfPi);

            Drawer.Change(size * DiagonalStep, HalfPi - Math.PI);
            Drawer.Change(size * DiagonalStep * Math.Sqrt(2), HalfPi + 3 * QuarterPi);
        }
    }
}