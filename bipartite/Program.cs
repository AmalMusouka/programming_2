using System;
using System.Text;
using static System.Text.StringBuilder;
using System.Collections.Generic;
class Program
{
    class IntList 
    {
        int[] a = new int[4];
        int count;

        public void append(int i) 
        {
            if (count == a.Length)
            {
                int[] b = new int[a.Length * 2];
                for (int j = 0; j < a.Length; ++j)
                    b[j] = a[j];
                a = b;
            }
            a[count++] = i;
        }

        public int length => count;

        public int this[int i] => a[i];
    }


    static void BFS(IntList[] graph, int start, int length)
    {
        Queue<int> queue = new Queue<int>();
        StringBuilder first = new StringBuilder();
        StringBuilder second = new StringBuilder();
        bool[] visited = new bool[length];
        bool[] group1 = new bool[length];
        bool[] group2 = new bool[length];
        int prev_w = 0;
        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            int v = queue.Dequeue();
            if (!group2[v])
            {
                group1[v] = true;
            }
            //Console.WriteLine("visiting" + v);
            for (int i = 0; i < graph[v].length; ++i)
            {
                int w = graph[v][i];
                if (!visited[w])
                {
                    visited[w] = true;
                    if (group1[v])
                    {
                        group2[w] = true;
                        if (w > prev_w)
                        {
                            second.Append(w + 1);
                            second.Append(" ");
                        }
                        else
                        {
                            second.Insert(0, w + 1);
                            second.Insert(1, " ");
                        }
                        
                        prev_w = w;
                    }
                    else
                    {
                        group1[w] = true;
                        first.Append(w + 1);
                        first.Append(" ");
                    }
                    queue.Enqueue(w);
                    //Console.WriteLine("Enqueuing city " + graph[v][i]);
                }
                else
                {
                    if (group1[w] && group1[v] || group2[v] && group2[w])
                    {
                        Console.WriteLine("Nelze");
                        return;
                    }
                    
                }
                
            }
        }
        Console.WriteLine(first);
        Console.WriteLine(second);
    }
    static void Main(string[] args)
    {
        int cities = int.Parse(Console.ReadLine());
        int roads = int.Parse(Console.ReadLine());
        IntList[] bipartite = new IntList[cities];
        for (int i = 0; i < cities; ++i)
        {
            bipartite[i] = new IntList();
        }

        for (int i = 0; i < roads; ++i)
        {
            string[] input = Console.ReadLine().Split(' ');
            int first = int.Parse(input[0]) - 1;
            int second = int.Parse(input[1]) - 1;
            
            /*
            if (first < 0 || first >= cities || second < 0 || second >= cities)
            {
                Console.WriteLine("error: city out of bounds");
                return;
            }
            */
            
            bipartite[first].append(second);
            bipartite[second].append(first);
        }
        /*for (int i = 0; i < cities; ++i)
        {
            Console.Write($"city {i + 1}: ");
            for (int j = 0; j < bipartite[i].length; ++j)
            {
                Console.Write(bipartite[i][j] + 1 + " "); // Convert back to 1-indexed for output
            }
            Console.WriteLine();
        }*/
        BFS(bipartite, 0,cities);
    }
}