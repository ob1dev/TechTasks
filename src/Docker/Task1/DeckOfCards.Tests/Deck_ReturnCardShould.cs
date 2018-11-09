using DeckOfCards.Cards;
using DeckOfCards.Decks;
using System;
using Xunit;

namespace DeckOfCards.Tests
{
  public class Deck_ReturnCardShould
  {
    [Fact]
    public void Return_Ace_Of_Diamond()
    {
      // Arrange 
      var deck = new Deck(DeckType.Empty);
      var card = new Card(SuitType.Diamond, FaceType.Ace);

      // Act
      deck.ReturnCard(card);

      var returnedCards = deck.ToArray();
      var lastCard = returnedCards[returnedCards.Length - 1];

      // Assert
      Assert.Equal(card, lastCard);
    }

    [Fact]
    public void Return_Jack_Of_Clubs()
    {
      // Arrange      
      var cards = new[] { new Card(SuitType.Diamond, FaceType.Ace),
                          new Card(SuitType.Spade, FaceType.Two),
                          new Card(SuitType.Heart, FaceType.Ten)
                        };
      var deck = new Deck(cards);
      var card = new Card(SuitType.Club, FaceType.Jack);

      // Act
      deck.ReturnCard(card);

      var returnedCards = deck.ToArray();
      var lastCard = returnedCards[returnedCards.Length - 1];

      // Assert
      Assert.Equal(card, lastCard);
    }

    [Fact]
    public void Throw_Exception_Given_53_Card()
    {
      // Arrange      
      var deck = new Deck(DeckType.Ordered);
      var card = new Card(SuitType.Club, FaceType.Jack);

      // Act
      Exception ex = Assert.Throws<ArgumentOutOfRangeException>(() => deck.ReturnCard(card));

      // Assert
      Assert.Equal($"The card '{card}' cannot be added. The deck already contains maximum cards of '{Deck.CollectionOf52Cards}'.{Environment.NewLine}Parameter name: card", ex.Message);
    }
  }
}