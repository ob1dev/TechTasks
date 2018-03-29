using System;
using Xunit;

namespace Converter.Tests
{
  public class NumeralsConverter_ToRomanShould
  {
    #region Validate Default Seven Symbols

    [Fact]
    public void Return_I_Given_Value_Of_1()
    {
      var result = NumeralsConverter.ToRoman(1);

      Assert.Equal("I", result);
    }
    
    [Fact]
    public void Return_V_Given_Value_Of_5()
    {
      var result = NumeralsConverter.ToRoman(5);

      Assert.Equal("V", result);
    }

    [Fact]
    public void Return_X_Given_Value_Of_10()
    {
      var result = NumeralsConverter.ToRoman(10);

      Assert.Equal("X", result);
    }

    [Fact]
    public void Return_L_Given_Value_Of_50()
    {
      var result = NumeralsConverter.ToRoman(50);

      Assert.Equal("L", result);
    }

    [Fact]
    public void Return_L_Given_Value_Of_100()
    {
      var result = NumeralsConverter.ToRoman(100);

      Assert.Equal("C", result);
    }

    [Fact]
    public void Return_L_Given_Value_Of_500()
    {
      var result = NumeralsConverter.ToRoman(500);

      Assert.Equal("D", result);
    }

    [Fact]
    public void Return_L_Given_Value_Of_1000()
    {
      var result = NumeralsConverter.ToRoman(1000);

      Assert.Equal("M", result);
    }

    #endregion

    #region Validate Low and High Boundaries

    [Theory]
    [InlineData(1001)]
    [InlineData(0)]
    [InlineData(-1)]
    public void Throw_Exception_Given_Values_Is_Out_Of_Range(int value)
    {
      Exception ex = Assert.Throws<ArgumentOutOfRangeException>(() => NumeralsConverter.ToRoman(value));

      Assert.Equal($"The value '{value}' must be between 1 and 1000.{Environment.NewLine}Parameter name: number", ex.Message);
    }

    #endregion

    #region Validate Alternative Forms

    [Fact]
    public void Return_IIII_Given_Value_Of_4()
    {
      var result = NumeralsConverter.ToRoman(4);

      Assert.Equal("IIII", result);
    }

    [Fact]
    public void Return_VIIII_Given_Value_Of_8()
    {
      var result = NumeralsConverter.ToRoman(8);

      Assert.Equal("VIII", result);
    }

    [Fact]
    public void Return_VIIII_Given_Value_Of_9()
    {
      var result = NumeralsConverter.ToRoman(9);

      Assert.Equal("VIIII", result);
    }

    #endregion
  }
}
