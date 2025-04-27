using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    public record Treasure(string Name, int Weight, int Value);

    public static void Main(string[] args)
    {
        int maxWeight = int.Parse(Console.ReadLine()!);
        int totalTreasures = int.Parse(Console.ReadLine()!);
        (int, string) [,] ways = new (int, string)[totalTreasures + 1, maxWeight + 1];
        List<Treasure> treasures = new List<Treasure>();

        for (int i = 0; i < totalTreasures; i++)
        {
            string[] tokens = Console.ReadLine().Split(" ");
            treasures.Add(new Treasure(tokens[0], int.Parse(tokens[1]), int.Parse(tokens[2])));
        }
        

        for (int i = totalTreasures - 1; i >= 0; i--)
        {
            for (int j = 1; j <= maxWeight; j++)
            {
                
                (int, string) steal = (0, "");

                if (j - treasures[i].Weight >= 0)
                {
                    int val = treasures[i].Value + ways[i, j - treasures[i].Weight].Item1;
                    string gem = treasures[i].Name + " " + ways[i, j - treasures[i].Weight].Item2;
                    steal = (val, gem);

                }

                int notVal = ways[i + 1, j].Item1;
                string notGem = ways[i + 1, j].Item2;
                (int, string) notSteal = (notVal, notGem);

                if (steal.Item1 > notSteal.Item1)
                {
                    ways[i, j].Item1 = steal.Item1;
                    ways[i, j].Item2 += steal.Item2;
                }
                else
                {
                    ways[i, j].Item1 = notSteal.Item1;
                    ways[i, j].Item2 += notSteal.Item2;
                } 
            }
        }
        
        Console.WriteLine(ways[0, maxWeight].Item1);
        string[] output = ways[0, maxWeight].Item2.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        Dictionary<string, int> words = new Dictionary<string, int>();
        for (int i = 0; i < output.Length; i++)
        {
            if (words.ContainsKey(output[i]))
            {
                words[output[i]]++;
            }
            else
            {
                words.Add(output[i], 1);
            }
        }

        foreach (var word in words)
        {
            Console.WriteLine($"{word.Key} {word.Value}");
        }
        
    }
}