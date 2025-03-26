using System;

class Program
{
    class Rectangle
    {
        public (int x, int y) p;
        public (int x, int y) q;

        public Rectangle((int, int) p, (int, int) q)
        {
            this.p = p;
            this.q = q;
        }

        public (int, int) upperLeft() => (p.x, p.y);

        public (int, int) upperRight() => (q.x, p.y);

        public (int, int) LowerLeft() => (p.x, q.y);
        public (int, int) lowerRight() => (q.x, q.y);
        public string str() => $"({p.x},{p.y}) - ({q.x},{q.y})";

        public int perimeter() => 2 * (Math.Abs(p.y - q.y) + Math.Abs(p.x - q.x));
        
        public int area() => Math.Abs(p.x - q.x) * Math.Abs(p.y - q.y);

        public bool contains(Rectangle r)
        {
            if (r.p.x < p.x) return false;
            return true;
        }

    }

    static void Main(string[] args)
    {
        Rectangle r = new Rectangle((2, 3), (8, 10));
        Rectangle s = new Rectangle((5, 5), (10, 7));
        Rectangle t = new Rectangle((2, 8), (3, 10));
        Rectangle u = new Rectangle((4, 6), (6, 8));

        Console.WriteLine(r.upperLeft());        // (2, 3)
        Console.WriteLine(r.lowerRight());       // (8, 10)
        Console.WriteLine(r.str());              // (2, 3) - (8, 10)
        Console.WriteLine(r.perimeter());
        Console.WriteLine(r.area());
    }
}