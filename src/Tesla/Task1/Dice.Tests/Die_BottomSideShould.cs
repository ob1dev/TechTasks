using Xunit;

namespace Dice.Tests
{
  public class Die_BottomSideShould
  {
    [Fact]
    public void Return_One_Pip_If_Top_Side_Six_Pips()
    {
      // Arrange 
      var die = new Die(SideType.SixPips);

      // Act
      var actual = die.BottomSide;

      // Assert
      Assert.Equal(SideType.OnePip, actual);
    }

    [Fact]
    public void Return_Two_Pips_If_Top_Side_Five_Pips()
    {
      // Arrange 
      var die = new Die(SideType.FivePips);

      // Act
      var actual = die.BottomSide;

      // Assert
      Assert.Equal(SideType.TwoPips, actual);
    }

    [Fact]
    public void Return_Three_Pips_If_Top_Side_Four_Pips()
    {
      // Arrange 
      var die = new Die(SideType.FourPips);

      // Act
      var actual = die.BottomSide;

      // Assert
      Assert.Equal(SideType.ThreePips, actual);
    }

    [Fact]
    public void Return_Four_Pips_If_Top_Side_Three_Pips()
    {
      // Arrange 
      var die = new Die(SideType.ThreePips);

      // Act
      var actual = die.BottomSide;

      // Assert
      Assert.Equal(SideType.FourPips, actual);
    }

    [Fact]
    public void Return_Five_Pips_If_Top_Side_Two_Pips()
    {
      // Arrange 
      var die = new Die(SideType.TwoPips);

      // Act
      var actual = die.BottomSide;

      // Assert
      Assert.Equal(SideType.FivePips, actual);
    }

    [Fact]
    public void Return_Six_Pips_If_Top_Side_one_Pip()
    {
      // Arrange 
      var die = new Die(SideType.OnePip);

      // Act
      var actual = die.BottomSide;

      // Assert
      Assert.Equal(SideType.SixPips, actual);
    }
  }
}