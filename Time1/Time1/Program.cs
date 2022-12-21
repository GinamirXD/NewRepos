namespace Time1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var t1 = new Time(35, 70, 61);
            var t2 = new Time(35, 70);
            var t3 = new Time();
            var t4 = new Time(35);

            Console.WriteLine(t1);
            Console.WriteLine(t2);
            Console.WriteLine(t3);
            Console.WriteLine(t4);

            Console.WriteLine(t1.Seconds());

            Console.WriteLine(t1 + t2);
            Console.WriteLine(t1 - t2);
            Console.WriteLine(t1 * 2);
            Console.WriteLine(t1 / 2);
        }
    }
}