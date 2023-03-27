namespace Polynom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var polynomialList1 = Polynomial.BuildPolynomial("C:\\Users\\ginam\\source\\repos\\NewRepos\\Polynom\\Polynom\\Polynom1.txt");
            Console.WriteLine(polynomialList1);

            polynomialList1.Insert(2, 4);
            Console.WriteLine(polynomialList1);

            Console.WriteLine("**********");
            var polynomialList2 = Polynomial.BuildPolynomial("C:\\Users\\ginam\\source\\repos\\NewRepos\\Polynom\\Polynom\\Poynom2.txt");
            Console.WriteLine(polynomialList2);

            polynomialList1.Sum(polynomialList2);
            Console.WriteLine(polynomialList1);

            polynomialList2.Derive();
            Console.WriteLine(polynomialList2);

            var result = polynomialList2.Value(1);
            var result2 = polynomialList2.Value(5);

            Console.WriteLine(result);
            Console.WriteLine(result2);
        }
    }
}