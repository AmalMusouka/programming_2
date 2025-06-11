using System.Runtime.InteropServices.Marshalling;

class Program
{
    static int[] coins = { 1, 2, 5, 10, 20, 50 };

    static void sum(int n)
    {
        Stack<int> nums = [];

        void go(int rem, int max)
        {
            if (rem == 0)
            {
                Console.WriteLine(string.Join(" + ", nums));
            }
            else
            {
                foreach (int coin in coins)
                {
                    if (coin <= rem && coin <= max)
                    {
                        nums.Push(coin);
                        go(rem - coin, coin);
                        nums.Pop();
                    }
                }
            }
        }

        go(n, n);
    }

    static void Permutations(string s)
    {
        Stack<char> letters = [];
        char[] chars = s.ToCharArray();

        void go()
        {
            if (letters.Count == s.Length)
            {
                Console.WriteLine(string.Join("", letters));
            }
            else
            {
                foreach (char c in chars)
                {
                    if (!letters.Contains(c))
                    {
                        letters.Push(c);
                        go();
                        letters.Pop();
                    }

                   
                }
            }
        }
        go();
    }

    static void Combinations(int[] a, int k)
    {
        Stack<int> nums = [];

        void go(int start)
        {
            if (nums.Count == k)
            {
                Console.WriteLine(string.Join(" ", nums.Reverse()));
            }
            else
            {
                for(int i = start; i < a.Length; i++)
                {
                    if (!nums.Contains(a[i]))
                    {
                        nums.Push(a[i]);
                        go(i + 1);
                        nums.Pop();
                    }
                }
            }
            
        }
        go(0);
    }

    static void Composition(int n)
    {
        int[] nums = new int[n];
        Stack<int> sums = new Stack<int>();

        for (int i = 0; i < n; i++)
        {
            nums[i] = i + 1;
        }

        void go()
        { 
            if (sums.Sum() == n)
            {
                Console.WriteLine(string.Join(" + ", sums));
            }
            else
            {
                foreach (int x in nums)
                {
                    if (sums.Sum() + x <= n)
                    {
                        sums.Push(x);
                        go();
                        sums.Pop();
                    }
                }
            }
        }
        go();
    }

    static void Partitions(int n)
    {
        int[] nums = new int[n];
        Stack<int> sums = new Stack<int>();

        for (int i = 0; i < n; i++)
        {
            nums[i] = i + 1;
        }

        void go(int start)
        { 
            if (sums.Sum() == n)
            {
                Console.WriteLine(string.Join(" + ", sums));
            }
            else
            {
                for (int i = start; i < nums.Length; i++)
                {
                    if (sums.Sum() + nums[i] <= n)
                    {
                        sums.Push(nums[i]);
                        go(i);
                        sums.Pop();
                    }
                }
            }
        }
        go(0);
    }

    static int fib_top_down(int n)
    {
        int[] cache = new int[n + 1];
        cache[1] = 1;
        cache[2] = 1;

        int f(int i)
        {
            if (cache[i] == 0)
            {
                cache[i] = f(i - 1) + f(i - 2);
            }
            return cache[i];
        }
        
        return f(n);
    }

    static int fib_bottom_up(int n)
    {
        int[] arr = new int[n + 1];
        arr[1] = 1;
        arr[2] = 1;

        for (int i = 3; i <= n; i++)
        {
            arr[i] = arr[i - 1] + arr[i - 2];
        }
        
        return arr[n];
    }
    
    
    static int[] prices = [0, 1, 5, 8, 9, 10, 17, 17, 20, 24, 30];

    static int profit(int n)
    {
        int best = 0;
        for (int i = 1; i <= n; i++)
        {
            best = Math.Max(best, prices[i] + profit(n - i));
        }
        return best;
    }

    static int profit_bottom_up(int n)
    {
        int[] best = new int[n + 1];

        for (int i = 0; i <= n; i++)
        {
            best[i] = 0;
            for (int j = i; j <= n; j++)
            {
                best[i] = Math.Max(best[i], prices[i] + best[i - j]);
            }
        }
        return best[n];
    }

    static (int, string) profit_bottom_up2(int n, int[] prices)
    {
        int[] best = new int[n + 1];
        string[] sizes = new string[n + 1];

        for (int i = 1; i <= n; i++)
        {
            best[i] = i;
            for (int j = i; j <= n; j++)
            {
                int p = prices[j] + best[i - j];
                if (p > best[i])
                {
                    best[i] = p;
                    sizes[i] = sizes[i - j] + i + " ";
                }
            }
        }
        
        return (best[n], sizes[n]);
    }

