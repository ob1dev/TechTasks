using Xunit;

namespace Intervals.Tests
{
  public class Interval_OperatorGreaterShould
  {
    [Theory]
    [InlineData("(2-3)", "(0-1)")]
    [InlineData("(3-4)", "(1-2)")]
    public void Return_True_Given_Lesser_And_Greater_Intervals(string s1, string s2)
    {
      // Arrange 
      var i1 = Interval.Parse(s1);
      var i2 = Interval.Parse(s2);

      // Act
      var result = i1 > i2;

      // Assert
      Assert.True(result);
    }
  }
}