// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;
using System.Collections.Generic;

class Graph
{
    private int V; // Número de vértices
    private List<int>[] adj; // Lista de adjacência

    public Graph(int v)
    {
        V = v;
        adj = new List<int>[v];
        for (int i = 0; i < v; ++i)
            adj[i] = new List<int>();
    }

    public void AddEdge(int v, int w)
    {
        adj[v].Add(w);
        adj[w].Add(v);
    }

    public void BFS(int startVertex)
    {
        bool[] visited = new bool[V];

        Queue<int> queue = new Queue<int>();

        visited[startVertex] = true;
        queue.Enqueue(startVertex);

        while (queue.Count != 0)
        {
            int currentVertex = queue.Dequeue();
            Console.Write(currentVertex + " ");

            foreach (int adjacentVertex in adj[currentVertex])
            {
                if (!visited[adjacentVertex])
                {
                    visited[adjacentVertex] = true;
                    queue.Enqueue(adjacentVertex);
                }
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        //Graph graph = new Graph(7);
        Graph graph = new Graph(7);
        graph.AddEdge(0, 1);
        graph.AddEdge(0, 2);
        graph.AddEdge(1, 3);
        graph.AddEdge(1, 4);
        graph.AddEdge(2, 5);
        //graph.AddEdge(2, 6);
        graph.AddEdge(4, 5);

        Console.WriteLine("Breadth-First Traversal (starting from vertex 0):");
        graph.BFS(0);
    }
}

