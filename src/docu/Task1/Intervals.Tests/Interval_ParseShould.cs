using Xunit;

namespace Intervals.Tests
{
  public class Interval_ParseShould
  {
    [Theory]
    [InlineData("(3-5)")]
    [InlineData("(3 - 5)")]
    [InlineData("( 3-5 )")]
    [InlineData(" (3-5) ")]
    [InlineData(" ( 3 - 5 ) ")]
    public void Return_Interval_From_3_To_5_Given_Value_Of_3_And_5(string interval)
    {
      // Arrange 
      var expected = new Interval(3, 5);

      // Act
      var actual = Interval.Parse(interval);

      // Assert
      Assert.Equal(expected, actual);
    }
  }
}