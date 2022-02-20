namespace CardsLibrary;

public interface IDeckFormat
{
    public IEnumerable<Suit> Suits { get; }
    public IEnumerable<Rank> Ranks { get; }
    public int JokerCount { get; }

}