    static int ways_dp(int n)
    {
        int[] ways = new int[n + 1];
        
        ways[0] = 1;
        for (int i = 1; i <= n; i++)
        {
            int w = 0;
            foreach (int c in coins)
            {
                if (i - c >= 0)
                {
                    w += ways[i - c];
                }

                ways[i] = w;
            }
        }
        
        return ways[n];
    }

    static void garden(int n)
    {
        Stack<char> arr = new Stack<char>();

        void go(int start, bool allow_parsley)
        {
            if (start == 0)
            {
                Console.WriteLine(string.Join(" + ", arr));
            }
            else
            {
                arr.Push('C');
                go(start - 1, true);
                arr.Pop();
                if (allow_parsley)
                {
                    arr.Push('P');
                    go(start - 1, false);
                    arr.Pop();
                }
            }
            
   
        }
        go(n, true);
    }

    static int ways(int n)
    {
        int[] arr = new int[n + 1];
        arr[0] = 1;
        arr[1] = 2;

        for (int i = 2; i <= n; i++)
        {
            arr[i] = arr[i - 1] + arr[i - 2];
        }
        return arr[n];
    }


    static int smallest_coins(int[] coins, int sum)
    {
        int[] arr = new int[sum + 1];
        arr[0] = 0;

        for (int i = 1; i <= sum; i++)
        {
            arr[i] = -1;
            foreach (int coin in coins)
            {
                if (i - coin >= 0)
                {
                    if (arr[i] == -1 || arr[i - coin] + 1 < arr[i])
                    {
                        arr[i] = arr[i - coin] + 1;
                    }

                }
            }
        }

        return arr[sum];
    }
    
    static public int ClimbStairs(int n) 
    {
        int[] arr = new int[n + 1];
        int[] steps = [1, 2];
        arr[0] = 1;

        for (int i = 1; i <= n; ++i)
        {
            foreach (int step in steps)
            {
                if(i - step >= 0)
                {
                    arr[i] += arr[i - step];
                }
            }

        }
        
        return arr[n];
    }

    static public int MinCostClimbingStairs(int[] cost)
    {
        int[] arr_start_at_0 = new int[cost.Length];
        int[] steps = [1, 2];
        
        arr_start_at_0[0] = cost[0];
        arr_start_at_0[1] = cost[1];

        for (int i = 2; i < cost.Length; ++i)
        {
            arr_start_at_0[i] = cost[i] + Math.Min(arr_start_at_0[i - 1], arr_start_at_0[i - 2]);
        }
        
        return Math.Min(arr_start_at_0[cost.Length - 1], arr_start_at_0[cost.Length - 2]);
    }

    static public int Jumps(int[] steps)
    {
        int[] arr = new int[steps.Length + 1];
        int[] choices = new int[steps.Length + 1];
        arr[0] = 0;

        for (int i = steps.Length - 1; i >= 0; --i)
        {
            int best = int.MaxValue;
            int best_choice = -1;
            for (int j = 1; j <= steps[i]; ++j)
            {
                if (i + j > steps.Length)
                {
                    break;
                }
                best = Math.Min(best, steps[i + j]);
                best_choice = j;
            }
            steps[i] = best;
            choices[i] = best_choice;
        }

        return steps[0];
    }

    /*static public string longest_palindrome(string s)
    {
        string lps(int i, int j)
        {
            if (j <= i)
            {
                return s[i..(j + 1)];
            }
            else
            {
                if (j == i)
                {
                    
                }
            }
        }
    }*/


    static public int ways_to_run(int n)
    {
        int[,] arr = new int[n + 1, 4];
        int[] possible_moves = new int[] {1, 2, 3};
        arr[0, 0] = 1;

        
        for (int i = 1; i <= n; ++i)
        {
            foreach (int move in possible_moves)
            {
                for (int j = 0; j < 4; j++)
                {
                    if ((move == 1 && j == 1) || (move == 3 && j == 3))
                    {
                        continue;
                    }

                    if (i - move >= 0)
                    {
                        arr[i, move] += arr[i - move, j];
                    }
                }

            }
        }

        return arr[n, 1] + arr[n, 2] + arr[n, 3];
    }


    static public bool firstWins(int n, int a, int b)
    {
        int[] outcome = [1, -1];
        
        
    }
    
    
    static void Main(string[] args)
    {
        Console.WriteLine(ways_to_run(10));
    }
}