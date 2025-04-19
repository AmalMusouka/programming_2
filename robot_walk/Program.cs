using System;
using System.Collections.Generic;


class Program
{
    static public float getProbability(List<List<float>> maze,int x, int y)
    {
        if (x == 0)
        {
            if (y == 0)
            {
                return (maze[x + 1][y] + maze[x][y + 1])/2;
            }

            if (y == maze[0].Count - 1)
            {
                return (maze[x][y - 1] + maze[x + 1][y])/2;
            }
            return (maze[x + 1][y] + maze[x][y - 1] + maze[x][y + 1])/3;
        }

        if (y == 0)
        {
            if (x == maze.Count - 1)
            {
                return (maze[x - 1][y] + maze[x][y + 1])/2;
            }
            return (maze[x - 1][y] + maze[x][y + 1] + maze[x + 1][y])/3;
        }

        if (x == maze.Count - 1)
        {
            if (y == maze[0].Count - 1)
            {
                return (maze[x - 1][y] + maze[x][y - 1])/2;
            }
            return (maze[x - 1][y] + maze[x][y - 1] + maze[x][y + 1])/3;
        }

        if (y == maze[0].Count - 1)
        {
            return (maze[x][y - 1] + maze[x - 1][y] + maze[x + 1][y])/3;
        }
        
        return (maze[x][y - 1] + maze[x - 1][y] + maze[x + 1][y] + maze[x][y + 1])/4;
    }
    
    
    static void Main(string[] args)
    {
        List<List<float>> maze = new List<List<float>>();
        List<(int, int)> hole = new List<(int, int)>();
        List<(int, int)> goal = new List<(int, int)>();
        int count = 0;
        
        while (Console.ReadLine() is string line)
        {
            
            List<float> probability = new List<float>(new float[line.Length]);
            
            for (int j = 0; j < line.Length; j++)
            {
                if (line[j] == '.')
                {
                    probability[j] = 0;
                }
                else if (line[j] == 'h')
                {
                    probability[j] = 0;
                    hole.Add((count, j));
                }
                else
                {
                    probability[j] = 1;
                    goal.Add((count , j));
                }
            }

            count++;
            maze.Add(probability);
        }


        float change = 1;
        
        while (change >= 0.000001)
        {
            change = 0;
            for (int i = 0; i < maze.Count; i++)
            {
                for (int j = 0; j < maze[0].Count; j++)
                {
                    if (!hole.Contains((i, j)) && !goal.Contains((i, j)))
                    {
                        float prev = maze[i][j];
                        maze[i][j] = getProbability(maze, i, j);
                        float curr_change = Math.Abs(maze[i][j] - prev);
                        
                        change = change < curr_change ? curr_change : change;
                    }

                }
                
            }
        }


        float prob = (float)Math.Round(maze[0][0], 3);
        Console.WriteLine("{0:0.000}", prob);
    }
}