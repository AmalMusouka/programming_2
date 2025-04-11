using static System.Console;
using System.Collections.Generic;
using System.Linq;

class Program
{
    public class Matrix
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
            if (string.IsNullOrWhiteSpace(ReadLine())) {}
            
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
            
            for (int i = 0; i < a.size; ++i)
            {
                for (int j = 0; j < a.size; ++j)
                {
                    for (int k = 0; k < a.size; ++k)
                    {
                        c.matrix[i, j] += a.matrix[i, k] * b.matrix[k, j];
                    }
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


    public static Matrix doExpression(string str, Matrix a, Matrix b)
    {
        var operators = new Dictionary<string, Matrix>
        {
            { "+", a + b },
            { "-", a - b },
            { "*", a * b },
        };
        
        return operators[str];

    }

    public static void readPostfix(string expression, Matrix[] matrices)
    {
        string[] postfix = expression.Split(" ");
        string[] operators = ["+", "-", "*"];
        List<Matrix> matricesList = new List<Matrix>();
        for (int i = 0; i < matrices.Length; ++i)
        {
            matricesList.Add(matrices[i]);
        }
        
        
        
        Stack<string> toInfix = new Stack<string>();

        for (int i = 0; i < postfix.Length; ++i)
        {
            toInfix.Push(postfix[i]);
            if (operators.Contains(postfix[i]))
            {
                string op = toInfix.Pop();
                int matrix1 = int.Parse(toInfix.Pop()) - 1;
                int matrix2 = int.Parse(toInfix.Pop()) - 1;
                Matrix matrix3 = doExpression(op, matricesList[matrix2], matricesList[matrix1]);
                matricesList.Add(matrix3);
                toInfix.Push((matricesList.Count).ToString());
                
            }
        }

        matricesList[int.Parse(toInfix.Pop()) - 1].print();
    }
    

    static void Main(string[] args)
    {
        string[] input= ReadLine().Split(" ");
        int matrixSize = int.Parse(input[0]);
        int matrixNum = int.Parse(input[1]);
        Matrix[] matrices = new Matrix[matrixNum];

        for (int i = 0; i < matrixNum; ++i)
        {
            matrices[i] = new Matrix(matrixSize);
            matrices[i].read();
        }
        string exp = ReadLine();
        readPostfix(exp, matrices);

    }
}