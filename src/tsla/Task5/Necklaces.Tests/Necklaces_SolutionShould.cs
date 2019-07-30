using System;
using Xunit;

namespace Task3.Tests
{
  public class Necklaces_SolutionShould
  {
    [Fact]
    public void Return_0_Given_Empty_Array()
    {
      // Arrange 
      var necklaces = new Necklaces();
      var array = (int[])Array.CreateInstance(typeof(int), 0);

      // Act
      var actual = necklaces.Solution(array);

      // Assert
      Assert.Equal(0, actual);
    }

    [Fact]
    public void Return_0_Given_Array_With_Zero_Index()
    {
      // Arrange 
      var necklaces = new Necklaces();
      var array = new[] { 0 };

      // Act
      var actual = necklaces.Solution(array);

      // Assert
      Assert.Equal(1, actual);
    }

    [Fact]
    public void Return_0_Given_Array_With_Indexes_5_4_0_3_1_6_2()
    {
      // Arrange 
      var necklaces = new Necklaces();
      var array = new[] { 5, 4, 0, 3, 1, 6, 2 };

      // Act
      var actual = necklaces.Solution(array);

      // Assert
      Assert.Equal(4, actual);
    }
  }
}