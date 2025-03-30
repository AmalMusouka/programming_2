using System;
using static System.Console;
using System.Collections.Generic;
class Program
{
    class Graph {
        
        static public int num;
        static public int[][] edge;
        public Graph() 
        {
            num = int.Parse(ReadLine()!);
            edge = new int[num + 1][];      // 1 .. num
        
            for (int i = 1 ; i <= num ; ++i) 
            {
                string[] words = ReadLine()!.Trim().Split(null);
                int m = int.Parse(words[0]);
                if (words.Length != m + 1)
                {
                    throw new Exception("bad input");
                }

                edge[i] = new int[m];
                for (int j = 0; j < m; ++j)
                {
                    edge[i][j] = int.Parse(words[j + 1]);
                }
            }
        }
        
       static public void DFS()
        {
            int[] visited = new int[num + 1]; // 0: white, 1: grey, 2: black
            int[] parent = new int[num + 1]; 
            int cycleStart = -1;
            int cycleEnd = -1;
            
            void Visit(int v)
            {
                visited[v] = 1;
                foreach (int j in edge[v])
                {
                    if (visited[j] == 0)
                    {
                        parent[j] = v;
                        Visit(j);
                        if (cycleStart != -1) 
                        {
                            break;
                        }
                    }
                    else if (visited[j] == 1) 
                    {
                        cycleStart = j;
                        cycleEnd = v;
                        return;
                    }
                }

                visited[v] = 2;
            }
            for (int i = 1; i <= num; ++i)
            {
                if (visited[i] == 0)
                {
                    Visit(i);
                    if (cycleStart != -1) 
                    {
                        break;
                    }
                }
            }
            if (cycleStart == -1)
            {
                WriteLine("neni"); // No cycle
            }
            else
            {
                int count = 0;
                List<int> cycles = new List<int>();
                cycles.Add(cycleStart);
                count += 1;
                int current = cycleEnd;

                while (current != cycleStart)
                {
                    cycles.Add(current);
                    count += 1;
                    current = parent[current];
                }
                WriteLine(count);
                for (int i = 0; i < count; ++i)
                {
                    Write(cycles[i] + " ");
                }

            }
        }
    }

    static void Main(string[] args)
    {
        Graph g = new Graph();
        Graph.DFS();
    }
}
    