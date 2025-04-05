using System;

class Program
{
    public class Card
    {
        private Dictionary<string, int>converter = new Dictionary<string, int>
        {
            {"A", 1}, {"2", 2}, {"3", 3}, {"4", 4}, {"5", 5},
            {"6", 6}

        };
        // 1 = Ace, 2 .. 10, 11 = Jack, 12 = Queen, 13 = King 
        public int rank;
        public char suit;

        public Card(string s)
        {
            string[] array = s.Split();
            rank = converter[array[0]];
            suit = char.Parse(array[1]);
        }

        static void Main(string[] args)
        {
            Card c = new Card("AC");
            Console.WriteLine($"rank = {c.rank}, suit = '{c.suit}'");
        }
    }
}