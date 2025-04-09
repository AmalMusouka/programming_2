using System;
using System.Reflection.Emit;

class Program
{
    static long top_down_fib(long n)
    {
        long[] cache = new long[n + 1]; // cache

        long f(long i)
        {
            if (cache[i] == 0)
            {
                cache[i] = i < 3 ? 1 : f(i - 1) + f(i - 2);
            }

            return cache[i];
        }

        return f(n);
    }

    static long bottom_up_fib(long n) // more efficient and clear running time
    {
        long[] f = new long[n + 1];
        f[1] = f[2] = 1;
        for (long i = 3; i <= n; ++i)
        {
            f[i] = f[i - 1] + f[i - 2];
        }

        return f[n];
    }

    static int[] prices = [0, 1, 5, 8, 9, 10, 17, 17, 20, 24, 30];
    // given a rod of size n, return the maximum possible profit from cutting it and selling the pieces

    static int profit_naive(int n)
    {
        if (n == 0)
        {
            return 0;
        }

        int p = 0; //best profit so far
        for (int i = 0; i <= n; ++i)
        {
            p = Math.Max(p, prices[i] + profit_naive(n - i));
        }

        return p;
    }

    static int profit(int size)
    {
        int[] a = new int[size + 1];  // a[n] is solution for size n
        for (int n = 1; n <= size; ++n)
        {
            for (int i = 1; i <= n; ++i)
            {
                a[n] = Math.Max(a[n], prices[i] + a[n - i]);
            }
        }

        return a[size];
    }

    static (int, int[]) profit2(int size) // including the sizes to chop it into
    {
        int[] a = new int[size + 1];
        int[] cut = new int[size + 1]; // first chop to make for each size
        for (int n = 1; n <= size; ++n)
            //goal: compute a[n] and cut[n]
        {
            for (int i = 1; i <= n; ++i) // each chop size
            {
                int c = prices[i] + a[n - i];
                if (c > a[n]) // best so far
                {
                    a[n] = c;
                    cut[n] = i; // remember size to chop off
                }
            }
        }

        int profit = a[size];
            List<int> cuts = [];
            while (size > 0)
            {
                cuts.Add(cut[size]);
                size -= cut[size];
            }

            return (profit, cuts.ToArray());

    }

    public static int[] coins = [1, 2, 5, 7, 10, 20, 50];
    
    //Given n, return the number of ways to form it from Czech coins

    int ways_naive(int n)
    {
        if (n == 0)
        {
            return 1;
        }

        int w = 0;
        foreach (int c in coins)
        {
            if (c <= n)
            {
                w += ways_naive(n - c);
            }
        }

        return w;
    }

    static long ways(int sum)
    {
        long[] w = new long[sum + 1];
        w[0] = 1;

        for (int n = 1; n <= sum; ++n) // compute w[n] the num of ways to form the sum n
        {
            foreach (int c in coins)
            {
                if (c <= n)
                {
                    w[n] += w[n - c];
                }
            }
        }


        return w[sum];
    }
    
    
    static void Main(string[] args)
    {
        Console.WriteLine(ways(int.Parse(args[0])));
    }

}
