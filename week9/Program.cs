using System;

class Program
{
    static public string LCS(string a, string b)
    {
        string[,] common = new string[a.Length + 1, b.Length + 1];
        // common[i, j] = s <=> s is the longest common subsequence of a[0..i] and b[0..i]

        for (int i = 0; i <= a.Length; i++)
        {
            common[i, 0] = "";
        }
        for (int j = 0; j <= a.Length; j++)
        {
            common[0, j] = "";
        }

        for (int i = 1; i <= a.Length; i++)
        {
            for (int j = 1; j <= b.Length; j++)
            {
                if (a[i - 1] == b[j - 1])
                {
                    common[i, j] = common[i - 1, j - 1] + a[i - 1];
                }
                else
                {
                    {
                        string common_a = common[i - 1, j]; //hiding the last of the first string
                        string common_b = common[i, j - 1];
                        common[i, j] = common_a.Length > common_b.Length ? common_a : common_b;
                    }
                }
            }
        }

        return common[a.Length, b.Length];
    }

    static int MinAttempts(int floors, int eggs)
    {
        int go(int floors, int eggs)
        {
            if (floors == 0)
            {
                return 0;
            }

            if (eggs == 0)
            {
                return int.MaxValue;
            }

            if (floors == 1)
            {
                return 1;
            }

            if (eggs == 1)
            {
                return floors;
            }

            int result = int.MaxValue;
            for (int floor = 1; floor <= floors; floor++)
            {
                int if_breaks = go(floor - 1, eggs - 1);
                int if_survives = go(floors - floor, eggs);
                int candidate = Math.Max(if_breaks, if_survives);
                if (candidate < result)
                {
                    result = candidate;
                }
            }

            return result + 1;

        }

        return go(floors, eggs);
    }

    static int MinAttemptDP(int floors, int eggs)
    {
        Dictionary<(int floors, int eggs), (int result, int floor)> memo = new();
        
        int go(int floors, int eggs)
        {
            if (floors == 0)
            {
                return 0;
            }

            if (eggs == 0)
            {
                return int.MaxValue;
            }

            if (floors == 1)
            {
                return 1;
            }

            if (eggs == 1)
            {
                return floors;
            }

            var key = (floors, eggs);
            if (memo.TryGetValue(key, out(int, int) val))
            {
                return val.Item1;
            }

            int result = int.MaxValue;
            int bestFloor = -1;
            for (int floor = 1; floor <= floors; floor++)
            {
                int if_breaks = go(floor - 1, eggs - 1);
                int if_survives = go(floors - floor, eggs);
                int candidate = Math.Max(if_breaks, if_survives);
                if (candidate < result)
                {
                    result = candidate;
                    bestFloor = floor;
                }
            }

            memo[key] = (result + 1, bestFloor);
            return result + 1;

        }

        return go(floors, eggs);
        
    }

    static void Main(string[] args)
    {
        Console.WriteLine(LCS("hello", "hall"));
    }
}