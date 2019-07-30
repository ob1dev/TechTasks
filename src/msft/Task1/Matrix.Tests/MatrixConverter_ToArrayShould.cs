using Xunit;

namespace Matrix.Tests
{
  public class MatrixConverter_ToArrayShould
  {
    #region NxN Matrices

    [Fact]
    public void Return_1_Given_1x1_Matrix()
    {
      // Arrange
      int[,] matrix = 
        {
          {1}
        };

      // Act
      var result = MatrixConverter.ToArray(matrix);

      // Assert
      Assert.Equal("1", result);
    }

    [Fact]
    public void Return_1243_Given_2x2_Matrix()
    {
      // Arrange
      int[,] matrix =
        {
          { 1, 2 },
          { 3, 4 }
        };

      // Act
      var result = MatrixConverter.ToArray(matrix);

      // Assert
      Assert.Equal("1 2 4 3", result);
    }

    [Fact]
    public void Return_1236987456_Given_3x3_Matrix()
    {
      // Arrange
      int[,] matrix =
        {
          { 1, 2, 3 },
          { 4, 5, 6 },
          { 7, 8, 9 }
        };

      // Act
      var result = MatrixConverter.ToArray(matrix);

      // Assert
      Assert.Equal("1 2 3 6 9 8 7 4 5", result);
    }

    [Fact]
    public void Return_12348121615141395671110_Given_4x4_Matrix()
    {
      // Arrange
      int[,] matrix =
        {
          {  1,  2,  3,  4 },
          {  5,  6,  7,  8 },
          {  9, 10, 11, 12 },
          { 13, 14, 15, 16 },
        };

      // Act
      var result = MatrixConverter.ToArray(matrix);

      // Assert
      Assert.Equal("1 2 3 4 8 12 16 15 14 13 9 5 6 7 11 10", result);
    }

    #endregion

    #region NxM Matrices

    [Fact]
    public void Return_123654_Given_2x3_Matrix()
    {
      // Arrange
      int[,] matrix =
        {
          { 1, 2, 3 },
          { 4, 5, 6 }
        };

      // Act
      var result = MatrixConverter.ToArray(matrix);

      // Assert
      Assert.Equal("1 2 3 6 5 4", result);
    }

    [Fact]
    public void Return_124653_Given_3x2_Matrix()
    {
      // Arrange
      int[,] matrix =
        {
          { 1, 2 },
          { 3, 4 },
          { 5, 6 }
        };

      // Act
      var result = MatrixConverter.ToArray(matrix);

      // Assert
      Assert.Equal("1 2 4 6 5 3", result);
    }

    [Fact]
    public void Return_12348765_Given_2x4_Matrix()
    {
      // Arrange
      int[,] matrix =
        {
          { 1, 2, 3, 4 },
          { 5, 6, 7, 8 }
        };

      // Act
      var result = MatrixConverter.ToArray(matrix);

      // Assert
      Assert.Equal("1 2 3 4 8 7 6 5", result);
    }

    [Fact]
    public void Return_1236987456_Given_3x4_Matrix()
    {
      // Arrange
      int[,] matrix =
        {
          { 1,  2,  3,  4 },
          { 5,  6,  7,  8 },
          { 9, 10, 11, 12 }
        };

      // Act
      var result = MatrixConverter.ToArray(matrix);

      // Assert
      Assert.Equal("1 2 3 4 8 12 11 10 9 5 6 7", result);
    }

    #endregion
  }
}