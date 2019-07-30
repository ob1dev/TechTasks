using System;

namespace DeckOfCards.Cards
{
  public abstract class BaseCard : ICard
  {
    protected readonly SuitType suit;
    protected readonly FaceType face;

    public SuitType Suit
    {
      get
      {
        return this.suit;
      }
    }

    public FaceType Face
    {
      get
      {
        return this.face;
      }
    }

    protected BaseCard(SuitType suit, FaceType face)
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