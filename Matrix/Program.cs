using static System.Console;

class Program
{
    class Matrix
    {
        int size;
        int[,] matrix;

        public Matrix(int n)
        {
            size = n;
            matrix = new int[n, n];
        }

        public void read()
        {
            for (int i = 0; i < size; ++i)
            {
                string[] words = ReadLine()!.Trim().Split(null);
                if (words.Length != size)
                {
                    WriteLine("bad input");
                    return;
                }

                for (int j = 0; j < size; ++j)
                {
                    matrix[i, j] = int.Parse(words[j]);
                }
            }
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            Matrix c = new Matrix(a.size);
            for (int i = 0; i < c.size; ++i)
            {
                for (int j = 0; j < c.size; ++j)
                {
                    c.matrix[i, j] = a.matrix[i, j] + b.matrix[i, j];
                }
            }

            return c;
        }
        
        public static Matrix operator -(Matrix a, Matrix b)
        {
            Matrix c = new Matrix(a.size);
            for (int i = 0; i < c.size; ++i)
            {
                for (int j = 0; j < c.size; ++j)
                {
                    c.matrix[i, j] = a.matrix[i, j] - b.matrix[i, j];
                }
            }

            return c;
        }
        
        public static Matrix operator *(Matrix a, Matrix b)
        {
            Matrix c = new Matrix(a.size);
            for (int i = 0; i < c.size; ++i)
            {
                for (int j = 0; j < c.size; ++j)
                {
                    c.matrix[i, j] += a.matrix[j, i] * b.matrix[i, j];
                }
            }

            return c;
        }

        public void print()
        {
            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    Write($"{matrix[i, j]} ");
                }

                WriteLine();
            }
        }
    }


    public static string readPostfix(string expression)
    {
        string[] postfix = expression.Split(" ");
        string[] operators = ["+", "-", "*", "/"];
        string exp = "";
        Stack<string> toInfix = new Stack<string>();

        for (int i = 0; i < postfix.Length; ++i)
        {
            toInfix.Push(postfix[i]);
            if (operators.Contains(postfix[i]))
            {
                string op = toInfix.Pop();
                string val1 = toInfix.Pop();
                string val2 = toInfix.Pop();
                exp += " " + val2 + op + val1;
                toInfix.Push(exp);
                Console.WriteLine(exp);
            }
        }

        return toInfix.Pop();
    }
    

    static void Main(string[] args)
    {
       // string[] input= Console.ReadLine().Split(" ");
        //int matrixSize = int.Parse(input[0]);
        //int matrixNum = int.Parse(input[1]);

        string input = "a b c * d e - / +";
        Console.WriteLine(readPostfix(input));

    }
}