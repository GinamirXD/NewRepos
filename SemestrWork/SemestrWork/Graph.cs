using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestrWork
{
    public class Graph
    {
        private int V; // No. of vertices
        private List<int>[] adj; // Adjacency List

        // Constructor
        Graph(int v)
        {
            V = v;
            adj = new List<int>[v];
            for (int i = 0; i < v; ++i)
                adj[i] = new List<int>();
        }

        // Function to add an edge into the graph
        void addEdge(int v, int w) { adj[v].Add(w); }

        // A recursive function to print DFS starting from v
        void DFSUtil(int v, bool[] visited)
        {

            // Mark the current node as visited and print it
            visited[v] = true;
            Console.Write(v + " ");

            // Recur for all the vertices adjacent to this
            // vertex
            List<int> i = adj[v];
            foreach (var n in i)
            {
                if (!visited[n])
                    DFSUtil(n, visited);
            }
        }

        // Function that returns reverse (or transpose) of this
        // graph
        Graph getTranspose()
        {
            Graph g = new Graph(V);
            for (int v = 0; v < V; v++)
            {

                // Recur for all the vertices adjacent to this
                // vertex
                foreach (int i in adj[v])
                    g.addEdge(i, v);
            }
            return g;
        }

        void fillOrder(int v, bool[] visited, Stack<int> stack)
        {
            // Mark the current node as visited and print it
            visited[v] = true;

            // Recur for all the vertices adjacent to this
            // vertex
            foreach (var n in adj[v])
            {
                if (!visited[n])
                    fillOrder(n, visited, stack);
            }
            // All vertices reachable from v are processed by
            // now, push v to Stack
            stack.Push(v);
        }

        // The main function that finds and prints all strongly
        // connected components
        void printSCCs()
        {
            Stack<int> stack = new Stack<int>();

            // Mark all the vertices as not visited (For first
            // DFS)
            var visited = new bool[V];

            // Fill vertices in stack according to their
            // finishing times
            for (int i = 0; i < V; i++)
                if (visited[i] == false)
                    fillOrder(i, visited, stack);

            // Create a reversed graph
            Graph gr = getTranspose();

            // Mark all the vertices as not visited (For second
            // DFS)
            for (int i = 0; i < V; i++)
                visited[i] = false;

            // Now process all vertices in order defined by
            // Stack
            while (stack.Count != 0)
            {

                // Pop a vertex from stack
                int v = stack.Pop();

                // Print Strongly connected component of the
                // popped vertex
                if (visited[v] == false)
                {
                    gr.DFSUtil(v, visited);
                    Console.WriteLine();
                }
            }
        }
    }
}
