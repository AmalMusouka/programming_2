using System;

class Program
{
    static long Factorial(long n)
    {
        long result = 1;
        for (int i = 2; i <= n; ++i)
        {
            result *= i;
        }

        return result;
    }

    static long PermutationToNumber(int[] permutation_)
    {
        int[] permutation = [.. permutation_];
        long result = 0;

        for (int i = 0; i < permutation.Length; ++i)
        {
            long numBase = Factorial(permutation.Length - i - 1);
            int digit = permutation[i];
            result += (digit - 1) * numBase;

            for (int j = i + 1; j < permutation.Length; ++j)
            {
                if (permutation[j] > digit)
                {
                    permutation[j]--;
                }
            }

            return result;
        }

        static int[] NumberToPermutation(long index, int N)
        {
            List<int> available = Enumerable.Range(1, N).ToList();
            for (int i = 0; i < index; ++i)
            {   
                int radix = N - i - 1;
                long numBase = Factorial(radix);
                int digit = (int)(index / numBase);

                index %= numBase;
                permutation[i] = available[digit];
                available.RemoveAt(digit);
            }

        return permutation;
    }
        
        
    
    static void Main(string[] args)
    {
        
    }
}