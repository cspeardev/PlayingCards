using CardsLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace CardsTests;

[TestClass]
public class CardTests
{
    [TestMethod]
    public void ShuffleTest()
    {
        Deck deck = new();
        for (int i = 0; i < 100000; i++)
        {
            Deck shuffledDeck = deck;
            var originalSequence = deck.Cards;
            shuffledDeck.Shuffle();
            if (shuffledDeck.Cards.SequenceEqual(originalSequence))
            {
                Assert.Fail();
            }
            deck.Shuffle();
        }
    }
    [TestMethod]
    public void SVGTest()
    {
        Deck deck = new();

        foreach(Card card in deck.Cards)
        {
            Assert.IsFalse(string.IsNullOrEmpty(card.SVG));
        }
    }
}
