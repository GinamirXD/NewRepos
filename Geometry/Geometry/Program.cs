namespace Geometry
{
    public class Program
    {
        public static void Main()
        {
            Rectangle r = new(1, 1, 3, 2);
            Console.WriteLine(r);
            r.Move(1, 1);
            Console.WriteLine(r);
            r.Rotate(Math.PI/2);
            Console.WriteLine(r);

            Triangle t = new(1, 1, 1, 3, 3, 1);
            Console.WriteLine(t);
            t.Move(1, 1);
            Console.WriteLine(t);
            t.Rotate(Math.PI/2);
            Console.WriteLine(t);

            Circle c = new(4, 1, 1);
            Console.WriteLine(c);
            c.Move(1, 1);
            Console.WriteLine(c);
            c.Rotate(Math.PI/ 2);
            Console.WriteLine(c);

            Point p = new(1, 1);
            Console.WriteLine(p);
            p.Move(1, 1);
            Console.WriteLine(p);
            p.Rotate(Math.PI / 2);
            Console.WriteLine(p);
        }
    }
}