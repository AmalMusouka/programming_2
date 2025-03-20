using System;
using System.Collections.Generic;


class TypeSetting
{

    static List<string> SplitWords(string line)
    {
        List<string> words = [];
        string word = "";
        foreach (char c in line)
        {
            if (char.IsLetter(c))
            {
                word += c;
            }
            else
            {
                if (word != "")
                {
                    words.Add(word);
                    word = "";
                }
            }
        }

        return words;
    }

    static void PrintWords(List<string> words)
    {
        int outputLength = 0;
        string outputLine = "";
        foreach (string w in words)
        {
            if (outputLength + w.Length > 30)
            {
                Console.WriteLine(outputLine);
                outputLine = w + " ";
                outputLength = w.Length + 1;
            }
            else if (w.Length > 30)
            {
                Console.WriteLine(outputLine);
                Console.WriteLine(w);
                outputLength = 0;
                outputLine = "";
            }
            else
            {
                outputLine += w + " ";
                outputLength += w.Length + 1;
            }
        }
        Console.WriteLine(outputLine);
    }
    static void Main()
    {
        string para = "";
        while (Console.ReadLine() is string line)
        {
            para += line + " ";
        }
        List<string> words = SplitWords(para);
        PrintWords(words);
    }
}