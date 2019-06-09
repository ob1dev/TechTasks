using Xunit;
using System;

namespace Sort.Tests
{
  public class SlideSort_FindSlicesShould
  {
    #region Validate Low and High Boundaries

    [Theory]
    [InlineData(0)]
    [InlineData(100001)]
    public void Throw_Exception_Given_Array_Length_Of_Out_Of_Range(int length)
    {
      // Arrange
      var array = (int[])Array.CreateInstance(typeof(int), length);

      // Act
      Exception ex = Assert.Throws<ArgumentOutOfRangeException>(() => SliceSort.FindSlices(array));

      // Assert
      Assert.Equal($"The length of the array must be between 1 and 100000.{Environment.NewLine}Parameter name: length", ex.Message);
    }
    
    [Theory]
    [InlineData(new[] { -1 })]
    [InlineData(new[] { 0 })]
    [InlineData(new[] { 100000001 })]
    public void Throw_Exception_Given_Array_With_Ivalide_Elements(int[] array)
    {
      // Act
      Exception ex = Assert.Throws<ArgumentOutOfRangeException>(() => SliceSort.FindSlices(array));

      // Assert
      Assert.Equal($"The values of the array elements must be between 1 and 100000000.{Environment.NewLine}Parameter name: element", ex.Message);
    }

    #endregion

    [Fact]
    public void Return_3_Given_Array_Of_2_4_1_6_5_9_7()
    {
      // Arrange 
      var array = new[] { 2, 4, 1, 6, 5, 9, 7 };

      // Act
      var actual = SliceSort.FindSlices(array).Count;

      // Assert
      Assert.Equal(3, actual);
    }

    [Fact]
    public void Return_1_Given_Array_Of_4_3_2_6_1()
    {
      // Arrange 
      var array = new[] { 4, 3, 2, 6, 1 };

      // Act
      var actual = SliceSort.FindSlices(array).Count;

      // Assert
      Assert.Equal(1, actual);
    }

    [Fact]
    public void Return_3_Given_Array_Of_2_1_6_4_3_7()
    {
      // Arrange 
      var array = new[] { 2, 1, 6, 4, 3, 7 };

      // Act
      var actual = SliceSort.FindSlices(array).Count;

      // Assert
      Assert.Equal(3, actual);
    }
  }
}