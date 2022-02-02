using System;
using System.Xml;

namespace CardsLibrary;

public partial class Card : IEquatable<Card>
{
    private string cardSVG;
    public Card(Suit? Suit, Rank Rank)
    {
        CardSuit = Suit;
        CardRank = Rank;
        cardSVG = GenerateSVG();
    }
    public Color CardColor { get; }
    public Rank CardRank { get; }
    /// <summary>
    /// CardSuit will be null if rank is Joker
    /// </summary>
    public Suit? CardSuit { get; }

    public string SVG
    {
        get => cardSVG;
        private set => cardSVG = value;
    }

    public bool IsFaceCard
    {
        get
        {
            if (CardRank.GetType() == typeof(int) || CardRank == Rank.joker)
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
        if (CardRank == Rank.joker)
        {
            return "Joker";
        }
        else
        {
            return string.Format("{0} of {1}", CardRank, CardSuit);
        }
    }

    bool IEquatable<Card>.Equals(Card? other)
    {
        if (other == null) return false;
        if (ReferenceEquals(this, other)) return true;
        if (CardRank != other.CardRank) return false;
        if (CardSuit != other.CardSuit) return false;
        if (CardSuit != other.CardSuit) return false;

        return true;
    }

    private string GenerateSVG()
    {
        string cardSVG;

        XmlDocument xmlDoc = new XmlDocument();
        XmlDeclaration declaration = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", "yes");

        XmlElement root = xmlDoc.DocumentElement;
        xmlDoc.InsertBefore(declaration, root);

        XmlElement svgElement = xmlDoc.CreateElement("svg");

        svgElement.SetAttribute("xmlns", "http://www.w3.org/2000/svg");
        svgElement.SetAttribute("version", "1.1");

        XmlElement descElement = xmlDoc.CreateElement("desc");
        descElement.InnerText = ToString();

        xmlDoc.AppendChild(svgElement);

        cardSVG = xmlDoc.OuterXml;

        return cardSVG;
    }
}
