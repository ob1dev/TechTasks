using System;

namespace DeckOfCards.Cards
{
  public class Card
  {
    private SuitType suit;
    private FaceType face;

    public Card(SuitType suit, FaceType face)
    {
      this.suit = suit;
      this.face = face;
    }

    public override string ToString()
    {
      var suitName = Enum.GetName(this.suit.GetType(), this.suit);
      var faceName = Enum.GetName(this.face.GetType(), this.face);

      return $"{faceName} of {suitName}s";
    }
  }
}