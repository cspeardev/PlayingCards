namespace CardsLibrary;

public partial class Deck
{
    private static Random rnd = new();
    private List<Card> cards;

    public IList<Card> Cards { get => cards; }

    public Deck(Format DeckFormat = Format.French52, int Jokers = 0)
    {
        cards = new List<Card>();
        List<Card.Suit> DeckSuits = new();
        List<Card.Rank> DeckRanks = new();

        int jokerCount = 0;

        switch (DeckFormat)
        {
            case Format.French52:
                DeckSuits = new List<Card.Suit> { Card.Suit.clubs, Card.Suit.hearts, Card.Suit.spades, Card.Suit.diamonds };
                DeckRanks = new List<Card.Rank> { Card.Rank.ace, Card.Rank.two, Card.Rank.three, Card.Rank.four, Card.Rank.five, Card.Rank.six, Card.Rank.seven, Card.Rank.eight, Card.Rank.nine, Card.Rank.ten, Card.Rank.jack, Card.Rank.queen, Card.Rank.king };
                break;

        }


        foreach (Card.Suit s in DeckSuits)
        {
            foreach (Card.Rank r in DeckRanks)
            {
                Cards.Add(new Card(s, r));
            }
        }

        for (int i = 0; i < jokerCount; i++)
        {
            Cards.Add(new Card(null, Card.Rank.joker));
        }


        for (int i = 0; i < Jokers; i++) cards.Add(new Card(null, Card.Rank.joker));
    }

    /// <summary>
    /// Shuffles all cards in the deck.
    /// If the shuffle results in the cards being in the same order, will shuffle again.
    /// </summary>
    public void Shuffle()
    {
        var originalSequence = cards;
        do
        {
            cards = cards.OrderBy(c => rnd.Next()).ToList();
        } while (cards.SequenceEqual(originalSequence));

    }
}
