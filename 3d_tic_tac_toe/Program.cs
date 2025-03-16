using System;
using System.Runtime.CompilerServices;

class TicTacToe
{
    static char[,,] ToMatrix(string s)
    {
        int rowCount = 4;
        int colCount = 4;
        int dimensions = 4;

        char[,,] arr = new char[dimensions, colCount, rowCount];

        int count = 0;

        for (int i = 0; i < dimensions; i++)
        {
            for (int j = 0; j < rowCount; j++)
            {
                for (int k = 0; k < colCount; k++)
                {
                    arr[i, j, k] = s[count];
                    count++;
                }
            }
        }

        return arr;
    }

    static bool checkMove(char[,,] matrix)
    {
        //check diagonals across the cube
        if (matrix[0, 0, 0] != '.' && matrix[0, 0, 0] == matrix[1, 1, 1] && matrix[1, 1, 1] == matrix[2, 2, 2] &&
            matrix[2, 2, 2] == matrix[3, 3, 3])
        {
            matrix[0, 0, 0] = matrix[1, 1, 1] = matrix[2, 2, 2] = matrix[3, 3, 3] = Char.ToUpper(matrix[0, 0, 0]);
            return true;
        }
        if (matrix[3, 0, 0] != '.' && matrix[3, 0, 0] == matrix[2, 1, 1] && matrix[2, 1, 1] == matrix[1, 2, 2] &&
            matrix[1, 2, 2] == matrix[0, 3, 3])
        {
            matrix[3, 0, 0] = matrix[2, 1, 1] = matrix[1, 2, 2] = matrix[0, 3, 3] = Char.ToUpper(matrix[3, 0, 0]);
            return true;
        }
        if (matrix[0, 0, 3] != '.' && matrix[0, 0, 3] == matrix[1, 1, 2] && matrix[1, 1, 2] == matrix[2, 2, 1] &&
            matrix[2, 2, 1] == matrix[3, 3, 0])
        {
            matrix[0, 0, 3] = matrix[1, 1, 2] = matrix[2, 2, 1] = matrix[3, 3, 0] = Char.ToUpper(matrix[0, 0, 3]);
            return true;
        }
        if (matrix[3, 0, 3] != '.' && matrix[3, 0, 3] == matrix[2, 1, 2] && matrix[2, 1, 2] == matrix[1, 2, 1] &&
            matrix[1, 2, 1] == matrix[0, 3, 0])
        {
            matrix[3, 0, 3] = matrix[2, 1, 2] = matrix[1, 2, 1] = matrix[0, 3, 0] = Char.ToUpper(matrix[3, 0, 3]);
            return true;
        }

        for (int i = 0; i < 4; i++)
        {
            //check diagonals from left to right across edges
            if (matrix[i, 0, 0] != '.' && matrix[i, 0, 0] == matrix[i, 1, 1] && matrix[i, 1, 1] == matrix[i, 2, 2] && matrix[i, 2, 2] == matrix[i, 3, 3])
            {
                matrix[i, 0, 0] = matrix[i, 1, 1] = matrix[i, 2, 2] = matrix[i, 3, 3] = Char.ToUpper(matrix[i, 0, 0]);
                return true;
            }
            //check diagonals from right to left across edges
            if (matrix[i, 0, 3] != '.' && matrix[i, 0, 3] == matrix[i, 1, 2] && matrix[i, 1, 2] == matrix[i, 2, 1] && matrix[i, 2, 1] == matrix[i, 3, 0])
            {
                matrix[i, 0, 3] = matrix[i, 1, 2] = matrix[i, 2, 1] = matrix[i, 3, 0] = Char.ToUpper(matrix[i, 0, 3]);
                return true;
            }
            //check diagonals from front to back across the cube(right to left)
            if (matrix[0, 0, i] != '.' && matrix[0, 0, i] == matrix[1, 1, i] && matrix[1, 1, i] == matrix[2, 2, i] && matrix[2, 2, i] == matrix[3, 3, i])
            {
                matrix[0, 0, i] = matrix[1, 1, i] = matrix[2, 2, i] = matrix[3, 3, i] = Char.ToUpper(matrix[0, 0, i]);
                return true;
            }
            //check diagonals from front to back across the cube(left to right)
            if (matrix[3, 0, i] != '.' && matrix[3, 0, i] == matrix[2, 1, i] && matrix[2, 1, i] == matrix[1, 2, i] && matrix[1, 2, i] == matrix[0, 3, i])
            {
                matrix[3, 0, i] = matrix[2, 1, i] = matrix[1, 2, i] = matrix[0, 3, i] = Char.ToUpper(matrix[3, 0, i]);
                return true;
            }
            //check diagonals on the top(left to right)
            if (matrix[3, i, 0] != '.' && matrix[3, i, 0] == matrix[2, i, 1] && matrix[2, i, 1] == matrix[1, i, 2] && matrix[1, i, 2] == matrix[0, i, 3])
            {
                matrix[3, i, 0] = matrix[2, i, 1] = matrix[1, i, 2] = matrix[0, i, 3] = Char.ToUpper(matrix[3, i, 0]);
                return true;
            }
            //check diagonals on the top(left to right)
            if (matrix[0, i, 0] != '.' && matrix[0, i, 0] == matrix[1, i, 1] && matrix[1, i, 1] == matrix[2, i, 2] && matrix[2, i, 2] == matrix[3, i, 3])
            {
                matrix[0, i, 0] = matrix[1, i, 1] = matrix[2, i, 2] = matrix[3, i, 3] = Char.ToUpper(matrix[0, i, 0]);
                return true;
            }
            for (int j = 0; j < 4; j++)
            {
                //check horizontal lines
                if (matrix[i, j, 0] != '.' && matrix[i, j, 0] == matrix[i, j, 1] && matrix[i, j, 1] == matrix[i, j, 2] && matrix[i, j, 2] == matrix[i, j, 3])
                {
                    matrix[i, j, 0] = matrix[i, j, 1] = matrix[i, j, 2] = matrix[i, j, 3] = Char.ToUpper(matrix[i, j, 0]);
                    return true;
                }
                //check horizontal lines across
                if (matrix[0, j, i] != '.' && matrix[0, j, i] == matrix[1, j, i] && matrix[1, j, i] == matrix[2, j, i] && matrix[2, j, i] == matrix[3, j, i])
                {
                    matrix[0, j, i] = matrix[1, j, i] = matrix[2, j, i] = matrix[3, j, i] = Char.ToUpper(matrix[0, j, i]);
                    return true;
                }
                //check vertical lines
                if (matrix[i, 0, j] != '.' && matrix[i, 0, j] == matrix[i, 1, j] && matrix[i, 1, j] == matrix[i, 2, j] && matrix[i, 2, j] == matrix[i, 3, j])
                {
                    matrix[i, 0, j] = matrix[i, 1, j] = matrix[i, 2, j] = matrix[i, 3, j] = Char.ToUpper(matrix[i, 0, j]);
                    return true;
                }
                
            }
            
        }
        return false;
    }
    static void Main()
    {
        string s = "";
        while (Console.ReadLine() is string line)
        {
            s += line;
        }

        char[,,] matrix = ToMatrix(s);
        if (checkMove(matrix))
        {
            string result = "";
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4; ++j)
                {
                    for (int k = 0; k < 4; ++k)
                    {
                        result += matrix[i, j, k];
                    }
                    
                    result += "\n";
                }
                if ( i < 3)
                {
                    result += "\n";
                };
            }
            
            Console.WriteLine(result);
        }
        else
        {
            Console.WriteLine("no winner");
        }

    }
    
}