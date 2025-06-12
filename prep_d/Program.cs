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
                for (int i = start; i < a.Length; i++)
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
                if (i - step >= 0)
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
        int[] possible_moves = new int[] { 1, 2, 3 };
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
        int[] arr = [1, a, b];
        Stack<int> winners = new Stack<int>();

        void go(int player, int next_player, int num)
        {
            if (num == 0)
            {
                winners.Push(player);
            }
            else if (num > 0)
            {
                foreach (int stone in arr)
                {
                    if (stone != next_player)
                    {
                        go(next_player, player, num - stone);

                    }
                }
            }
        }

        go(a, b, n);
        if (winners.Contains(b))
        {
            return true;
        }

        return false;
    }


    static public bool Wins(int[] arr)
    {
        bool firstwins = true;

        bool go(int player, bool firstplayer, int num)
        {
            if (player >= num)
            {
                return !firstplayer;
            }

            int[] temp = [1, arr[player]];

            foreach (int square in temp)
            {
                bool result = go(player + square, !firstplayer, num);

                if (result && firstplayer)
                {
                    return true;
                }

                if (!firstplayer && !result)
                {
                    return false;
                }
            }


            return !firstplayer;
        }

        return go(0, true, arr.Length);
    }

    static public void thief(string s)
    {
        //string input = Console.ReadLine();
        int[] arr = s.Split(' ').Select(int.Parse).ToArray();
        int[] houses = new int[arr.Length];
        int[] max = new int[arr.Length];
        max[0] = arr[0];
        max[1] = Math.Max(arr[0], arr[1]);
        Stack<int> sums = new Stack<int>();
        sums.Push(Math.Max(arr[0], arr[1]));
        sums.Push(0);


        for (int i = 2; i < arr.Length; ++i)
        {
            max[i] = Math.Max(max[i - 2] + arr[i], max[i - 1]);
            if (max[i] != max[i - 1] && max[i] - arr[i] != max[i - 1])
            {
                sums.Push(arr[i]);
            }
            else
            {
                sums.Push(0);
            }
        }

        Console.Write("total loot = ");
        Console.Write(max[arr.Length - 1]);
        Console.WriteLine();
        Console.Write("houses: ");
        int c = sums.Count;
        for (int i = 0; i < c; ++i)
        {
            Console.Write(sums.Pop() + " ");
        }

    }

    public class Box
    {
        public int width, depth, height;

        public Box(int width, int depth, int height)
        {
            this.width = width;
            this.depth = depth;
            this.height = height;
        }



    }

    public static int maxHeight(Box[] b)
    {
        int[] max = new int[b.Length];
        int last_index = 0;

        for (int i = 0; i < b.Length; ++i)
        {
            max[i] = b[i].height;
        }

        for (int i = 1; i < b.Length; ++i)
        {
            for (int j = 0; j < i; ++j)
            {
                if (b[j].width > b[i].width && b[j].depth > b[i].depth)
                {
                    max[i] = Math.Max(max[j] + b[i].height, max[i]);
                }
            }
        }

        return max[b.Length - 1];
    }

    public static int min()
    {
        int[,] arr =
        {
            { 2, 3, 6, 2, 0, 6 },
            { 2, 1, 1, 3, 1, 4 },
            { 1, 6, 3, 3, 1, 5 },
            { 2, 5, 8, 1, 3, 2 }
        };

        int row = arr.GetLength(0);
        int col = arr.GetLength(1);
        int[,] minimizer = new int[row + 1, col + 1];

        for (int i = 0; i < row; ++i)
        {
            for (int j = 0; j < col; ++j)
            {
                minimizer[i, j] = arr[i, j];
            }
        }

        for (int i = 0; i < row + 1; ++i)
        {
            minimizer[i, col] = int.MaxValue;
        }

        for (int j = 0; j < col + 1; ++j)
        {
            minimizer[row, j] = int.MaxValue;
        }

        minimizer[row, col - 1] = 0;

        for (int i = row - 1; i >= 0; --i)
        {
            for (int j = col - 1; j >= 0; --j)
            {
                int minimum = Math.Min(minimizer[i + 1, j], minimizer[i, j + 1]);
                minimizer[i, j] += minimum;
            }
        }

        return minimizer[0, 0];
    }

    public static int max()
    {
        int[,] arr =
        {
            { 2, 3, 2, 5, 4 },
            { 4, 2, 5, 3, 1 },
            { 0, 3, 4, 1, 6 },
            { 5, 2, 0, 3, 2 },
            { 2, 3, 2, 3, 1 }
        };

        int row = arr.GetLength(0);
        int col = arr.GetLength(1);
        int[,] maximizer = new int[row + 1, col + 1];

        for (int i = 0; i < row; ++i)
        {
            for (int j = 0; j < col; ++j)
            {
                maximizer[i, j] = arr[i, j];
            }
        }

        for (int i = 0; i < row + 1; ++i)
        {
            maximizer[i, col] = int.MinValue;
        }

        for (int j = 0; j < col + 1; ++j)
        {
            maximizer[row, j] = 0;
        }


        for (int i = row - 1; i >= 0; --i)
        {
            for (int j = col - 1; j >= 0; --j)
            {
                int maximum;
                if (j > 0)
                {
                    maximum = Math.Max(maximizer[i + 1, j + 1],
                        Math.Max(maximizer[i + 1, j - 1], maximizer[i + 1, j]));
                }
                else
                {
                    maximum = Math.Max(maximizer[i + 1, j], maximizer[i + 1, j + 1]);
                }

                maximizer[i, j] += maximum;
            }
        }

        int highest = 0;
        for (int i = 0; i < col; ++i)
        {
            highest = Math.Max(highest, maximizer[0, i]);
        }

        return highest;
    }

    public static void derange(string str)
    {
        void go(string s, string t)
        {
            if (s.Length == 0)
            {
                Console.WriteLine(t);
                return;
            }

            for (int i = 0; i < s.Length; ++i)
            {
                char ch = s[i];

                if (ch == str[t.Length])
                {
                    continue;
                }

                go(s.Remove(i, 1), t + ch);

            }

        }

        go(str, "");
    }

    public static bool coin_game(int m)
    {
        int[] arr = new int[m];
        for (int i = 0; i < m; ++i)
        {
            arr[i] = i + 1;
        }

        bool go(int coin)
        {
            if (coin <= 2)
            {
                return false;
            }

            foreach (int c in arr)
            {
                if (c == 0)
                {
                    continue;
                }

                if (coin - c != c && coin - c > 0 && coin - c > 1)
                {
                    if (!go(coin - c))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        return go(m);


    }
    

    static void Main(string[] args)
    {
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"Coins={i}, First player wins? {coin_game(i)}");
        }
    }
}