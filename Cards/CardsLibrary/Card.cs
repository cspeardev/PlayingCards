using System;

namespace Cards
{
    public class Card
    {
        public Card(suit? Suit, rank Rank)
        {
            CardSuit = Suit;
            CardRank = Rank;
        }
        public enum suit
        {
            //French Suited
            hearts,
            spades,
            diamonds,
            clubs,
            //German suited
            bells,
            acorns,
            leaves,
            //Swiss suited
            shields,
            roses,
            //Spanish suited
            coins,
            cups

        }
        public enum color
        {
            red,
            black,
            blue
        }
        public enum rank
        {
            ace = 'A',
            two = 2,
            three = 3,
            four = 4,
            five = 5,
            six = 6,
            seven = 7,
            eight = 8,
            nine = 9,
            ten = 10,
            jack = 'J',
            queen = 'Q',
            king = 'K',
            joker
        }
        public color CardColor { get; }
        public rank CardRank { get; }
        public suit? CardSuit { get; }

        public string SVG { 
            get {
                //TODO: Complete 
                return null;
            } 
        }
        public bool IsFaceCard { get
            {
                if (CardRank.GetType() == typeof(int) || CardRank == rank.joker)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            } 
        }
        public override string ToString()
        {
            if(CardRank == Card.rank.joker)
            {
                return "Joker";
            }
            else
            {
                return String.Format("{0} of {1}", CardRank, CardSuit);
            }
        }


    }
}
