using System;
using System.Collections.Generic;

class Program
{

    static string getAutomata(int wolfram)
    {
        string binary = Convert.ToString(wolfram, 2);
        while (binary.Length < 8)
        {
            binary = "0" + binary;
        }
        
        return binary;
    }

    static string toInt(string wolfram)
    {
        string integers = "";
        int i = 0;
        while (i < wolfram.Length)
        {
            if (wolfram[i] == 'x')
            {
                integers += "1";
            }
            else
            {
                integers += "0";   
            }
            ++i;
        }
        return integers;
    }

    static string toStr(char integer)
    {
        if (integer == '1')
        {
            return "x";
        }

        return "-";
    }

    static string generateAutomata(string input, string wolfram)
    {
        int i = 0;
        string output = "";
        
        while (i < input.Length)
        {
            string neighbors = input[(i - 1 + input.Length) % input.Length].ToString() + input[i].ToString() + input[(i + 1) % input.Length].ToString();
            string intNeighbors = toInt(neighbors);
            int binary = Convert.ToInt32(intNeighbors, 2);
            output += toStr(wolfram[7 - binary]);
            ++i;
        }
        return output;
    }
    
    static void Main(string[] args)
    {
        int wolfram = int.Parse(Console.ReadLine());
        string binary = getAutomata(wolfram);
        int simulations = int.Parse(Console.ReadLine());
        string automaton = Console.ReadLine();

        bool write = true;
        bool first = true;

        int counter = 0;
        
        while (counter < simulations)
        {
            automaton = generateAutomata(automaton, binary);
            if ((counter >= 20 && simulations > 40) && first)
            {
                Console.WriteLine("...");
                write = false;
                first = false;
            }
            
            if (counter == simulations - 20)
            {
                write = true;
            }

            if (write)
            {
                Console.WriteLine(automaton);
            }
            counter++;
        }
    }
}