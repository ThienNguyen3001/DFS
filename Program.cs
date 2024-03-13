using System;
using System.Collections.Generic;

class Graph
{
    private Dictionary<int, List<int>> graph; 
    public List<int> path;
    public Graph()
    {
        graph = new Dictionary<int, List<int>>();
    }

    public void AddEdge(int v, int w)
    {
        if (!graph.ContainsKey(v))
        {
            graph[v] = new List<int>();
        }
        if (!graph.ContainsKey(w))
        {
            graph[w] = new List<int>();
        }
        graph[v].Add(w);
        graph[w].Add(v);
    }
    void InStack(Stack<int> st)
    {
        Console.Write("Stack hien tai la: ");
        foreach (var i in st)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();
    }
    public void DFS(int from)
    {
        HashSet<int> visited = new HashSet<int>();
        Stack<int> stack = new Stack<int>();

        stack.Push(from);

        Console.WriteLine($"Them {from} vao stack");
        InStack(stack);

        while (stack.Count > 0)
        {
            int currentVertex = stack.Pop();
            Console.WriteLine($"Rut {currentVertex} khoi stack");

            InStack(stack);
            Console.WriteLine();
            visited.Add(currentVertex);
           
            foreach (int neighbor in graph[currentVertex])
            {
                if (!visited.Contains(neighbor))
                {
                    Console.WriteLine($"Them {neighbor} vao stack");
                    stack.Push(neighbor);
                    visited.Add(neighbor);
                    InStack(stack);
                }
            }
        }

    }

    public static void Main(string[] args)
    {
        Graph g = new Graph();

        g.AddEdge(0, 1);
        g.AddEdge(0, 2);
        g.AddEdge(0, 3);
        g.AddEdge(1, 4);
        g.AddEdge(1, 5);
        g.AddEdge(2, 5);
        g.DFS(0);
    }
}
