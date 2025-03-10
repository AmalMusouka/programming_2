using static System.Console;

class Program
{
    static bool Begins(string s, string t)
    {
        if (t == "")
        {
            return true;
        }

        if (t.Length > s.Length)
        {
            return false;
        }

        for (int i = 0; i < t.Length; ++i)
        {
            if (s[i] != t[i])
            {
                return false;
            }
        }
        return true;
    }

    static string AddCommas(string num)
    {
        string r = "";

        for (int i = 0; i < num.Length; ++i)
        {
            r += num[i];

            int index = num.Length - i - 1;
            if (index % 3 == 0 && index != 0)
            {
                r += ",";
            }
        }

        return r;
    }
    static void Main()
    {
//        string s = ReadLine()!
//        string t = ReadLine()!;
//        WriteLine(Begins(s, t));
//        WriteLine(AddCommas("10000"));
        string input = Console.ReadLine()!;
        string[] split = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        int? first = null;
        int firstCount = 0;
        int? second = null;
        int secondCount = 0;

        foreach (string s in split)
        {
            int i = int.Parse(s);
            if (first == null || first == i)
            {
                first = i;
                firstCount++;
            }
            else if (second == null || second == i)
            {
                second = i;
                secondCount++;
            }
            else
            {
                
            }
        }

        int? smaller = first < second ? first : second;
        int? larger = first < second ? second : first;
//        if (first > second)
//        {
//            (first, second, firstCount, secondCount) = (second, first, secondCount, firstCount);
//        }



    }
    
}