using System;
using System.Collections.Generic;
using Xunit;

namespace Triangle.Tests
{
  public class ShapeService_ClassifyTriangleShould
  {
    private readonly ShapeService shapeService;

    public ShapeService_ClassifyTriangleShould()
    {
      this.shapeService = new ShapeService();
    }

    #region Validate Boundaries

    [Theory]
    [InlineData( 0,  0,  0)]
    [InlineData( 1,  1,  2)]
    [InlineData(-1,  0,  1)]
    [InlineData(-1, -1, -1)]
    [InlineData(-1,  1,  1)]
    [InlineData( 1, -1,  1)]
    [InlineData( 1,  1, -1)]
    [InlineData( 3,  3,  5000)]
    [InlineData( 1,  1,  int.MaxValue)]
    [InlineData(int.MinValue, int.MinValue, int.MinValue)]
    public void Throw_Exception_Given_Value_Of_NotExistentTriangle(int a, int b, int c)
    {
      // Act
      Exception ex = Assert.Throws<ArgumentException>(() => this.shapeService.ClassifyTriangle(a, b, c));

      // Assert
      Assert.StartsWith($"Triangle with the given lengths of the sides a='{a}', b='{b}' and c='{c}' does not exist.", ex.Message);
    }

    #endregion

    #region Validate Equilateral Triangle

    [Fact]
    public void Return_Equilateral_Given_Value_Of_1_1_1()
    {
      // Arrange    
      int a = 1;
      int b = 1;
      int c = 1;

      this.shapeService.TrianglesTypes = new List<TriangleType>() { TriangleType.Equilateral };

      // Act
      var result = this.shapeService.ClassifyTriangle(a, b, c);

      // Assert
      Assert.True(result == TriangleType.Equilateral); 
    }

    [Fact]
    public void Return_Equilateral_Given_Value_Of_Int32Max_Int32Max_Int32Max()
    {
      // Arrange
      int a = int.MaxValue;
      int b = int.MaxValue;
      int c = int.MaxValue;

      this.shapeService.TrianglesTypes = new List<TriangleType>() { TriangleType.Equilateral };

      // Act
      var result = this.shapeService.ClassifyTriangle(a, b, c);

      // Assert
      Assert.True(result == TriangleType.Equilateral);
    }

    #endregion

    #region Validate Isosceles Triangle

    [Fact]
    public void Return_Isosceles_Given_Value_Of_3_3_5()
    {
      // Arrange
      int a = 3;
      int b = 3;
      int c = 5;

      this.shapeService.TrianglesTypes = new List<TriangleType>() { TriangleType.Isosceles };

      // Act
      var result = this.shapeService.ClassifyTriangle(a, b, c);

      // Assert
      Assert.True(result == TriangleType.Isosceles);
    }

    [Fact]
    public void Return_Isosceles_Given_Value_Of_10_10_5()
    {
      // Arrange
      int a = 10;
      int b = 10;
      int c = 5;

      this.shapeService.TrianglesTypes = new List<TriangleType>() { TriangleType.Isosceles };

      // Act
      var result = this.shapeService.ClassifyTriangle(a, b, c);

      // Assert
      Assert.True(result == TriangleType.Isosceles);
    }

    [Fact]
    public void Return_Isosceles_Given_Value_Of_15_1_15()
    {
      // Arrange
      int a = 15;
      int b = 1;
      int c = 15;

      this.shapeService.TrianglesTypes = new List<TriangleType>() { TriangleType.Isosceles };

      // Act
      var result = this.shapeService.ClassifyTriangle(a, b, c);

      // Assert
      Assert.True(result == TriangleType.Isosceles);
    }

    #endregion

    #region Validate Right Triangle

    [Fact]
    public void Return_Right_Given_Value_Of_6_8_10()
    {
      // Arrange
      int a = 6;
      int b = 8;
      int c = 10;

      this.shapeService.TrianglesTypes = new List<TriangleType>() { TriangleType.Right };

      // Act
      var result = this.shapeService.ClassifyTriangle(a, b, c);

      // Assert
      Assert.True(result == TriangleType.Right);
    }

    [Fact]
    public void Return_Right_Given_Value_Of_10_6_8()
    {
      // Arrange
      int a = 10;
      int b = 6;
      int c = 8;

      this.shapeService.TrianglesTypes = new List<TriangleType>() { TriangleType.Right };

      // Act
      var result = this.shapeService.ClassifyTriangle(a, b, c);

      // Assert
      Assert.True(result == TriangleType.Right);
    }

    [Fact]
    public void Return_Right_Given_Value_Of_8_10_6()
    {
      // Arrange
      int a = 8;
      int b = 10;
      int c = 6;

      this.shapeService.TrianglesTypes = new List<TriangleType>() { TriangleType.Right };

      // Act
      var result = this.shapeService.ClassifyTriangle(a, b, c);

      // Assert
      Assert.True(result == TriangleType.Right);
    }

    #endregion

    #region Validate Scalene Triangle

    [Fact]
    public void Return_Scalene_Given_Value_Of_3_4_5()
    {
      // Arrange
      int a = 3;
      int b = 4;
      int c = 5;

      //this.shapeService.Types = TriangleType.Scalene;
      this.shapeService.TrianglesTypes = new List<TriangleType>() { TriangleType.Scalene };

      // Act
      var result = this.shapeService.ClassifyTriangle(a, b, c);

      // Assert
      Assert.True(result == TriangleType.Scalene);
    }

    [Fact]
    public void Return_Scalene_Given_Value_Of_5_3_4()
    {
      // Arrange
      int a = 5;
      int b = 3;
      int c = 4;

      //this.shapeService.Types = TriangleType.Scalene;
      this.shapeService.TrianglesTypes = new List<TriangleType>() { TriangleType.Scalene };

      // Act
      var result = this.shapeService.ClassifyTriangle(a, b, c);

      // Assert
      Assert.True(result == TriangleType.Scalene);
    }

    [Fact]
    public void Return_Scalene_Given_Value_Of_4_5_3()
    {
      // Arrange
      int a = 4;
      int b = 5;
      int c = 3;

      //this.shapeService.Types = TriangleType.Scalene;
      this.shapeService.TrianglesTypes = new List<TriangleType>() { TriangleType.Scalene };

      // Act
      var result = this.shapeService.ClassifyTriangle(a, b, c);

      // Assert
      Assert.True(result == TriangleType.Scalene);
    }

    #endregion
  }
}