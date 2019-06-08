using DiceTable.Dice;
using Xunit;

namespace DiceTable.Tests
{
  public class Die_TryRotateToShould
  {
    [Theory]
    [InlineData(SideType.OnePip)]
    [InlineData(SideType.TwoPips)]
    [InlineData(SideType.ThreePips)]
    [InlineData(SideType.FourPips)]
    [InlineData(SideType.FivePips)]
    [InlineData(SideType.SixPips)]
    public void Return_0_Given_Top_Side(SideType top)
    {
      // Arrange 
      var die = new Die(top);

      // Act
      var actual = die.TryRotateTo(top);

      // Assert
      Assert.Equal(MovesNecessary.None, actual);
    }

    [Theory]
    [InlineData(SideType.OnePip, SideType.TwoPips)]
    [InlineData(SideType.OnePip, SideType.ThreePips)]
    [InlineData(SideType.OnePip, SideType.FourPips)]
    [InlineData(SideType.OnePip, SideType.FivePips)]

    [InlineData(SideType.TwoPips, SideType.OnePip)]
    [InlineData(SideType.TwoPips, SideType.ThreePips)]
    [InlineData(SideType.TwoPips, SideType.FourPips)]
    [InlineData(SideType.TwoPips, SideType.SixPips)]

    [InlineData(SideType.ThreePips, SideType.OnePip)]
    [InlineData(SideType.ThreePips, SideType.TwoPips)]
    [InlineData(SideType.ThreePips, SideType.FivePips)]
    [InlineData(SideType.ThreePips, SideType.SixPips)]

    [InlineData(SideType.FourPips, SideType.OnePip)]
    [InlineData(SideType.FourPips, SideType.TwoPips)]
    [InlineData(SideType.FourPips, SideType.FivePips)]
    [InlineData(SideType.FourPips, SideType.SixPips)]

    [InlineData(SideType.FivePips, SideType.OnePip)]
    [InlineData(SideType.FivePips, SideType.ThreePips)]
    [InlineData(SideType.FivePips, SideType.FourPips)]
    [InlineData(SideType.FivePips, SideType.SixPips)]

    [InlineData(SideType.SixPips, SideType.TwoPips)]
    [InlineData(SideType.SixPips, SideType.ThreePips)]
    [InlineData(SideType.SixPips, SideType.FourPips)]
    [InlineData(SideType.SixPips, SideType.FivePips)]
    public void Return_1_Given_Any_Adjacent_Side(SideType top, SideType adjacent)
    {
      // Arrange 
      var die = new Die(top);

      // Act
      var actual = die.TryRotateTo(adjacent);

      // Assert
      Assert.Equal(MovesNecessary.One, actual);
    }

    [Theory]
    [InlineData(SideType.OnePip, SideType.SixPips)]
    [InlineData(SideType.TwoPips, SideType.FivePips)]
    [InlineData(SideType.ThreePips, SideType.FourPips)]
    [InlineData(SideType.FourPips, SideType.ThreePips)]
    [InlineData(SideType.FivePips, SideType.TwoPips)]
    [InlineData(SideType.SixPips, SideType.OnePip)]
    public void Return_2_Given_Bottom_Side(SideType top, SideType bottom)
    {
      // Arrange 
      var die = new Die(top);

      // Act
      var actual = die.TryRotateTo(bottom);

      // Assert
      Assert.Equal(MovesNecessary.Two, actual);
    }
  }
}