class Time
{
    private int n;

    public Time(int h, int m, int s)
    {
        n = h * 3600 + m * 60 + s;
    }

    Time(int n)
    {
        this.n = n;
    }

    public int hours => n / 3600;

    public int minutes => (n / 60) % 60;

    public int seconds => n % 60;

    public static Time operator +(Time t, int delta)
    {

    }

    // Tree Check for bst
    
    private class Node
    {
        public int Value;
        public Node? Left;
        public Node? Right;

        public Node(int value, Node? left = null, Node? right = null)
        {
            Value = value;
            Left = left;
            Right = right;
        }
    }
    
    public bool IsBst()
    {
        bool isBst = true;
        int? lastVisited = null;

        void Go(Node? n)
        {
            if (n != null)
            {
                Go(n.left);
                if (lastVisited != null && n.Value <= lastVisited)
                {
                    isBst = false;
                }

                lastVisited = n.Value;
                Go(n.Right);
            }
        }

        Go(root);
        return isBst;
    }



        
    
}