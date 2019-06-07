using System;

namespace Dice
{
  public class Die
  {
    private static readonly int MaxTopBottomSides = 7;

    public SideType TopSide { get; }

    public SideType BottomSide
    {
      get
      {
        return (SideType)(MaxTopBottomSides - (int)this.TopSide);
      }
    }

    public Die()
    {
      var random = new Random();
      this.TopSide = (SideType)random.Next(1, 7);
    }

    public Die(SideType side)
    {
      this.TopSide = side;
    }

    public MovesNecessary TryRotateTo(SideType side)
    {
      MovesNecessary result;

      if (this.TopSide == side)
      {
        result = MovesNecessary.None;
      }
      else if (this.BottomSide == side)
      {
        result = MovesNecessary.Two;
      }
      else
      {
        result = MovesNecessary.One;
      }

      return result;
    }
  }
}