using System;

class Wheel
{

    static int GetOdds(int input)
    {
        int total = (input) + (input) + (input);
        int count = 0;
        int[] wheel = new int[3 * input];
        wheel[0] = 1;
        

        return wheel[0];
    }
    
    static int getGCD(int a, int b)
    {
        while (a != 0 && b != 0)
        {
            if (a > b)
                a %= b;
            else
                b %= a;
        }

        return a | b;
    }
    
    static void Main()
    { 
        int input = int.Parse(Console.ReadLine()!);
     int per_seq = (input + 1);
     int total_seq = per_seq * per_seq * per_seq;
     int res = GetOdds(input);
     Console.WriteLine(res);
     int x = getGCD(res, total_seq);
     res /= x;
     total_seq /= x;
     Console.WriteLine(res + "/" + total_seq);
     
     
    }
}