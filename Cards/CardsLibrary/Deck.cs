using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards
{
    public class Deck
    {
        public enum format
        {
            Italian
        }
        private List<Card> cards;

        public List<Card> Cards { get => cards; set => cards = value; }

        public Deck(format DeckFormat = format.Italian, int Jokers = 0)
        {
            Cards = new List<Card>();
            List<Card.suit> DeckSuits = null;
            List<Card.rank> DeckRanks = null;

            switch (DeckFormat)
            {
                case format.Italian:
                    DeckSuits = new List<Card.suit> { Card.suit.clubs, Card.suit.hearts, Card.suit.spades, Card.suit.diamonds };
                    DeckRanks = new List<Card.rank> { Card.rank.ace, Card.rank.two, Card.rank.three, Card.rank.four, Card.rank.five, Card.rank.six, Card.rank.seven, Card.rank.eight, Card.rank.nine, Card.rank.ten, Card.rank.jack, Card.rank.queen, Card.rank.king };
                    break;

            }


            foreach (Card.suit s in DeckSuits)
            {
                foreach (Card.rank r in DeckRanks)
                {
                    Cards.Add(new Card(s, r));
                }
            }

            for (int i = 0;i < Jokers; i++) cards.Add(new Card(null, Card.rank.joker));
        }
    }
}
