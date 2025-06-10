using System;

class Program
{
    static public int max_palindrome = 0;
    static public int num_1 = 0;
    static public int num_2 = 0;
    
    static public void CheckPalindrome(int x, int y)
    {
        int digits;
        int value = 0;
        int num = x * y;

        while (num > 0)
        {
            digits = num % 10;
            value = value * 10 + digits;
            num /= 10;
        }

        if (value > max_palindrome)
        {
            max_palindrome = value;
            num_1 = x;
            num_2 = y;
        }
    }

    static public void LargestPalindrome()
    {
        for (int i = 99; i >= 0; i--)
        {
            for (int j = 99; j >= 0; j--)
            {
                CheckPalindrome(i, j);
            }
        }
        
        Console.WriteLine("Palindrome: " + max_palindrome);
        Console.WriteLine("Number: " + num_1);
        Console.WriteLine("Number: " + num_2);
    }

    static public bool ContainsString(string s, string t)
    {
        int upper_limit = t.Length;
        if (s[0..upper_limit] == t)
        {
            return true;
        }
        return false;
    }

    static public void SBeginsWithT(string s, string t)
    {
        if (t.Length > s.Length || !ContainsString(s, t))
        {
            Console.WriteLine(false);
        }
        else
        {
            Console.WriteLine(true);
        }
    }

    static public void Commas(string num)
    {
        string string_num = num;
        int x = string_num.Length;
        string final = "";
        
        for (int i = x - 1; i >= 0; i--)
        {
            if (((x - 1 - i) % 3 == 0) && ((x - 1 - i) > 0))
            {
                final =  string_num[x - 1 - i] + "," + final;
            }
            else
            {
                final = string_num[x - 1 - i] + final;
            }
        }
        Console.WriteLine(final);
    }

    static public void SortingTwoValue()
    {
        string sequence = Console.ReadLine();
        string[] str = new string[2];
        string num = "";
        int count = 0;
        int str_1 = 0;
        int str_2 = 0;
        string final_string_1 = "";
        string final_string_2 = "";

        for (int i = 0; i < sequence.Length; i++)
        {
            
            if (sequence[i] == ' ' || i == sequence.Length - 1)
            {
                if (num == str[0])
                {
                    num = "";
                    str_1++;
                }
                else
                {
                    if (count < 2)
                    {
                        str[count] = num;
                    }
                    count++;
                    num = "";
                    str_2++;
                }
                
            }
            else
            {
                num += sequence[i];
            }
        }

        for (int i = 0; i < str_1; i++)
        {
            final_string_1 += str[0] + " ";   
        }

        for (int i = 0; i < str_2; i++)
        {
            final_string_2 += str[1] + " ";
        }

        if (int.Parse(str[0]) > int.Parse(str[1]))
        {
            Console.WriteLine(final_string_2 + final_string_1);
        }
        else
        {
            Console.WriteLine(final_string_1 + final_string_2);
        }
    }
    
    static public void Main(string[] args)
    {
        long l = 256_256_256_256;
        Console.WriteLine((long) (byte) (int) l);
    }
    
}