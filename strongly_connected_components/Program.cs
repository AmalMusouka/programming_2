using static System.Console;
using System.Collections.Generic;

class Program
{
    class Graph
    {
        static public int num;
        static public List<int>[] edge; // edge[v] is a list of vertices that v points to
        static public List<int>[] reverse; // reverse[v] is a list of vertices that point to v

        public Graph()
        {
            num = int.Parse(ReadLine()!);
            edge = new List<int>[num + 1];
            reverse = new List<int>[num + 1];
            for (int i = 1; i <= num; ++i)
            {
                edge[i] = new List<int>();
                reverse[i] = new List<int>();
            }

            while (ReadLine() is string s)
            {
                string[] words = s.Split();
                int from = int.Parse(words[0]), to = int.Parse(words[1]);
                edge[from].Add(to);
                reverse[to].Add(from);
            }
        }

        public List<List<int>> Algorithm()
        {
            bool[] visited = new bool[num + 1];
            Stack<int> stack = new Stack<int>();
            
            void DFS(int v)
            {
                visited[v] = true;
                foreach (int u in edge[v])
                {
                    if (!visited[u])
                        DFS(u);
                }
                stack.Push(v);
            }

            for (int i = 1; i <= num; ++i)
            {
                if (!visited[i])
                {
                    DFS(i);
                }
            }

            //DFS on the reversed graph
            visited = new bool[num + 1];
            List<List<int>> components = new List<List<int>>();

            void ReverseDFS(int v, List<int> components)
            {
                visited[v] = true;
                components.Add(v);
                foreach (int u in reverse[v])
                {
                    if (!visited[u])
                        ReverseDFS(u, components);
                }
            }

            while (stack.Count > 0)
            {
                int v = stack.Pop();
                if (!visited[v])
                {
                    List<int> component = new List<int>();
                    ReverseDFS(v, component);
                    components.Add(component);
                }
            }
            
            return components;
        }
    }



    public static void Main(string[] args)
    {
        Graph g = new Graph();
        List<List<int>> components = new List<List<int>>();
        components = g.Algorithm();

        for (int i = 0; i < components.Count; ++i)
        {
            for (int j = 0; j < components[i].Count; ++j)
            {
                Write(components[i][j] + " ");
            }
            WriteLine();
        }
    }
}
