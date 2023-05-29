namespace GraphGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            /*int numVertices = int.Parse(Console.ReadLine());
            double edgeProbability = 0.2;

            Random random = new Random();
            bool[,] adjacencyMatrix = new bool[numVertices, numVertices];
            for (int i = 0; i < numVertices; i++)
            {
                for (int j = 0; j < numVertices; j++)
                {
                    if (i != j && random.NextDouble() < edgeProbability)
                    {
                        adjacencyMatrix[i, j] = true;
                    }
                }
            }

            using (StreamWriter writer = new StreamWriter("C:\\Users\\ginam\\source\\repos\\NewRepos\\GraphGenerator\\GraphGenerator\\graph24.txt"))
            {
                writer.WriteLine(numVertices);

                for (int i = 0; i < numVertices; i++)
                {
                    for (int j = 0; j < numVertices; j++)
                    {
                        if (adjacencyMatrix[i, j])
                        {
                            writer.WriteLine("{0} {1}", i, j);
                        }
                    }
                }
            }*/

            for(int num = 25; num < 51; num++)
            {
                int numVertices = num * 5 + 5;
                double edgeProbability = 0.2;

                Random random = new Random();
                bool[,] adjacencyMatrix = new bool[numVertices, numVertices];
                for (int i = 0; i < numVertices; i++)
                {
                    for (int j = 0; j < numVertices; j++)
                    {
                        if (i != j && random.NextDouble() < edgeProbability)
                        {
                            adjacencyMatrix[i, j] = true;
                        }
                    }
                }

                using (StreamWriter writer = new StreamWriter($"C:\\Users\\ginam\\source\\repos\\NewRepos\\GraphGenerator\\GraphGenerator\\graph{num}.txt"))
                {
                    writer.WriteLine(numVertices);

                    for (int i = 0; i < numVertices; i++)
                    {
                        for (int j = 0; j < numVertices; j++)
                        {
                            if (adjacencyMatrix[i, j])
                            {
                                writer.WriteLine("{0} {1}", i, j);
                            }
                        }
                    }
                }
            }
        }
    }
}