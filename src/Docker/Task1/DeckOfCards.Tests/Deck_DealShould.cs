using DeckOfCards.Cards;
using DeckOfCards.Decks;
using Xunit;

namespace DeckOfCards.Tests
{
  public class Deck_DealShould
  {
    [Fact]
    public void Return_Null()
    {
      // Arrange 
      var deck = new Deck(DeckType.Empty);

      // Act
      var actual = deck.Deal();

      // Assert
      Assert.Null(actual);
    }

    [Fact]
    public void Return_Null_Too()
    {
      // Arrange 
      var cards = new[] { new HeartCard(FaceType.Ten) };
      var deck = new Deck(cards);

      // Act
      _ = deck.Deal();
      var actual = deck.Deal();

      // Assert
      Assert.Null(actual);
    }

    [Fact]
    public void Return_2_Of_Spades()
    {
      // Arrange 
      var deck = new Deck(DeckType.Ordered);

      // Act
      var actual = deck.Deal();

      // Assert
      Assert.Equal("Two of Spades", actual.ToString());
    }

    [Fact]
    public void Return_10_Of_Heart()
    {
      // Arrange 
      var cards = new[] { new HeartCard(FaceType.Ten) };
      var deck = new Deck(cards);

      // Act
      var actual = deck.Deal();

      // Assert
      Assert.Equal("Ten of Hearts", actual.ToString());
    }

    [Fact]
    public void Return_Ace_Of_Diamonds()
    {
      // Arrange 
      var cards = new ICard[] { new DiamondCard(FaceType.Ace),
                                new SpadeCard(FaceType.Two),
                                new HeartCard(FaceType.Ten)
                              };
      var deck = new Deck(cards);

      // Act
      var actual = deck.Deal();

      // Assert
      Assert.Equal("Ace of Diamonds", actual.ToString());
    }
  }
}