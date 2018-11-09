using System;
using System.Collections.Generic;
using System.Linq;
using DeckOfCards.Cards;

namespace DeckOfCards.Decks
{
  public class Deck
  {
    private List<Card> deck = new List<Card>(52);

    public Deck()
    {
      foreach (var suit in Enum.GetValues(typeof(SuitType)).Cast<SuitType>())
      {
        foreach (var face in Enum.GetValues(typeof(FaceType)).Cast<FaceType>())
        {
          this.deck.Add(new Card(suit, face));
        }
      }
    }

    public Deck(bool shuffled) : this()
    {
      if (shuffled)
      {
        this.Shuffle();
      }
    }

    public Card Deal()
    {
      Card card = null;

      if (this.deck.Any())
      {
        card = this.deck[0];
        this.deck.RemoveAt(0);
      }

      return card;
    }

    public void ReturnCard(Card card)
    {
      if (card != null)
      {
        this.deck.Add(card);
      }
    }

    public void Shuffle()
    {
      var deckCapacity = this.deck.Count;

      for (int index = 0; index < deckCapacity - 1; index++)
      {
        var nextPos = this.nextPosition(index, deckCapacity);
        var card = this.deck[index];

        this.deck.Insert(nextPos, card);
        this.deck.RemoveAt(index);
      }
    }

    private int nextPosition(int currentPossition, int deckCount)
    {
      var random = new Random();
      var nextPosition = currentPossition;

      while (currentPossition == nextPosition)
      {
        nextPosition = random.Next(0, deckCount);
      }

      return nextPosition;
    }
  }
}
