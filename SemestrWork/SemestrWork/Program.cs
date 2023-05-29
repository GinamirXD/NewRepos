namespace SemestrWork
{
    internal class Program
    {
        public static void Main(String[] args)
        {
            Graph g = new Graph(5);
            g.addEdge(1, 0);
            g.addEdge(0, 2);
            g.addEdge(2, 1);
            g.addEdge(0, 3);
            g.addEdge(3, 4);

            Console.WriteLine(
                "Following are strongly connected components "
                + "in given graph ");
            g.printSCCs();
        }
    }
}