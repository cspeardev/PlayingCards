using System.Runtime.InteropServices;

namespace CardsLibrary;

public class Deck
{
    private static Random rnd = new();
    private List<Card> cards;

    public IList<Card> Cards { get => cards; }

    public Deck([Optional]IDeckFormat DeckFormat)
    {
        if (DeckFormat == null)
        {
            DeckFormat = new French52();
        }
        cards = new List<Card>();

        foreach (Suit s in DeckFormat.Suits)
        {
            foreach (Rank r in DeckFormat.Ranks)
            {
                Cards.Add(new Card(s, r));
            }
        }

        for (int i = 0; i < DeckFormat.JokerCount; i++)
        {
            Cards.Add(new Card(null, Rank.joker));
        }
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
