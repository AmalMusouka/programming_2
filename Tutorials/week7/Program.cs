using System;

class Program
{
    static public void SubsetsPrefix(int n)
    {
        // void go(string prefix, int i)
        // {
        //     if (i > n)
        //     {
        //         Console.WriteLine("{" + prefix + "}");
        //     }
        //     else
        //     {
        //         go(prefix + i + " ", i + 1);
        //         go(prefix, i + 1);
        //     }
        // }
        // go(" ", 1);
        
        Stack<int> stack = new();

        void go(int i)
        {
            if (i > n)
            {
                Console.WriteLine("{" + string.Join(" ", stack.Reverse()) + "}");
            }
            else
            {
                go(i + 1);
                stack.Push(i);
                go(i + 1);
                stack.Pop();
            }
        }

        go(1);
    }

    static public void SubsetsArray(int n)
    {
        bool[] member = new bool[n];

        void go(int i)
        {
            if (i >= member.Length)
            {
                Console.Write("{");
                for (int j = 0; j < member.Length; ++j)
                {
                    if (member[j])
                    {
                        Console.Write($"{j + 1} ");
                    }
                }
                Console.WriteLine("}");
            }
            else
            {
                go(i + 1);
                member[i] = true;
                go(i + 1);
                member[i] = false;
            }
        }
        go(0);
    }

    static public void SubsetsDigits(int n)
    {
        for (int i = 0; i < 1 << n; ++i)
        {
            Console.Write("{");
            for (int bit = 0; bit < n; ++bit)
            {
                if ((i & (1 << bit)) != 0) //or right shift & mask
                {
                    Console.Write($"{bit + 1} ");
                }
            }

            Console.WriteLine("}");
        }
    }
    
    // Permutations //

    static public void Permutations(string s)
    {
        char[] permutation = new char[s.Length];

        void go(int i)
        {
            if (i >= s.Length)
            {
                Console.WriteLine(new string(permutation));
            }
            else
            {
                for (int j = 0; j < permutation.Length; ++j)
                {
                    if (permutation[j] != 0)
                    {
                        continue;
                    }

                    permutation[j] = s[i];
                    go(i + 1);
                    permutation[j] = (char)0;
                }
            }
        }
        go(0);
    }

    static public void Combinations(int[] a, int k)
    {
        if (k > a.Length)
        {
            return;
        }

        if (k == 0)
        {
            Console.WriteLine("[]");
            return;
        }

        int[] res = new int[k];

        void go(int i, int rem)
        {
            if (rem == 0)
            {
                Console.WriteLine("[" + string.Join(",", res.Select(x => x.ToString())) + "]");
            }
            else if (i < a.Length)
            {
                res[^rem] = a[i];
                go(i + 1, rem - 1);
                go(i + 1, rem);
            }
        }
        go(0, k);
    }
    
    
    
    

    static void Main(string[] args)
    {
        Permutations("cat");
    }
}