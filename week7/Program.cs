using Pos = (int x, int y);
using static System.Math;

int[] coins = [1, 2, 5, 10, 20];


void print(string s) => Console.WriteLine(s);

// Print all ways to form n using valid coins
void change(int n)
{
    Stack<int> nums = [];

    void go(int rem) // rem = remaining sum to make
    {
        if (rem == 0)
        {
            print(string.Join(" + ", nums));
        }
        else
        {
            foreach (int c in coins)
            {
                if (c <= rem)
                {
                    nums.Push(c);
                    go(rem - c);
                    nums.Pop();
                }
            }
        }
    }
     // Print all ways to form a sum of (rem), using coins whose value is <= (max)
    void maxGo(int rem, int max)
    {
        if (rem == 0)
        {
            print(string.Join(" + ", nums.Reverse()));
        }
        else
        {
            foreach (int c in coins)
            {
                if (c <= rem && c <= max)
                {
                    nums.Push(c);
                    maxGo(rem - c, c);
                    nums.Pop();
                }
            }
        }
    }

    maxGo(n, n);
}

void draw_board(int n, Stack<Pos> queens)
{
    for (int y = 0; y < n; ++y)
    {
        for (int x = 0; x < n; ++x)
        {
         Console.Write(queens.Contains((x, y)) ? "Q " : ". ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}
// Return true if queens at p and q attack each other.
bool attack(Pos p, Pos q) => p.x == q.x || p.y == q.y || Abs(p.x - q.x) == Abs(p.y - q.y);

void queens(int n)
{
    Stack<Pos> queens = [];

    void place(int y)
    {
        if (y == n)
        {
            draw_board(n, queens);
        }
        else
        {
            for (int x = 0; x < n; ++x)
            {
                if (!queens.Any(q => attack(q, (x, y))))
                {
                    queens.Push((x, y));
                    place(y + 1);
                    queens.Pop();
                }
            }
        }
    }
    place(0);
}


queens(int.Parse(args[0]));