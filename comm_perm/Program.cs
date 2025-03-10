using System;

class Permutation
{

    static int[] FrequenceyList(string array)
    {
        int[] arr = new int[26];
        foreach (char c in array.ToCharArray())
        {
            arr[c % 'a'] += 1;
        }

        return arr;
    }

    static void Main()
    {
        string s = Console.ReadLine()!;
        string t = Console.ReadLine()!;
        

        string res = "";

        int[] freq_s = FrequenceyList(s);
        int[] freq_t = FrequenceyList(t);


        for (int i = 0; i < freq_s.Length; ++i)
        {
            if (freq_s[i] > 0 && freq_t[i] > 0)
            {
                if (freq_s[i] <= freq_t[i])
                {
                    for (int j = 0; j < freq_s[i]; ++j)
                    {
                        res += (char)('a' + i);
                    }
                }
                else
                {
                    for (int j = 0; j < freq_t[i]; ++j)
                    {
                        res += (char)('a' + i);
                    }
                }
            }
        }
        
        Console.WriteLine(res);
    }
    
}