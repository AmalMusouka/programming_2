using System;


class Program
{

    enum Suit
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    };

    class Card
    {
        public int rank;
        public Suit suit;

        public Card(int rank, Suit suit)
        {
            this.rank = rank;
            this.suit = suit;
        }

        public string Describe(int rank, Suit suit)
        {
            string rank_str = "";
            
            if (rank == 11)
            {
                rank_str = "Jack";
            }
            else if (rank == 12)
            {
                rank_str = "Queen";
            }
            else if (rank == 13)
            {
                rank_str = "King";
            }
            else if (rank == 1)
            {
                rank_str = "Ace";
            }
            else
            {
                rank_str = rank.ToString();
            }
            return (rank_str + " of " + suit);
        }
        
    }


    class Deck
    {
        public List<Card> cards;
        
        public Deck()
        {
            cards = new List<Card>();

            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                
                for (int i = 1; i <= 13; i++)
                {
                    cards.Add(new Card(i, suit));
                }
            }
        }

        public Card[] Deal(int n)
        {
            
            Random random = new Random();
            
            if (cards.Count < n)
            {
                return null;
            }
            
            for (int i = 0; i < n; i++)
            {
                cards.Remove(cards[random.Next(cards.Count)]);
            }
            
            return cards.ToArray();
        }
        
        public int Count() => cards.Count;
    }
    
    
    static void Main(string[] args)
    {
    }
}