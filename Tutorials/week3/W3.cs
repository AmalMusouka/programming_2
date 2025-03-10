using System;

// Dynamic Array //

class Week3
{
    class DynArray
    {
        private const int initialCapacity = 16;
        private int size;
        private int[] data;

        public DynArray()
        {
            size = 0;
            data = new int[initialCapacity];
        }

        public int Length() => size;

        private void Resize()
        {
            int[] newData = new int[data.Length * 2];
            for (int i = 0; i < data.Length; ++i)
            {
                newData[i] = data[i];
            }

            data = newData;
        }

        public void Append(int i)
        {
            if (size == data.Length)
            {
                Resize();
            }

            data[size++] = i;
        }

        public int Get(int index) => index >= size ? throw new IndexOutOfRangeException() : data[index];

        public void Set(int index, int value)
        {
            if (index >= size)
            {
                throw new IndexOutOfRangeException();
            }

            data[index] = value;
        }
    }
    
    // Implement a class Queue that works in O(1) for all cases

    class Queue
    {
        private class Node
        {
            public int Value;
            public Node? Next;

            public Node(int value, Node? next = null)
            {
                Value = value;
                Next = next;
            }
        }

        private Node? head;
        private Node? tail;

        public Queue()
        {
            head = tail = null;
        }

        public bool IsEmpty() => head == null;

        public void EnQueue(int i)
        {
            if (tail == null)
            {
                head = tail = new(i);
            }
            else
            {
                tail.Next = new(i);
                tail = tail.Next;
            }
        }

        public int DeQueue()
        {
            int i;
            if (TryDequeue(out i))
            {
                return i;
            }
            else
            {
                throw new InvalidOperationException();
            }

        }
        
        public bool TryDequeue(out int i)
        {
            if (head == null)
            {
                i = default;
                return false;
            }
            else
            {
                i = head.Value;
                head = head.Next;
                if (head == null)
                {
                    tail = null;
                }

                return true;
            }
        }
    }

    // Implement a Binary search tree

    class BinaryTree
    {
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

        private Node? root;
        private int size;

        public BinaryTree()
        {
            root = null;
            size = 0;
        }

        public int Size() => size;

        public bool Contains(int i)
        {
            Node? node = root;
            while (node != null)
            {
                if (node.Value == i)
                {
                    return true;
                }
                else if (i < node.Value)
                {
                    node = node.Left;
                }
                else
                {
                    node = node.Right;
                }
            }

            return false;
        }

        public void Insert(int i)
        {
            if (root == null)
            {
                root = new(i);
                size = 1;
                return;
            }

            Node? n = root;
            while (true)
            {
                if (i == n.Value)
                {
                    return;
                }
                else if (i < n.Value)
                {
                    if (n.Left == null)
                    {
                        n.Left = new(i);
                        size++;
                        return;
                    }
                    else
                    {
                        n = n.Left;
                    }
                }
                else
                {
                    if (n.Right == null)
                    {
                        n.Right = new(i);
                        size++;
                        return;
                    }
                    else
                    {
                        n = n.Right;
                    }
                }
            }
        }

            public int[] ToArray()
            {
                int[] array = new int[size];
                int index = 0;

                void Go(Node? n)
                {
                    if (n != null)
                    {
                        Go(n.Left);
                        array[index++] = n.Value;
                        Go(n.Right);
                    }
                }
                
                Go(root);
                return array;
            }
        }
    

    static void Main(string[] args)
    {
       // DynArray d = new();
       // d.Get(10);

       BinaryTree b = new();
       b.Insert(0);
       b.Insert(-10);
       b.Insert(20);
       b.Insert(10);
       foreach (int i in b.ToArray())
       {
           
       }
       
    }
}