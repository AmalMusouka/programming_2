using System.Numerics;

//count how many integers in the array a satisfy a condition

int count(int[] a, IntCondition cond)//Condition<int> cond
{
    int n = 0;
    foreach (int i in a)
    {
        if (cond(i))
        {
            n += 1;
        }
    }

    return n;
}

U[] map<T, U>(T[] a, Func<T, U> f)
{
    U[] b = new U[a.Length];
    for (int i = 0; i < a.Length; ++i)
    {
        b[i] = f(a[i]);
    }

    return b;
}


bool is_odd(int i) => i % 2 == 1;

//IntCondition c = is_odd;
//Console.WriteLine(c(4));

int[] a = [3, 4, 5, 6, 7];
Interval interv = new(5, 100);
Console.WriteLine(count(a, interv.contains));

delegate bool IntCondition(int i);//Condition<T>

class Interval
{
    private int low, high;

    public Interval(int low, int high)
    {
        this.low = low;
        this.high = high;
    }

    public bool contains(int i) => low <= i && i <= high;
}


//sum of numbers
T sum<T>(T[] a) where T : INumber<T>
{
    T s = T.Zero;
    foreach (T x in a)
    {
        s += x;
    }

    return s;
}

//write 'wc': word count

try
{
    int words = 0;
    foreach (string s in File.ReadLines(args[0]))
    {
        words += s.Split().Length;
    }

    Console.WriteLine($"{words:n0} words");
}
catch (IOException)
{
    Console.WriteLine("file not found");
}


// binary search tree class

class Node<T>
{
    public T val;
    public Node<T> left, right;

    public Node(T val, Node<T>? left, Node<T>? right)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

// a set of values of type T
class TreeSet<T> where T: IComparable<T>
{
    private Node<T>? root = null;

    bool contains(T x)
    {
        Node<T>? p = root;
        while (p != null)
        {
            int i = x.CompareTo(p.val);
            if (i < 0)
            {
                p = p.left;
            }
            else if (i > 0)
            {
                p = p.right;
            }
            else
            {
                return true;
            }

            return false;
        }
    }
} 