using Xunit;

namespace Intervals.Tests
{
  public class Interval_OperatorLessShould
  {
    [Theory]
    [InlineData("(0-1)", "(2-3)")]
    [InlineData("(1-2)", "(3-4)")]
    public void Return_True_Given_Lesser_And_Greater_Intervals(string s1, string s2)
    {
      // Arrange 
      var i1 = Interval.Parse(s1);
      var i2 = Interval.Parse(s2);

      // Act
      var result = i1 < i2;

      // Assert
      Assert.True(result);
    }
  }
}
