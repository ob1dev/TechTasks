using System;
using Xunit;

namespace Task1.Tests
{
  public class Sum_SolutionShould
  {
    [Fact]
    public void Return_0_Given_Empty_Array()
    {
      // Arrange 
      var sum = new Sum();
      var array = (int[])Array.CreateInstance(typeof(int), 0);

      // Act
      var actual = sum.Solution(array);

      // Assert
      Assert.Equal(0, actual);
    }

    [Fact]
    public void Return_0_Given_IntMinValue_IntMaxValue()
    {
      // Arrange 
      var sum = new Sum();
      var array = new[] { int.MinValue, int.MaxValue };

      // Act
      var actual = sum.Solution(array);

      // Assert
      Assert.Equal(0, actual);
    }

    [Fact]
    public void Return_0_Given_IntMaxValue_IntMaxValue()
    {
      // Arrange 
      var sum = new Sum();
      var array = new[] { int.MaxValue, int.MaxValue };

      // Act
      var actual = sum.Solution(array);

      // Assert
      Assert.Equal(0, actual);
    }

    [Fact]
    public void Return_0_Given_IntMinValue_IntMinValue()
    {
      // Arrange 
      var sum = new Sum();
      var array = new[] { int.MinValue, int.MinValue };

      // Act
      var actual = sum.Solution(array);

      // Assert
      Assert.Equal(0, actual);
    }

    [Fact]
    public void Return_Negative_11_Given_1_1000_80_Negative_91()
    {
      // Arrange 
      var sum = new Sum();
      var array = new[] { 1, 1000, 80, -91 };

      // Act
      var actual = sum.Solution(array);

      // Assert
      Assert.Equal(-11, actual);
    }

    [Fact]
    public void Return_182_Given_47_1900_1_90_45()
    {
      // Arrange 
      var sum = new Sum();
      var array = new[] { 47, 1900, 1, 90, 45 };

      // Act
      var actual = sum.Solution(array);

      // Assert
      Assert.Equal(182, actual);
    }

    [Fact]
    public void Return_32_Given_Negative_13_1900_1_100_45()
    {
      // Arrange 
      var sum = new Sum();
      var array = new[] { -13, 1900, 1, 100, 45 };

      // Act
      var actual = sum.Solution(array);

      // Assert
      Assert.Equal(32, actual);
    }
  }
}