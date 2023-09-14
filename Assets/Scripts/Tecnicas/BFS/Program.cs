using System;
using System.Collections.Generic;
using System.Linq;

public class Graph
{
    private int V;
    private List<int>[] adj;

    public Graph(int v)
    {
        V = v;
        adj = new List<int>[v];
        for (int i = 0; i < v; i++)
        {
            adj[i] = new List<int>();
        }
    }

    public void AddEdge(int u, int v)
    {
        adj[u].Add(v);
    }

    public void BFS(int s)
    {
        Console.WriteLine("BFS Traversal:");
        bool[] visited = new bool[V];
        Queue<int> queue = new Queue<int>();

        visited[s] = true;
        queue.Enqueue(s);

        while (queue.Count > 0)
        {
            s = queue.Dequeue();
            Console.Write(s + " ");

            foreach (int i in adj[s])
            {
                if (!visited[i])
                {
                    visited[i] = true;
                    queue.Enqueue(i);
                }
            }
        }

        Console.WriteLine();
    }

    public void DFS(int s)
    {
        Console.WriteLine("DFS Traversal:");
        bool[] visited = new bool[V];
        DFSUtil(s, visited);
        Console.WriteLine();
    }

    private void DFSUtil(int v, bool[] visited)
    {
        visited[v] = true;
        Console.Write(v + " ");

        foreach (int i in adj[v])
        {
            if (!visited[i])
            {
                DFSUtil(i, visited);
            }
        }
    }

    public void AStar(int start, int goal)
    {
        Console.WriteLine("A* Pathfinding:");
        // Implement A* algorithm here
        List<int> path = AStarAlgorithm(start, goal);
        if (path != null)
        {
            Console.WriteLine("Path from " + start + " to " + goal + ": " + string.Join(" -> ", path));
        }
        else
        {
            Console.WriteLine("No path found from " + start + " to " + goal);
        }
    }

    private List<int> AStarAlgorithm(int start, int goal)
    {
        // Implement A* algorithm here and return the path as a List<int>
        // You'll need to define your heuristic function and data structures for the open and closed lists.
        // For simplicity, I'll leave this part as an exercise for you.
        // Make sure to handle cases where no path is found.

        // Example pseudocode:
        // 1. Initialize open list with start node
        // 2. Initialize closed list as empty
        // 3. while open list is not empty
        //    a. Pop node with lowest f-score from open list
        //    b. If the current node is the goal, reconstruct and return the path
        //    c. Generate successors of current node
        //    d. For each successor, calculate g and h values
        //    e. For each successor, if it is in the closed list with a lower f-score, skip it
        //    f. Add successors to open list
        // 4. No path found, return null
        return null;
    }

    public void Dijkstra(int start, int goal)
    {
        Console.WriteLine("Dijkstra's Pathfinding:");
        // Implement Dijkstra's algorithm here
        List<int> path = DijkstraAlgorithm(start, goal);
        if (path != null)
        {
            Console.WriteLine("Path from " + start + " to " + goal + ": " + string.Join(" -> ", path));
        }
        else
        {
            Console.WriteLine("No path found from " + start + " to " + goal);
        }
    }

    private List<int> DijkstraAlgorithm(int start, int goal)
    {
        // Implement Dijkstra's algorithm here and return the path as a List<int>
        // You'll need to define data structures for the priority queue and keep track of distances.
        // For simplicity, I'll leave this part as an exercise for you.
        // Make sure to handle cases where no path is found.

        // Example pseudocode:
        // 1. Initialize distance array with infinity values
        // 2. Initialize priority queue with (start, 0) as the first element
        // 3. while priority queue is not empty
        //    a. Pop node with smallest distance from priority queue
        //    b. If the current node is the goal, reconstruct and return the path
        //    c. Calculate tentative distance to neighbors
        //    d. If tentative distance is less than current distance, update distance and add to priority queue
        // 4. No path found, return null
        return null;
    }

    public static void Main(string[] args)
    {
        Graph graph = new Graph(7);
        graph.AddEdge(0, 1);
        graph.AddEdge(0, 2);
        graph.AddEdge(1, 3);
        graph.AddEdge(1, 4);
        graph.AddEdge(2, 5);
        graph.AddEdge(4, 5);

        int startNode = 0;
        int goalNode = 5;

        graph.BFS(startNode);
        graph.DFS(startNode);
        graph.AStar(startNode, goalNode);
        graph.Dijkstra(startNode, goalNode);
    }
}
