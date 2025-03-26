using System;
using System.Collections.Generic;

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
    
    public string str() => $"({p.x}, {p.y}) - ({q.x}, {q.y})";

    public int perimeter() => 2 * (Math.Abs(p.y - q.y) + Math.Abs(p.x - q.x));

    public int area() => Math.Abs(p.x - q.x) * Math.Abs(p.y - q.y);

    public bool contains(Rectangle rect)
    {
        if ((rect.p.x >= p.x) && (rect.p.y >= p.y) && (rect.q.x <= q.x) && (rect.q.y <= q.y))
        {
            return true;
        }

        return false;
    }

    public bool overlap(Rectangle rect)
    {
        if ((rect.p.x >= q.x) || (rect.q.x <= p.x) || (rect.p.y >= q.y) || (rect.q.y <= p.y))
        {
            return false;
        }

        return true;
    }

    public Rectangle intersect(Rectangle rect)
    {
        (int, int) newUpperLeft;
        (int, int) newLowerRight;
        int UpperLeftx;
        int UpperLefty;
        int LowerRightx;
        int LowerRighty;

        UpperLeftx = rect.p.x > p.x ? rect.p.x : p.x;
        UpperLefty = rect.p.y > p.y ? rect.p.y : p.y;
        LowerRightx = rect.q.x < q.x ? rect.q.x : q.x;
        LowerRighty = rect.q.y < q.y ? rect.q.y : q.y;

        newUpperLeft = (UpperLeftx, UpperLefty);
        newLowerRight = (LowerRightx, LowerRighty);

        return new Rectangle(newUpperLeft, newLowerRight);

    }

    /*static void Main(string[] args)
    {
        Rectangle r = new Rectangle((2, 3), (8, 10));
        Rectangle s = new Rectangle((5, 5), (10, 7));
        Rectangle t = new Rectangle((2, 8), (3, 10));
        Rectangle u = new Rectangle((4, 6), (6, 8));


        Console.WriteLine(r.overlap(s)); // True
        Console.WriteLine(s.overlap(t)); // False
        Console.WriteLine(t.overlap(r)); // True
        Console.WriteLine(u.overlap(s)); // True

    }*/
}
