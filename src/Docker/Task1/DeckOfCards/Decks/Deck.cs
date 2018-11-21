using DeckOfCards.Cards;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeckOfCards.Decks
{
  public class Deck
  {
    public const int CollectionOf52Cards = 52;
    private Queue<Card> deck;

    public Deck()
    {
      this.deck = new Queue<Card>(CollectionOf52Cards);
    }

    public Deck(Card[] cards) : this()
    {
      foreach (var card in cards)
      {
        this.deck.Enqueue(card);
      }
    }

    public Deck(DeckType type) : this()
    {
      if (type is DeckType.Empty)
      {
        // Nothing to do here. Base constructor initializes an empty deck.
      }
      else if (type is DeckType.Ordered)
      {
        this.InitializeDeck();
      }
      else if (type is DeckType.Unordered)
      {
        this.InitializeDeck();
        this.Shuffle();
      }
      else
      {
        throw new ArgumentException("Deck's type is not a recognized.", nameof(type));
      }
    }

    public Card[] ToArray()
    {
      return this.deck.ToArray();
    }

    public Card Deal()
    {
      Card card = null;

      if (this.deck.Any())
      {
        card = this.deck.Dequeue();
      }

      return card;
    }

    public void ReturnCard(Card card)
    {
      if (this.deck.Count == CollectionOf52Cards)
      {
        throw new ArgumentOutOfRangeException(nameof(card), $"The card '{card}' cannot be added. The deck already contains maximum cards of '{CollectionOf52Cards}'.");
      }

      if (card != null)
      {
        this.deck.Enqueue(card);
      }
    }

    public void Shuffle()
    {
      if (this.deck.Any())
      {
        var cards = this.deck.ToArray();
        var count = this.deck.Count;

        for (int index = 0; index < count; index++)
        {
          var newPosition = this.NewPosition(index, count);

          var tempCard = cards[index];
          cards[index] = cards[newPosition];
          cards[newPosition] = tempCard;
        }

        this.deck = new Queue<Card>(cards);
      }
    }

    #region Private Methods

    private void InitializeDeck()
    {
      foreach (var suit in Enum.GetValues(typeof(SuitType)).Cast<SuitType>())
      {
        foreach (var face in Enum.GetValues(typeof(FaceType)).Cast<FaceType>())
        {
          this.deck.Enqueue(new Card(suit, face));
        }
      }
    }

    private int NewPosition(int currentPossition, int deckCount)
    {
      var random = new Random();
      var nextPosition = currentPossition;

      while (currentPossition == nextPosition)
      {
        nextPosition = random.Next(0, deckCount);
      }

      return nextPosition;
    }

    #endregion
  }
}