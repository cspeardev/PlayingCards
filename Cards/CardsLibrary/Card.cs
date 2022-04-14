using System.Xml;

namespace CardsLibrary;

public class Card : IEquatable<Card>, ICloneable
{
    private string cardSVG;
    private string SvgMeasurementUnit = "in";
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

    /// <summary>
    /// String of the card's graphical representation in SVG format
    /// </summary>
    public string SVG
    {
        get => cardSVG;
        private set => cardSVG = value;
    }

    public bool IsFaceCard
    {
        //TODO: Figure out how to better handle these, Aces are not face cards nor number cards
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

        decimal externalPadding = 0.2m;

        decimal svgHeight = 3.5m + (externalPadding*2);
        decimal svgWidth = 2.25m + externalPadding*2;
        decimal cardWidth = 2.25m;
        decimal cardHeight = 3.5m;
        decimal cardCornerLength = 0.11m;
        string cardBackgroundColor = "white";
        string cardStrokeColor = "black";
        decimal cardStrokeWidth = 0.015m;
        decimal rankX = (externalPadding + 0.1m);
        decimal rankY = (externalPadding + 0.1m);



        XmlDocument xmlDoc = new XmlDocument();
        XmlDeclaration declaration = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", "yes");

        XmlElement root = xmlDoc.DocumentElement;
        xmlDoc.InsertBefore(declaration, root);

        XmlElement svgElement = xmlDoc.CreateElement("svg");

        svgElement.SetAttribute("xmlns", "http://www.w3.org/2000/svg");
        svgElement.SetAttribute("version", "1.1");
        svgElement.SetAttribute("height", $"{svgHeight}{SvgMeasurementUnit}");
        svgElement.SetAttribute("width", $"{svgWidth}{SvgMeasurementUnit}");

        XmlElement descElement = xmlDoc.CreateElement("desc");
        descElement.InnerText = ToString();


        XmlElement cardBackgroundElement = xmlDoc.CreateElement("rect");
        cardBackgroundElement.SetAttribute("x", $"{externalPadding}{SvgMeasurementUnit}");
        cardBackgroundElement.SetAttribute("y", $"{externalPadding}{SvgMeasurementUnit}");
        cardBackgroundElement.SetAttribute("width", $"{cardWidth}{SvgMeasurementUnit}");
        cardBackgroundElement.SetAttribute("height", $"{cardHeight}{SvgMeasurementUnit}");
        cardBackgroundElement.SetAttribute("rx", $"{cardCornerLength}{SvgMeasurementUnit}");
        cardBackgroundElement.SetAttribute("ry", $"{cardCornerLength}{SvgMeasurementUnit}");
        cardBackgroundElement.SetAttribute("fill", cardBackgroundColor);
        cardBackgroundElement.SetAttribute("stroke", cardStrokeColor);
        cardBackgroundElement.SetAttribute("stroke-width", $"{cardStrokeWidth}{SvgMeasurementUnit}");


        XmlElement topRankElement = xmlDoc.CreateElement("text");

        string RankDisplayString = "";
        RankDisplayString = BuildRankString();

        topRankElement.InnerText = RankDisplayString;
        topRankElement.SetAttribute("font-size", $"0.3{SvgMeasurementUnit}");
        topRankElement.SetAttribute("font-family", "Arial");
        topRankElement.SetAttribute("fill", "black");
        topRankElement.SetAttribute("dominant-baseline", "hanging");
        topRankElement.SetAttribute("x", $"{rankX}{SvgMeasurementUnit}");
        topRankElement.SetAttribute("y", $"{rankY}{SvgMeasurementUnit}");
        XmlElement bottomRankElement = (XmlElement)topRankElement.Clone();



        bottomRankElement.InnerText = RankDisplayString;
        bottomRankElement.SetAttribute("transform", "scale (-1, -1)");
        bottomRankElement.SetAttribute("transform-origin", "center");


        svgElement.AppendChild(cardBackgroundElement);

        svgElement.AppendChild(topRankElement);
        svgElement.AppendChild(bottomRankElement);



        xmlDoc.AppendChild(svgElement);



        cardSVG = xmlDoc.OuterXml;

        return cardSVG;
    }

    private string BuildRankString()
    {
        string RankDisplayString;
        int RankValue = (int)CardRank;
        string charFromRank = char.ConvertFromUtf32(RankValue);
        if (char.IsLetter(Convert.ToChar(charFromRank)))
        {
            RankDisplayString = charFromRank;
        }
        else
        {
            RankDisplayString = RankValue.ToString();
        }
        return RankDisplayString;
    }

    public override bool Equals(object? obj)
    {
        return ((IEquatable<Card>)this).Equals(obj as Card);
    }

    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }

    public object Clone()
    {
        throw new NotImplementedException();
    }
}
