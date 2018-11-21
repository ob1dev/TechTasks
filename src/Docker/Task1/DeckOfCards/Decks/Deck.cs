using DeckOfCards.Cards;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeckOfCards.Decks
{
  public class Deck
  {
    public const int CollectionOf52Cards = 52;
    private Queue<ICard> deck;

    public Deck()
    {
      this.deck = new Queue<ICard>(CollectionOf52Cards);
    }

    public Deck(ICard[] cards) : this()
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
        this.InitDeck();
      }
      else if (type is DeckType.Unordered)
      {
        this.InitDeck();
        this.Shuffle();
      }
      else
      {
        throw new ArgumentException("Deck's type is not a recognized.", nameof(type));
      }
    }

    public ICard[] ToArray()
    {
      return this.deck.ToArray();
    }

    public ICard Deal()
    {
      ICard card = null;

      if (this.deck.Any())
      {
        card = this.deck.Dequeue();
      }

      return card;
    }

    public void ReturnCard(ICard card)
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
          var newPosition = this.SelectNewPosition(index, count);

          var tempCard = cards[index];
          cards[index] = cards[newPosition];
          cards[newPosition] = tempCard;
        }

        this.deck = new Queue<ICard>(cards);
      }
    }

    #region Private Methods

    private void InitDeck()
    {
      foreach (var suit in Enum.GetValues(typeof(SuitType)).Cast<SuitType>())
      {
        foreach (var face in Enum.GetValues(typeof(FaceType)).Cast<FaceType>())
        {
          switch (suit)
          {
            case SuitType.Spade:
              this.deck.Enqueue(new SpadeCard(face));
              break;

            case SuitType.Heart:
              this.deck.Enqueue(new HeartCard(face));
              break;

            case SuitType.Club:
              this.deck.Enqueue(new ClubCard(face));
              break;

            case SuitType.Diamond:
              this.deck.Enqueue(new DiamondCard(face));
              break;

            default:
              throw new ArgumentException($"The type of '{suit}' is not a recognized suit.", nameof(suit));
          }
        }
      }
    }

    private int SelectNewPosition(int currentPossition, int deckCount)
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