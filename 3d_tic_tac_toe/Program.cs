using System;

class TicTacToe
{
    static void Main()
    {
        string s = "";
        while (Console.ReadLine() is string line)
        {
            s += line;
        }

        char[] l = s.ToCharArray();
        char[] edge1 = new char[4] { l[0], l[1], l[2], l[3] };
        char[] edge2 = new char[4] { l[4], l[5], l[6], l[7] };
        char[] edge3 = new char[4] { l[8], l[9], l[10], l[11] };
        char[] edge4 = new char[4] { l[12], l[13], l[14], l[15] };
        
        
        Console.WriteLine(edge2);
    }
    
}