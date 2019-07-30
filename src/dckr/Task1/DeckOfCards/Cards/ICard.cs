namespace DeckOfCards.Cards
{
  public interface ICard
  {
    SuitType Suit { get; }
    FaceType Face { get; }
  }
}