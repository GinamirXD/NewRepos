using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

class Graph
{
    private int V; // Кол-во вершин
    private List<int>[] adj; // Список смежностей

    Graph(int v)
    {
        V = v;
        adj = new List<int>[v];
        for (int i = 0; i < v; ++i)
            adj[i] = new List<int>();
    }

    // Функция для добавления ребра в граф
    void addEdge(int v, int w) { adj[v].Add(w); }

    // Рекурсивная функция для печати DFS, начиная с v
    void DFSUtil(int v, bool[] visited)
    {

        //  Отмечает текущий узел как посещенный
        visited[v] = true;
        Console.Write(v + " ");

        //Повторяется для всех вершин, смежных с этой вершиной
        List<int> i = adj[v];
        foreach (var n in i)
        {
            if (!visited[n])
                DFSUtil(n, visited);
        }
    }

    // Функция, которая возвращает транспонированный граф
    Graph getTranspose()
    {
        Graph g = new Graph(V);
        for (int v = 0; v < V; v++)
        {

            //Повторяется для всех вершин, смежных с этой вершиной
            foreach (int i in adj[v])
                g.addEdge(i, v);
        }
        return g;
    }

    void fillOrder(int v, bool[] visited, Stack<int> stack)
    {
        visited[v] = true;

        foreach (var n in adj[v])
        {
            if (!visited[n])
                fillOrder(n, visited, stack);
        }

        stack.Push(v);
    }

    void printSCCs()
    {
        Stack<int> stack = new Stack<int>();
        var iterations = 0;
        // Отмечает все вершины как не посещенные (для первого DFS)
        var visited = new bool[V];

        // Заполняет вершины в стеке в соответствии со временем их завершения
        for (int i = 0; i < V; i++)
        {
            if (visited[i] == false)
                fillOrder(i, visited, stack);
            iterations++;
        }

        Graph gr = getTranspose();

        for (int i = 0; i < V; i++)
            visited[i] = false;

        while (stack.Count != 0)
        {

            int v = stack.Pop();

            //Выводит сильно связанный компонент выделенной вершины
            if (visited[v] == false)
            {
                gr.DFSUtil(v, visited);
                Console.WriteLine();
            }
            iterations++;
        }
        using (StreamWriter writer = new StreamWriter("C:\\Users\\ginam\\source\\repos\\NewRepos\\ConsoleApp2\\ConsoleApp2\\Iterations.txt", true))
        {
            writer.WriteLine(iterations);
        }
    }
   
    public static void Main(String[] args)
    {
        /*Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();

        string[] lines = File.ReadAllLines("C:\\Users\\ginam\\source\\repos\\NewRepos\\GraphGenerator\\GraphGenerator\\graph50.txt");
        int numVertices = int.Parse(lines[0]);
        
        Graph g = new Graph(numVertices);

        List<List<int>> adjacencyList = new List<List<int>>();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(' ');
            int startVertex = int.Parse(parts[0]);
            int endVertex = int.Parse(parts[1]);
            List<int> edge = new List<int> { startVertex, endVertex };
            adjacencyList.Add(edge);
        }

        for (int i = 0; i < adjacencyList.Count; i++)
        {
            g.addEdge(adjacencyList[i][0], adjacencyList[i][1]);
        }

        g.printSCCs();

        stopWatch.Stop();
        TimeSpan ts = stopWatch.Elapsed;
        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);

        using (StreamWriter writer = new StreamWriter("C:\\Users\\ginam\\source\\repos\\NewRepos\\ConsoleApp2\\ConsoleApp2\\Time.txt"))
        {
            writer.WriteLine(elapsedTime);
        }*/
        Stopwatch stopWatch = new Stopwatch();

        using (StreamWriter writer = new StreamWriter("C:\\Users\\ginam\\source\\repos\\NewRepos\\ConsoleApp2\\ConsoleApp2\\Time.txt", true))

        for (int j = 1; j < 51; j++)
        {           
            stopWatch.Start();

            string[] lines = File.ReadAllLines($"C:\\Users\\ginam\\source\\repos\\NewRepos\\GraphGenerator\\GraphGenerator\\graph{j}.txt");
            int numVertices = int.Parse(lines[0]);

            Graph g = new Graph(numVertices);

            List<List<int>> adjacencyList = new List<List<int>>();

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(' ');
                int startVertex = int.Parse(parts[0]);
                int endVertex = int.Parse(parts[1]);
                List<int> edge = new List<int> { startVertex, endVertex };
                adjacencyList.Add(edge);
            }

            for (int i = 0; i < adjacencyList.Count; i++)
            {
                g.addEdge(adjacencyList[i][0], adjacencyList[i][1]);
            }

            g.printSCCs();

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}",ts.Milliseconds);

            writer.WriteLine(elapsedTime);

            stopWatch.Reset();
        }
    }
}
