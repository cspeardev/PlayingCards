namespace CardsLibrary
{
    internal struct French52 : IDeckFormat
    {
        IEnumerable<Suit> IDeckFormat.Suits
        {
            get
            {
                return new List<Suit> { Suit.spades, Suit.clubs, Suit.hearts, Suit.diamonds };
            }
        }

        IEnumerable<Rank> IDeckFormat.Ranks
        {
            get
            {
                return new List<Rank> { Rank.ace, Rank.two, Rank.three, Rank.four, Rank.five, Rank.six, Rank.seven, Rank.eight, Rank.nine, Rank.ten, Rank.jack, Rank.queen, Rank.king };
            }
        }

        int IDeckFormat.JokerCount => 0;
    }
}
