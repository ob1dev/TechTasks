using DeckOfCards.Cards;
using DeckOfCards.Decks;
using System.Linq;
using Xunit;

namespace DeckOfCards.Tests
{
  public class Deck_ShuffleShould
  {
    [Fact]
    public void Return_True_Given_Empty_Deck()
    {
      // Arrange 
      var deck1 = new Deck(DeckType.Empty);
      var deck2 = new Deck(DeckType.Empty);

      // Act
      deck2.Shuffle();

      var cards1 = deck1.ToArray();
      var cards2 = deck2.ToArray();

      // Assert
      Assert.True(cards1.SequenceEqual(cards2));
    }

    [Fact]
    public void Return_False_Given_Ordered_Deck()
    {
      // Arrange 
      var deck1 = new Deck(DeckType.Ordered);
      var deck2 = new Deck(DeckType.Ordered);

      // Act
      deck2.Shuffle();

      var cards1 = deck1.ToArray();
      var cards2 = deck2.ToArray();

      // Assert
      Assert.False(cards1.SequenceEqual(cards2));
    }

    [Fact]
    public void Return_False_Given_Unordered_Deck()
    {
      // Arrange 
      var deck1 = new Deck(DeckType.Unordered);
      var deck2 = new Deck(DeckType.Unordered);

      // Act
      deck2.Shuffle();

      var cards1 = deck1.ToArray();
      var cards2 = deck2.ToArray();

      // Assert
      Assert.False(cards1.SequenceEqual(cards2));
    }

    [Fact]
    public void Return_False_Given_Ordered_And_Unordered_Deck()
    {
      // Arrange 
      var deck1 = new Deck(DeckType.Ordered);
      var deck2 = new Deck(DeckType.Unordered);

      var deck3 = new Deck(DeckType.Unordered);
      var deck4 = new Deck(DeckType.Ordered);

      // Act
      deck2.Shuffle();
      
      var cards1 = deck1.ToArray();
      var cards2 = deck2.ToArray();

      deck3.Shuffle();

      var cards3 = deck3.ToArray();
      var cards4 = deck4.ToArray();

      // Assert
      Assert.False(cards1.SequenceEqual(cards2));
      Assert.False(cards3.SequenceEqual(cards4));
    }

     [Fact]
    public void Return_False_Given_Cards()
    {
      // Arrange
      var cards1 = new[] { new Card(SuitType.Diamond, FaceType.Two),
                           new Card(SuitType.Spade, FaceType.Four),
                           new Card(SuitType.Heart, FaceType.Six),
                           new Card(SuitType.Club, FaceType.Eight),
                           new Card(SuitType.Diamond, FaceType.Ten),
                           new Card(SuitType.Spade, FaceType.Queen),
                           new Card(SuitType.Heart, FaceType.Six),
                           new Card(SuitType.Club, FaceType.Ace),
                         };
      var deck = new Deck(cards1);

      // Act
      deck.Shuffle();
      
      var cards2 = deck.ToArray();
      
      // Assert
      Assert.False(cards1.SequenceEqual(cards2));
    }
  }
}