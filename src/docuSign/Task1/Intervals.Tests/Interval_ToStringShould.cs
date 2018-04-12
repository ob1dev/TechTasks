using Xunit;

namespace Intervals.Tests
{
  public class Interval_ToStringShould
  {
    [Fact]
    public void Return_String_3_And_5_Given_Interval_From_3_To_5()
    {
      // Arrange 
      var interval = new Interval(3, 5);

      // Act
      var result = interval.ToString();

      // Assert
      Assert.Equal("(3-5)", result);
    }
  }
}