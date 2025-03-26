using System;

class Program
{
    static long GetClosestPerfectRoot(long square)
    {
        double x = Double.Ceiling(Math.Sqrt(square));
        double y = Double.Floor(Math.Sqrt(square));
        if (Math.Abs((x * x) - square) >= Math.Abs((y * y) - square))
        {
            return (long)y;
        }
        return (long)x;
    }
    static (long, long) GetCoords(long input)
    {
        long row = 0;
        long col = 0;
        
        long x = GetClosestPerfectRoot(input);
        long diff = Math.Abs(input - (x * x));

        if ((x * x) % 2 == 0)
        {
            if ((x * x) > input)
            {
                col = x - 1;
                row = diff;
            }
            else if ((x * x) == input)
            {
                col = x - 1;
                row = diff;
            }
            else
            {
                col = x;
                row = Math.Abs(diff - 1);
            }
        }
        else
        {
            if ((x * x) > input)
            {
                row = x - 1;
                col = diff;
            }
            else if ((x * x) == input)
            {
                row = x - 1;
                col = diff;
            }
            else
            {
                row = x;
                col = Math.Abs(diff - 1);
            }
        }

        return (row, col);
    }


    static void Main(string[] args)
    {
        while (Console.ReadLine() is string line)
        {
            long l = Int64.Parse(line.Replace("_", ""));
            (long, long) coords = GetCoords(l);
            Console.WriteLine($"{coords.Item1} {coords.Item2}");
        }

    }
}