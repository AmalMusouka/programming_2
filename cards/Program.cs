using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Hand h = new Hand("10H 10S 7H 7S 2D");
        Hand g = new Hand("AS AD 7C 7H 8D");
        Console.WriteLine(h.compare(g));
    }
}
public class Card
{
    private Dictionary<string, int>converter = new Dictionary<string, int>
    {
        {"A", 1}, {"2", 2}, {"3", 3}, {"4", 4}, {"5", 5},
        {"6", 6}, {"7", 7}, {"8", 8}, {"9", 9}, {"10", 10}, 
        {"J", 11}, {"Q", 12}, {"K", 13}

    };
    // 1 = Ace, 2 .. 10, 11 = Jack, 12 = Queen, 13 = King 
    public int rank;
    public char suit;

    public Card(string s)
    {
        string[] array = s.Select(c => c.ToString()).ToArray();
        rank = array.Length > 2 ? converter[array[0] + array[1]] : converter[array[0]];
        suit = char.Parse(array[^1]);
    }
}

public class Hand
{
    public List<Card> cards;
    public Hand(string hand)
    {
        cards = hand.Split(' ').Select(c => new Card(c)).ToList();
        cards.Sort((a, b) =>
        {
            if (a.rank != 1 && b.rank != 1)
            {
                return b.rank - a.rank;
            }
            return a.rank - b.rank;
        });
    }
    public (int, int) mostFrequent()
    {
        int highestCount = 0;
        int count = 0;
        int mostFrequentRank = cards[0].rank;
        int currentRank = cards[0].rank;
        foreach (Card c in cards)
        {
            if (currentRank == c.rank)
            {
                count++;
            }
            else
            {
                count = 1;
            }

            if (count > highestCount)
            {
                highestCount = count;
                mostFrequentRank = currentRank;
            }
            currentRank = c.rank;
        }
        return (highestCount, mostFrequentRank);
    }
    public void display()
    {
        foreach (Card c in cards)
        {
            Console.WriteLine("{0} {1}", c.rank, c.suit);
        }
    }

    public int compare(Hand g)
    {
        (int, int) freq1 = mostFrequent();
        (int, int) freq2 = g.mostFrequent();
        if (freq1.Item1 > freq2.Item1)
        {
            return 1;
        }
        
        if (freq1.Item1 < freq2.Item1)
        {
            return -1;
        }
        
        if (freq1.Item2 > freq2.Item2)
        {
            if (freq2.Item2 == 1)
            {
                return -1;
            }

            return 1;
        }
        
        if (freq1.Item2 < freq2.Item2)
        {
            if (freq1.Item2 == 1)
            {
                return 1;
            }
            return -1;
        }
        
        return 0;
    }
}


