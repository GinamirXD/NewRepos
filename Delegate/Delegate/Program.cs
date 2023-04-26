namespace Delegate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Collection<int> collection = new Collection<int>();
            collection.Add(1);
            collection.Add(2);
            collection.Add(3);
            collection.Add(4);
            collection.Add(5);

            int threshold = 3;
            int count = collection.Count(x => x > threshold);
            Console.WriteLine(count);

            int sum = collection.Aggregate((acc, x) => acc + x, 0);
            Console.WriteLine(sum);

            
            int max = collection.Aggregate((acc, x) => x > acc ? x : acc, collection[0]);
            Console.WriteLine(max);

            int min = collection.Aggregate((acc, x) => x < acc ? x : acc, collection[0]);
            Console.WriteLine(min);

            int count1 = collection.Count(x => x % 2 == 0 && x > 2);
            Console.WriteLine(count1);


        }
    }
}