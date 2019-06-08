using System;
using Xunit;

namespace DiceTable.Tests
{
  public class Table_FindMinMovesNecessaryShould
  {
    #region Validate Low and High Boundaries

    [Theory]
    [InlineData(101)]
    [InlineData(0)]
    [InlineData(-1)]
    public void Throw_Exception_Given_Dice_Of_Out_Of_Range(int value)
    {
      // Act
      Exception ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Table(value));

      // Assert
      Assert.Equal($"The number of dice on a table must be between 1 and 100.{Environment.NewLine}Parameter name: number", ex.Message);
    }

    [Theory]
    [InlineData(7)]
    [InlineData(0)]
    [InlineData(-1)]
    public void Throw_Exception_Given_Invalide_Die(int value)
    {
      // Arrange 
      var dice = new[] { value };

      // Act
      Exception ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Table(dice));

      // Assert
      Assert.Equal($"The die side must be between 1 and 6.{Environment.NewLine}Parameter name: die", ex.Message);
    }

    [Theory]
    [InlineData(new[] { 0, 1, 2 })]
    [InlineData(new[] { 1, 0, 3 })]
    [InlineData(new[] { 1, 2, 0 })]
    public void Throw_Exception_Given_Invalide_Dice(int[] dice)
    {
      // Act
      Exception ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Table(dice));

      // Assert
      Assert.Equal($"The die side must be between 1 and 6.{Environment.NewLine}Parameter name: die", ex.Message);
    }

    #endregion

    #region Validate Simple Cases

    [Theory]
    [InlineData(new[] { 1 })]
    [InlineData(new[] { 2 })]
    [InlineData(new[] { 3 })]
    [InlineData(new[] { 4 })]
    [InlineData(new[] { 5 })]
    [InlineData(new[] { 6 })]
    public void Return_0_Given_Single_Die(int[] dice)
    {
      // Arrange 
      var table = new Table(dice);

      // Act
      var actual = table.FindMinMovesNecessary();

      // Assert
      Assert.Equal(0, actual);
    }

    [Theory]
    [InlineData(new[] { 1, 1 })]
    [InlineData(new[] { 2, 2 })]
    [InlineData(new[] { 3, 3 })]
    [InlineData(new[] { 4, 4 })]
    [InlineData(new[] { 5, 5 })]
    [InlineData(new[] { 6, 6 })]
    public void Return_0_Given_Identical_Dice(int[] dice)
    {
      // Arrange 
      var table = new Table(dice);

      // Act
      var actual = table.FindMinMovesNecessary();

      // Assert
      Assert.Equal(0, actual);
    }

    [Theory]
    [InlineData(new[] { 1, 2 })]
    [InlineData(new[] { 2, 1 })]
    [InlineData(new[] { 2, 3 })]
    [InlineData(new[] { 3, 2 })]
    [InlineData(new[] { 4, 5 })]
    [InlineData(new[] { 5, 4 })]
    [InlineData(new[] { 5, 6 })]
    [InlineData(new[] { 6, 5 })]
    public void Return_1_Given_Dice_With_Adjacent_Sides(int[] dice)
    {
      // Arrange 
      var table = new Table(dice);

      // Act
      var actual = table.FindMinMovesNecessary();

      // Assert
      Assert.Equal(1, actual);
    }

    [Theory]
    [InlineData(new[] { 1, 6 })]
    [InlineData(new[] { 6, 1 })]
    [InlineData(new[] { 2, 5 })]
    [InlineData(new[] { 5, 2 })]
    [InlineData(new[] { 4, 3 })]
    [InlineData(new[] { 3, 4 })]
    public void Return_2_Given_Dice_With_Opposite_Sides(int[] dice)
    {
      // Arrange 
      var table = new Table(dice);

      // Act
      var actual = table.FindMinMovesNecessary();

      // Assert
      Assert.Equal(2, actual);
    }

    #endregion

    #region Validate Alternative Cases

    [Fact]
    public void Return_2_Given_Dice_1_2_3()
    {
      // Arrange 
      var dice = new[] { 1, 2, 3 };
      var table = new Table(dice);

      // Act
      var actual = table.FindMinMovesNecessary();

      // Assert
      Assert.Equal(2, actual);
    }

    [Fact]
    public void Return_2_Given_Dice_1_1_6()
    {
      // Arrange 
      var dice = new[] { 1, 1, 6 };
      var table = new Table(dice);

      // Act
      var actual = table.FindMinMovesNecessary();

      // Assert
      Assert.Equal(2, actual);
    }

    [Fact]
    public void Return_3_Given_Dice_1_6_2_3()
    {
      // Arrange 
      var dice = new[] { 1, 6, 2, 3 };
      var table = new Table(dice);

      // Act
      var actual = table.FindMinMovesNecessary();

      // Assert
      Assert.Equal(3, actual);
    }

    #endregion
  }
}