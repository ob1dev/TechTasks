using Xunit;

namespace Intervals.Tests
{
  public class Interval_IntersectWithShould
  {
    [Theory]
    [InlineData("(1-2)", "(2-3)", Intersection.Right)]    
    [InlineData("(1-3)", "(2-4)", Intersection.Right)]
    [InlineData("(1-3)", "(1-4)", Intersection.Right)]

    [InlineData("(3-5)", "(1-3)", Intersection.Left)]
    [InlineData("(3-5)", "(1-4)", Intersection.Left)]
    [InlineData("(3-5)", "(1-5)", Intersection.Left)]

    [InlineData("(2-5)", "(2-5)", Intersection.Both)]
    [InlineData("(2-5)", "(3-4)", Intersection.Both)]
    [InlineData("(2-5)", "(1-6)", Intersection.Both)]
    [InlineData("(2-5)", "(3-5)", Intersection.Both)]
    [InlineData("(2-5)", "(2-4)", Intersection.Both)]
    public void Return_True_Given_Lesser_And_Greater_Intervals(string s1, string s2, Intersection expectedPoint)
    {
      // Arrange 
      var i1 = Interval.Parse(s1);
      var i2 = Interval.Parse(s2);

      // Act
      var actualPoint = Intersection.None;
      var result = i1.IntersectWith(i2, out actualPoint);

      // Assert
      Assert.Equal(expectedPoint, actualPoint);
    }
  }
}