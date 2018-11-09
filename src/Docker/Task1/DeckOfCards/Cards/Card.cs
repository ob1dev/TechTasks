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
  }
}